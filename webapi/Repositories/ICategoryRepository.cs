using webapi.DTOs;

namespace webapi.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> ListAsync();
    }
}
