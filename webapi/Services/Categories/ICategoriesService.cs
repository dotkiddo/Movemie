using webapi.DTOs;

namespace webapi.Services.Categories
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<Category>> ListAsync();
    }
}
