using System.Threading.Tasks;
using System.Net.Http;

namespace LearningHttpClient.WebApi
{

    public interface IWeatherForecastService
    {
        Task<string> GetWeatherDetails(string cityName);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetWeatherDetails(string cityName)
        {
             string URL = $"?key=bc5597bc5e8e4031acd90433221701&q={cityName}&aqi=yes";
             var resultContent = await  _httpClient.GetAsync(URL);

             var response = await resultContent.Content.ReadAsStringAsync();

             return response;

        }

    }

}