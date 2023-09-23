using Dapper;
using Microsoft.Data.SqlClient;
using webapi.DTOs;

namespace webapi.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(IConfiguration conf) : base(conf)
        {

        }

        private static readonly Category[] cats = new Category[]
        {
            new Category { Id = 1, Name = "Drama" },
            new Category { Id = 2, Name = "Animation" },
            new Category { Id = 3, Name = "Comedy" }
        };

        public async Task<IEnumerable<Category>> ListAsync()
        {
            //string sql = @"SELECT Id, Name FROM Categories";

            //using (var conn = new SqlConnection(_connectionString))
            //{
            //    var res = await conn.QueryAsync<Category>(sql);
            //    return res;
            //}

            return cats;
        }

        public async Task<Category> GetAsync(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) ;//

            var sql = "SELECT TOP 1 * FROM Categories WHERE Name = @name";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QuerySingleOrDefaultAsync<Category>(sql, new { name });

                return result;
            }
        }

        public async Task<int> CreateAsync(Category category)
        {
//#error check if it exists first!
            if (category == null) throw new Exception();

            var sql = "INSERT INTO Category (Name) VALUES (@name)";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.QuerySingleAsync<int>(sql, new { category.Name });

                //#error
                // but this does not return the id!
                return result;
            }
        }

        // how the hell are you going to update it??
        public async Task<bool> UpdateAsync(Category category)
        {


            var sql = "UPDATE Category SET Name = @Name WHERE Id = @Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                var result = await conn.ExecuteAsync(sql, new { Name = category.Name, Id = category.Id });

                return result == 1;
            }

        }
    }
}
