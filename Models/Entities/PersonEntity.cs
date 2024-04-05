namespace DapperPracticalExample.Models.Entities
{
    public class PersonEntity
    {
        public long PersonId { get; set; }
        public  string FirstName { get; set; }

        public  string LastName { get; set; }

        // Relationships

        // A person can own multiple books (1 - N)
        public ICollection<BookEntity>? Books { get; set; }

        // A person can own multiple items (1 - N)
        public ICollection<ItemEntity>? Items { get; set; }
    }
}
