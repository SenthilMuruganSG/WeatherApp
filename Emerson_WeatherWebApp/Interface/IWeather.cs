using Emerson_WeatherApp.Entity;
using Emerson_WeatherApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emerson_WeatherApp.Interface
{
    public interface IWeather
    {
        Task<WeatherResponse> GetVariableData(WeatherRequest weatherRequest);
        Task<CityHighTemperatureResponse> GetHighTemperatureCityData(int Month);
        Task<CityAverageHumidityResponse> GetHighHumidityCityData(int Month);

        Task<CityListResponse> GetCityList();
    }
}
