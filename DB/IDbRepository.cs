using DapperPracticalExample.Models.Entities;

namespace DapperPracticalExample.DB
{
    public interface IDbRepository
    {
        Task<IEnumerable<AuthorEntity>> GetAuthors();

        Task<AuthorEntity> GetAuthor(long authorId);

        Task<IEnumerable<PersonEntity>> GetPersons();
        
    }
}
