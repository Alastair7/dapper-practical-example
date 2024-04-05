using Newtonsoft.Json;

namespace DapperPracticalExample.Models.DTO
{
    public class AuthorDTO
    {
        [JsonProperty("authorId")]
        public long AuthorId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
