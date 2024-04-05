using DapperPracticalExample.Models.Entities;
using Newtonsoft.Json;

namespace DapperPracticalExample.Models.DTO
{
    public class BookDTO
    {
        [JsonProperty("bookId")]
        public long BookId { get; set; }


        [JsonProperty("name")]
        public  string Name { get; set; }


        [JsonProperty("description")]
        public  string Description { get; set; }


        [JsonProperty("pageNumber")]
        public int PagesNumber { get; set; }


        [JsonProperty("author")]
        public AuthorDTO? Author { get; set; }

    }
}
