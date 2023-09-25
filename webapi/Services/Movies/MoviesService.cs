using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Services.Movies
{
    public class MoviesService : IMoviesService
    {
        private readonly IMovieRepository _moviesRepo;

        public MoviesService(IMovieRepository movies)
        {
            _moviesRepo = movies;
        }

        public Task<IEnumerable<Movie>> ListAsync()
        {
            return _moviesRepo.ListAsync();
        }

        public Task<IEnumerable<Movie>> ListByRatingAsync(int rating)
        {
            return _moviesRepo.ListByRatingAsync(rating);
        }

        public Task<IEnumerable<RatingCount>> ListRatingCountsAsync()
        {
            return _moviesRepo.ListRatingCountsAsync();
        }

        public Task<bool> CreateAsync(Movie movie)
        {
            return _moviesRepo.CreateAsync(movie);
        }

        public Task<bool> UpdateAsync(Movie movie)
        {
            return _moviesRepo.UpdateAsync(movie);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _moviesRepo.DeleteAsync(id);
        }

        public Task<bool> ExistsAsync(string movie)
        {
            return _moviesRepo.ExistsAsync(movie);
        }
    }
}

/**
 * 
 * finally - the report:  category*rating -> avg rating.
 *                                           total movies within that category
 *                                           
 * bonus = movies with that rating.
 * 
 */
