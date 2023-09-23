using webapi.DTOs;
using webapi.Repositories;

namespace webapi.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository _categoriesRepo;
        
        public CategoriesService(ICategoryRepository categories)
        {
            _categoriesRepo = categories;
        }

        public Task<IEnumerable<Category>> ListAsync()
        {
            return _categoriesRepo.ListAsync();
        }
    }
}
