using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newWebApi.Services
{
    public class WeatherForecastService
    {
        public WeatherForecastService()
        {

        }

        // copied over function from controller
        // added string[] Summaries into the parameter of our GetWeather function
        // updated the name of our function to GetWeather
        public IEnumerable<WeatherForecast> GetWeather(string[] Summaries)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}