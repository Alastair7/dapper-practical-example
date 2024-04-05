using DapperPracticalExample.Models.Entities;
using Newtonsoft.Json;

namespace DapperPracticalExample.Models.DTO
{
    public class PersonDTO
    {
        [JsonProperty("personId")]
        public long PersonId { get; set; }

        [JsonProperty("firstName")]
        public  string FirstName { get; set; }

        [JsonProperty("lastName")]
        public  string LastName { get; set; }

        [JsonProperty("books")]
        public ICollection<BookDTO>? Books { get; set; }

        [JsonProperty("items")]
        public ICollection<ItemDTO>? Items { get; set; }
    }
}
