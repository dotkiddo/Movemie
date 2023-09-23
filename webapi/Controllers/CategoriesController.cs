using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Services.Categories;

namespace webapi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoriesService _categories;
        
        public CategoriesController(
            ILogger<CategoriesController> logger,
            ICategoriesService categories
            )
        {
            _logger = logger;
            _categories = categories;
        }

        [HttpGet(Name = "ListCategories")]
        public async Task<IEnumerable<Category>> List()
        {
            return await _categories.ListAsync();
        }

    }
}
