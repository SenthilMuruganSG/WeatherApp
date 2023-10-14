using Emerson_WeatherApp.Entity;

namespace Emerson_WeatherApp.Models
{

    public class CityAverageHumidityResponse:CommonApiResponse
    {
        public CityAverageHumidity? cityAverageHumidity { get; set; }
    }
    public class CityAverageHumidity
    {
        public string CityName { get; set; }
        public decimal AverageHumidity { get; set; }
    }
    public class CityListResponse : CommonApiResponse
    {
        public List<City> CityList { get; set; }
    }
}
