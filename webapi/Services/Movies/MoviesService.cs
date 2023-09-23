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

        public Task<IEnumerable<MovieDto>> ListAsync()
        {
            return _moviesRepo.ListAsync();
        }

        public Task<IEnumerable<MovieDto>> ListByRatingAsync(int rating)
        {
            return _moviesRepo.ListByRatingAsync(rating);
        }

        public Task<IEnumerable<RatingCount>> ListRatingCountsAsync()
        {
            return _moviesRepo.ListRatingCountsAsync();
        }

        public Task<int> CreateAsync(Movie movie)
        {
            //if (String.IsNullOrWhiteSpace(movie.Name)) return; // something
            //if (await _moviesRepo.ExistsAsync(movie.Name)) return; //something;

            // here you go an search if the ting already exists or not.
            // repository should not be doing the logic.

            return _moviesRepo.CreateAsync(movie);
        }

        public Task<bool> UpdateAsync(Movie movie)
        {
           // if (movie.Id == default) throw new exception??; // something

            return _moviesRepo.UpdateAsync(movie);
        }

        public Task<bool> ExistsAsync(string name)
        {
           // if (String.IsNullOrWhiteSpace(movie.Name)) throw new Exception(); // something

            return _moviesRepo.ExistsAsync(name);
        }
    }
}

// what else?? -> 
/**
 * 
 * create's movie
 * filters
 * 
 * the grouping = ratings & count of movies with that rating
 * 
 * finally - the report:  category*rating -> avg rating.
 *                                           total movies within that category
 *                                           
 * bonus = movies with that rating.
 * 
 */
