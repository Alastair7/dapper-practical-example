namespace DapperPracticalExample.Models.Entities
{
    public class BookEntity
    {
        public long BookId { get; set; }
        public  string Name { get; set; }

        public  string Description { get; set; }

        public int PagesNumber { get; set; }

        // Relationships
        // A book can have one author (1 - 1)
        public AuthorEntity? Author { get; set; }
    }
}
