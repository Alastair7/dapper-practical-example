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
            AuthorEntity result;

            return await Task.Run(() =>
            {
                using SqlConnection connection = new (connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var sql = @"SELECT * FROM [dapperdev].[dbo].[authors] WHERE 
                            authorId = @authorId";

                result = connection
                .QueryFirst<AuthorEntity>(sql, new { authorId });

                return result;
            });
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

        public async Task<IEnumerable<PersonEntity>> GetPersons() 
        {
            IEnumerable<PersonEntity> result = new List<PersonEntity>();

            return await Task.Run(() =>
            {
                using SqlConnection connection = new (connectionString);

                if (connection.State != ConnectionState.Open) 
                {
                    connection.Open();
                }

                var sql = @"SELECT * 
                            FROM [dapperdev].[dbo].[persons] p
                            LEFT JOIN [dapperdev].[dbo].[books] b 
                            ON p.PersonId = b.PersonId
                            LEFT JOIN [dapperdev].[dbo].[authors] a 
                            ON b.IdAuthor = a.AuthorId 
                            LEFT JOIN [dapperdev].[dbo].[items] i 
                            ON p.PersonId = i.PersonId";

                Dictionary<long, PersonEntity> personDictionary = new ();
                /*
                 * Dapper will map Person, Book, Author and Item 
                 * to PersonEntity.
                 * The last object represents the mapping destination.
                 */
                result = connection.Query<PersonEntity, BookEntity, 
                    AuthorEntity, ItemEntity, PersonEntity>(sql, 
                    (person, book, author, item) => 
                    {
                        /*
                         * Dapper will move through each row.
                         * Even if it's duplicated.
                         */

                        if (!personDictionary.TryGetValue(person.PersonId,
                            out PersonEntity existentPerson)) 
                        {
                            existentPerson = person;
                            person.Items ??= new List<ItemEntity>();
                            person.Books ??= new List<BookEntity>();

                            personDictionary.Add(existentPerson.PersonId, 
                                existentPerson);
                        }

                        
                        if (book != null &&
                        !existentPerson.Books.Any(b => b.BookId == book.BookId)) 
                        {

                            if (author != null) 
                            {
                                book.Author = author;
                            }

                            existentPerson.Books.Add(book);
                        }

                        if (item != null && 
                        !existentPerson.Items.Any(i => i.Itemid == item.Itemid))
                        {
                            existentPerson.Items.Add(item);
                        }


                        return existentPerson;
                    },splitOn:"BookId,AuthorId,ItemId");

                result = personDictionary.Values;


                return result;
            });
        }

        public async Task<long> InsertAuthor(AuthorEntity author)
        {
            long result = 0;

            return await Task.Run(() => 
            {
                using SqlConnection connection = new (connectionString);

                if (connection.State != ConnectionState.Open) 
                {
                    connection.Open();
                }

                var sql = @"INSERT INTO [dapperdev].[dbo].[authors] (Name) 
                            VALUES (@Name)";

                var transaction = connection.BeginTransaction();

                try 
                {
                    result = connection.Execute(sql, author, transaction);
                    transaction.Commit();
                } catch (Exception) 
                {
                    transaction.Rollback();
                }

                return result;
            });
        }
        public async Task<long> DeleteAuthor(long authorId)
        {
            long result = 0;

            return await Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var sql = @"DELETE FROM [dapperdev].[dbo].[authors] WHERE 
                            AuthorId = @authorId";

                var transaction = connection.BeginTransaction();

                try
                {
                    result = connection.Execute(sql, new { authorId },
                        transaction);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

                return result;
            });
         }

        public async Task<long> UpdateAuthor(AuthorEntity author)
        {
            long result = 0;

            return await Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var sql = @"UPDATE [dapperdev].[dbo].[authors]
                            SET NAME = @Name WHERE AuthorId = @AuthorId";

                var transaction = connection.BeginTransaction();

                try
                {
                    result = connection.Execute(sql, author, transaction);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

                return result;
            });
        }
    }
}
