namespace Emerson_WeatherApp.Entity
{
    public class Variable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Unit { get;set; }
        public DateTimeOffset Timestamp { get; set; }
        public int CityId { get; set; }
    }
}
