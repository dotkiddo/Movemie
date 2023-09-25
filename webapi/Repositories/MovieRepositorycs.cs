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

        public async Task<bool> ExistsAsync(string name)
        {
            var sql = "SELECT TOP 1 1 FROM Movies WHERE Name = @Name";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QuerySingleOrDefaultAsync<bool>(sql, new { Name = name });
                return result;
            }
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            var sql = "UPDATE Move SET Name = @Name, Category = @Category, Rating = @Rating where Id = @Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.ExecuteAsync(sql, new { Name = movie.Name, Category = movie.Category, Rating = movie.Rating, Id = movie.Id });

                return result == 1;                
            }
        }

        public async Task<bool> CreateAsync(Movie movie)
        {
            var sql = "INSERT INTO MOVIES (Name, Category, Rating) VALUES (@Name, @Category, @Rating)";

            using (var conn =  new SqlConnection(_connectionString))
            {
                try
                {
                    int result = await conn.ExecuteAsync(sql, new { Name = movie.Name, Category = movie.Category, Rating = movie.Rating });
                    return result == 1;
                }
                catch (Exception ex)
                { 
                    // we should log the error using ILogger<MovieRepository>
                    return false;
                }                
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Movies WHERE Id = @Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.ExecuteAsync(sql, new { Id = id });

                return result == 1;
            }
        }

        public async Task<IEnumerable<Movie>> ListAsync()
        {
            string sql = @"SELECT Id, Name, Category, Rating FROM Movies ";

            using (var conn = new SqlConnection(_connectionString))
            {
                var res = await conn.QueryAsync<Movie>(sql);
                return res;
            }
        }

        public async Task<IEnumerable<RatingCount>> ListRatingCountsAsync()
        {
            var sql = @"SELECT Rating, COUNT(Id) Count
                        FROM Movies
                        GROUP BY Rating";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<RatingCount>(sql);
                return result;
            }
        }

        public async Task<IEnumerable<Movie>> ListByRatingAsync(int rating)
        {
            string sql = @"SELECT Id, Name, Category, Rating
                           FROM Movies 
                           WHERE Rating = @Rating";

            using (var conn = new SqlConnection(_connectionString))
            {
                var res = await conn.QueryAsync<Movie>(sql, new { Rating = rating });
                return res;
            }
        }

    }
}
