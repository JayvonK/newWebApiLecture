using Microsoft.AspNetCore.Mvc;
using newWebApi.Services;

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

    // Creating basically another variable or class and calling 
    private readonly WeatherForecastService _data;

    // constructor = allows you to setup initial values or configurations for an object when it is created. This ensures that the object starts in a valid and consisten state
    // For example, a bike factory, when the frame and wheels are made, there is a station that takes care of putting them together. Thats the constructor
    // We're injecting WeatherForecastService into the constructor, controller is able to get the necessary services from our services
    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastService data)
    {
        _logger = logger;
        _data = data;
    }

    // This would be the READ in our CRUD functions
    [HttpGet(Name = "GetWeatherForecast")]

    // IEnumerable = a collection of objects that can be enumerated (iterated) one at a time
    public IEnumerable<WeatherForecast> GetWeather()
    {
        return _data.GetWeather(Summaries);
    }
}
