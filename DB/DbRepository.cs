using Dapper;
using DapperPracticalExample.Models.Entities;
using System.Data;
using System.Data.SqlClient;

namespace DapperPracticalExample.DB
{
    public class DbRepository : IDbRepository
    {
        private readonly string connectionString;
        public DbRepository() 
        {
            connectionString = "Server=localhost\\SQLEXPRESS;" +
                "Database=master;" +
                "Trusted_Connection=True;";
        }

        public async Task<AuthorEntity> GetAuthor(long authorId)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<AuthorEntity>> GetAuthors()
        {
            IEnumerable<AuthorEntity> result = Enumerable.Empty<AuthorEntity>();
            return await Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();

                }
                var sql = "SELECT * FROM [dapperdev].[dbo].[authors]";
                result = connection.Query<AuthorEntity>(sql);
                return result;
            });
        }
    }
}
