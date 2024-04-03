namespace DapperPracticalExample.Models.Entities
{
    public class BookEntity
    {
        public long BookId { get; set; }
        public required string Name { get; set; }

        public required string Description { get; set; }

        public int PageNumber { get; set; }

        // Relationships
        // A book can have one or more authors (1 - N)
        public ICollection<AuthorEntity>? Authors { get; set; }

        // Multiple books can be owned by a person (1 - N)
        public PersonEntity? Person { get; set; }
    }
}
