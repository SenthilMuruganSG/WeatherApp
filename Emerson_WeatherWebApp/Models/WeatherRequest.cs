namespace Emerson_WeatherApp.Models
{
    public class WeatherRequest
    {
        public string VariableName { get; set; }
        public int  CityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
    }


}
