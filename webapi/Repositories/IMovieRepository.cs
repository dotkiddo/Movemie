using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<MovieDto>> ListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Id of the newly created movie</returns>
        public Task<int> CreateAsync(Movie movie);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Success indicator</returns>
        public Task<bool> UpdateAsync(Movie movie);

        public Task<IEnumerable<RatingCount>> ListRatingCountsAsync();

        public Task<IEnumerable<MovieDto>> ListByRatingAsync(int rating);

        public Task<bool> ExistsAsync(string name);
    }
}
