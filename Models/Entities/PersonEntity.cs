namespace DapperPracticalExample.Models.Entities
{
    public class PersonEntity
    {
        public long PersonId { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}
