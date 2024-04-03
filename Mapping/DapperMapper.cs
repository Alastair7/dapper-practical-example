using DapperPracticalExample.Models.DTO;
using DapperPracticalExample.Models.Entities;

namespace DapperPracticalExample.Mapping
{
    public static class DapperMapper
    {
        public static AuthorDTO AuthorEntityToAuthorDTO(AuthorEntity author) 
        {
            return new AuthorDTO()
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
            };
        }
    }
}
