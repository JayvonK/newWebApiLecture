using Microsoft.AspNetCore.Mvc;

// our root file. its a way for c# to organize our code
// newWebApi = parent folder
// Controllers = is our Controller folder
namespace newWebApi.Controllers;

// ApiController = is a AspNetCore.Mvc special attribute that marks this class as a API controller 
[ApiController]
// Route = is the route to this controller
[Route("[controller]")]

// the name of our class, WeatherForecastController
// : ControllerBase = inherits from AspNetCore.Mvc. It provides set of common functions, like GET, POST, ETC...
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    //this is a class
    private readonly ILogger<WeatherForecastController> _logger;

    // constructor = allows you to setup initial values or configurations for an object when it is created. This ensures that the object starts in a valid and consisten state
    // For example, a bike factory, when the frame and wheels are made, there is a station that takes care of putting them together. Thats the constructor
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // This would be the READ in our CRUD functions
    [HttpGet(Name = "GetWeatherForecast")]

    // IEnumerable = a collection of objects that can be enumerated (iterated) one at a time
    public IEnumerable<WeatherForecast> Get()
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
