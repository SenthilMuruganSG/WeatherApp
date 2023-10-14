using Emerson_WeatherApp.DataContext;
using Emerson_WeatherApp.Entity;
using Emerson_WeatherApp.Interface;
using Emerson_WeatherApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Emerson_WeatherApp.Services
{
    public class WeatherService : IWeather
    {
        private WeatherDbContext _weatherDbContext;

        public WeatherService(
        WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;

        }

        public async Task<CityListResponse> GetCityList()
        {
            var city = new CityListResponse();
            try
            {
                if (_weatherDbContext != null)
                {
                    var cityList = _weatherDbContext.City?.ToList();

                    if (cityList != null && cityList.Count > 0)
                    {

                    }
                    city.CityList = cityList;
                }

            }
            catch (Exception ex)
            {
                city.IsSuccess = false;
                city.Message = ex.Message;
            }
            return city;
        }

        public async Task<CityAverageHumidityResponse> GetHighHumidityCityData(int Month)
        {
            var response = new CityAverageHumidityResponse();
            try
            {
                if (_weatherDbContext != null)
                {

                    response.cityAverageHumidity = (from dtvariable in _weatherDbContext.Variable
                                                    join dtCity in _weatherDbContext.City on dtvariable.CityId equals dtCity.Id
                                                    where dtvariable.Name == "Humidity"
                                                    group new { dtvariable, dtCity } by new { dtvariable.CityId, dtCity.CityName }
                                                    into list
                                                    select new CityAverageHumidity
                                                    {
                                                        CityName = list.First().dtCity.CityName,
                                                        AverageHumidity = list.Average(list => Convert.ToDecimal(list.dtvariable.Value))
                                                    }).OrderByDescending(x => x.AverageHumidity).FirstOrDefault();
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<CityHighTemperatureResponse> GetHighTemperatureCityData(int Month)
        {
            var response = new CityHighTemperatureResponse();
            try
            {
                if (_weatherDbContext != null)
                {


                    response.cityHighTemperature = (from dtVariable in _weatherDbContext.Variable
                                                    join dtCity in _weatherDbContext.City on dtVariable.CityId equals dtCity.Id
                                                    where Convert.ToDouble(dtVariable.Value) > 30 && dtVariable.Name == "Temperature"
                                                    group dtCity by dtCity.CityName into list
                                                    select new CityHighTemperature
                                                    {
                                                        CityName = list.First().CityName,
                                                        TotalDays = list.Count()
                                                    }).OrderByDescending(x => x.TotalDays).FirstOrDefault();

                   
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<WeatherResponse> GetVariableData(WeatherRequest weatherRequest)
        {
            var response = new WeatherResponse();

            try
            {
                if (_weatherDbContext != null)
                {

                    response.variableDatas = null;

                    response.variableDatas = (from dtVariable in _weatherDbContext.Variable
                                              join dtCity in _weatherDbContext.City on dtVariable.CityId equals dtCity.Id
                                              where dtVariable.Name == weatherRequest.VariableName && dtVariable.CityId == weatherRequest.CityId &&
                                              (dtVariable.Timestamp >= weatherRequest.StartDate && dtVariable.Timestamp <= weatherRequest.EndDate)
                                              select new VariableData
                                              {
                                                  Value = dtVariable.Value,
                                                  Name = dtVariable.Name,
                                                  Timestamp = dtVariable.Timestamp,
                                                  CityId = dtCity.Id,
                                                  CityName = dtCity.CityName,
                                                  Unit = dtVariable.Unit,
                                                  Id = dtVariable.Id,
                                              }).ToList();

                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
