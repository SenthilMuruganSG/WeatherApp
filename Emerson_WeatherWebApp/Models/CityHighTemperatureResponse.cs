using Emerson_WeatherApp.Entity;

namespace Emerson_WeatherApp.Models
{
    public class CityHighTemperatureResponse : CommonApiResponse
    {
        public CityHighTemperature? cityHighTemperature { get; set; }
    }
    public class CityHighTemperature
    {
        public string CityName { get; set; }
        public int TotalDays { get; set; }
    }

}
