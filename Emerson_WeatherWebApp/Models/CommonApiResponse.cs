namespace Emerson_WeatherApp.Models
{
    public class CommonApiResponse
    {
        public string ErrorCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;

    }
}
