using Emerson_WeatherApp.Entity;

namespace Emerson_WeatherApp.Models
{
    public class WeatherResponse:CommonApiResponse
    {
       public List<VariableData> variableDatas { get; set; }
    }

    public class VariableData:Variable
    {
        public string CityName { get; set; }
    }
     
}
