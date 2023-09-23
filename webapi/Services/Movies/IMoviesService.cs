using webapi.DTOs;
using webapi.Models;

namespace webapi.Services.Movies
{
    public interface IMoviesService
    {
        public Task<IEnumerable<MovieDto>> ListAsync();

        public Task<int> CreateAsync(Movie movie);

        public Task<bool> ExistsAsync(string name);

        public Task<bool> UpdateAsync(Movie movie);

        public Task<IEnumerable<RatingCount>> ListRatingCountsAsync();
    }
}
