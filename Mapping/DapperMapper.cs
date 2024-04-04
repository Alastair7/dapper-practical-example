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

        public static BookDTO BookEntityToBookDTO(BookEntity book) 
        {
            AuthorDTO authorDto = null;

            if (book.Author != null) 
            {
                authorDto = AuthorEntityToAuthorDTO(book.Author);
            }

            return new BookDTO()
            {
                BookId = book.BookId,
                Name = book.Name,
                Description = book.Description,
                PagesNumber = book.PagesNumber,
                Author = authorDto
            };
        }

        public static ItemDTO ItemEntityToItemDTO(ItemEntity item) 
        {
            return new ItemDTO() 
            {
                Itemid = item.Itemid,
                Name = item.Name,
                Description = item.Description,
            };
        }

        public static PersonDTO PersonEntityToPersonDTO(PersonEntity person) 
        {
            var booksDto = person.Books.Select(BookEntityToBookDTO)
                .ToList();

            var itemsDto = person.Items.Select(ItemEntityToItemDTO)
                .ToList();

            return new PersonDTO()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Books = booksDto,
                Items = itemsDto,
            };
        }

        public static AuthorEntity AuthorDTOToAuthorEntity(AuthorDTO author) 
        {
            return new AuthorEntity()
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
            };
        }
    }
}
