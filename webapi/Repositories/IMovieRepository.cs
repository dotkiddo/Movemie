using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> ListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Id of the newly created movie</returns>
        public Task<bool> CreateAsync(Movie movie);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Success indicator</returns>
        public Task<bool> UpdateAsync(Movie movie);

        public Task<bool> DeleteAsync(int id);


        public Task<IEnumerable<RatingCount>> ListRatingCountsAsync();

        public Task<IEnumerable<Movie>> ListByRatingAsync(int rating);

        public Task<bool> ExistsAsync(string name);
    }
}
