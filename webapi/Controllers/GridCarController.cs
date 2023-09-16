using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;

namespace webapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GridCarController : ControllerBase
    {
        public GridCarController(ILogger<GridCarController> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<GridCarController> _logger;

        private static readonly GridCar[] cars = new GridCar[]
        {
            new GridCar { Make = "Toyota", Model = "Corolla", Price = 125000 },
            new GridCar {Make = "Ford", Model = "Fiesta", Price = 250000},
            new GridCar { Make = "Audi", Model = "Dolphin", Price = 380000}
        };

        [HttpGet(Name = "GetAllGridCars")]
        public IEnumerable<GridCar> Get()
        {
            return cars;
        }

    }
}
