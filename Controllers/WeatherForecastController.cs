using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ODataIssue.Controllers
{
    public class WeatherController : ODataController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [EnableQuery(MaxAnyAllExpressionDepth = 3)]
        [ODataRouteComponent]
        public IQueryable<Weather> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Weather
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                City = new City()
                {
                    Id = Guid.NewGuid(),
                    Name = Guid.NewGuid().ToString()
                }
            }).AsQueryable();
        }
    }
}