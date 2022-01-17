using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace LearningHttpClient.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        //private readonly IHttpClientFactory _httpClientFactory;

        // private static HttpClient _httpclient;

        // static WeatherForecastController()
        // {
        //     _httpclient = new HttpClient();
        // }

        //Names Client
        // public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        // {
        //     _logger = logger;
        //     _httpClientFactory = httpClientFactory;
        // }


        // Typed Client
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        // Named Client
        // [HttpGet]
        // public async Task<string> Get(string cityName)
        // {
        //     string URL = $"?key=bc5597bc5e8e4031acd90433221701&q={cityName}&aqi=yes";

        //     var httpClient = _httpClientFactory.CreateClient("WeatherApi");
        //     var resultContent = await httpClient.GetAsync(URL);

        //     return await resultContent.Content.ReadAsStringAsync();
        // }

     //Typed Client
        [HttpGet]
        public async Task<string> Get(string cityName)
        {
           var contentType = HttpContext.Request.ContentType;  
           return await _weatherForecastService.GetWeatherDetails(cityName);
        }

    }
}
