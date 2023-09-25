using webapi.DTOs;
using webapi.Models;

namespace webapi.Services.Movies
{
    public interface IMoviesService
    {
        public Task<IEnumerable<Movie>> ListAsync();

        public Task<bool> CreateAsync(Movie movie);

        public Task<bool> ExistsAsync(string movie);

        public Task<bool> UpdateAsync(Movie movie);

        public Task<bool> DeleteAsync(int id);


        public Task<IEnumerable<RatingCount>> ListRatingCountsAsync();
    }
}
