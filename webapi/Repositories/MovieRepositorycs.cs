using Dapper;
using Microsoft.Data.SqlClient;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Repositories
{
    public class MovieRepository : RepositoryBase, IMovieRepository
    {
        public MovieRepository(IConfiguration conf) : base(conf)
        {
                
        }

        private static readonly MovieDto[] mvs = new MovieDto[]
        {
            new MovieDto { Id = 1, Name = "Atonement", Category = "Drama", Rating = 5 },
            new MovieDto { Id = 2, Name = "Elemental", Category = "Animation", Rating = 4 },
            new MovieDto { Id = 3, Name = "Up", Category = "Animation", Rating = 3 }
        };

        public async Task GetAsync()
        {

        }

        public async Task<bool> ExistsAsync(string name)
        {
           // if (String.IsNullOrWhiteSpace(name)) ; // throw err?

            var sql = "SELECT TOP 1 1 FROM Movies WHERE Name = @Name";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QuerySingleOrDefaultAsync<bool>(sql, new { Name = name });
                return result;
            }
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            //if (!await ExistsAsync(movie.Name)) return; //something;

            var sql = "UPDATE Move SET Name = @Name, CategoryId = @CategoryId, Rating = @Rating where Id = @Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.ExecuteAsync(sql, new { Name = movie.Name, CategoryId = movie.CategoryId, Rating = movie.Rating, Id = movie.Id });

                return result == 1;                
            }
        }

        public async Task<int> CreateAsync(Movie movie)
        {
            var sql = "INSERT INTO MOVIES (Name, CategoryId, Rating) VALUES (@Name, @CategoryId, @Rating)";

            using (var conn =  new SqlConnection(_connectionString))
            {
                try
                {
                    var result = await conn.QuerySingleAsync<int>(sql, new { Name = movie.Name, CategoryId = movie.CategoryId, Rating = movie.Rating });
#warning no idea what it returns if it fails
                    //if ()
                    //if (result != 1) return // fail.
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }                
            }
        }

        public async Task<IEnumerable<MovieDto>> ListAsync()
        {
            string sql = @"SELECT M.Id, M.Name, C.Name Category, M.Rating
                           FROM Movies M 
                           INNER JOIN Categories C ON M.CategoryId = C.Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                var res = await conn.QueryAsync<MovieDto>(sql);
                return res;
            }

            //return mvs;
        }

        public async Task<IEnumerable<RatingCount>> ListRatingCountsAsync()
        {
            var sql = @"SELECT Rating, COUNT(Id)
                        FROM Movies
                        GROUP BY Rating";

#warning how will you make it return a 0 count for an existent rating?

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<RatingCount>(sql);
                return result;
            }
        }

        public async Task<IEnumerable<MovieDto>> ListByRatingAsync(int rating)
        {
            string sql = @"SELECT M.Id, M.Name, C.Name, M.Rating
                           FROM Movies M 
                           INNER JOIN Categories C ON M.CategoryId = C.Id
                           WHERE M.Rating = @rating";

            using (var conn = new SqlConnection(_connectionString))
            {
                var res = await conn.QueryAsync<MovieDto>(sql, new { rating });
                return res;
            }
        }

    }
}
