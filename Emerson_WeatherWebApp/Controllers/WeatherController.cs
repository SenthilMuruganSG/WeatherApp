using Emerson_WeatherApp.Interface;
using Emerson_WeatherApp.Models;
using Emerson_WeatherApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Emerson_WeatherApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    { 
        private readonly IWeather _weather;
        public WeatherController(IWeather weather) {
            _weather = weather;
        }
       
        [HttpPost("GetVariableData")]
        public Task<WeatherResponse> GetVariableData(WeatherRequest weatherRequest)
        {
            return _weather.GetVariableData(weatherRequest);
        }
 
        [HttpGet("GetHighTemperatureCityData/{month}")]
        public Task<CityHighTemperatureResponse> GetHighTemperatureCityData(int Month)
        {
            return _weather.GetHighTemperatureCityData(Month);
        }

        
        [HttpGet("GetAvgHumidityCityData/{month}")]
        public Task<CityAverageHumidityResponse> GetAvgHumidityCityData(int Month)
        {
            return _weather.GetHighHumidityCityData(Month);
        }

        [HttpGet("GetCityList")]
        public Task<CityListResponse> GetCityList()
        {
            return _weather.GetCityList();
        }
    }
}
