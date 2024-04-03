namespace DapperPracticalExample.Models.Entities
{
    public class ItemEntity
    {
        public long Itemid { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        // Relationships

        // Multiple items can be owned by a person
        public PersonEntity? Person { get; set; }
    }
}
