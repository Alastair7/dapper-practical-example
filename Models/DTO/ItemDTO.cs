using DapperPracticalExample.Models.Entities;
using Newtonsoft.Json;

namespace DapperPracticalExample.Models.DTO
{
    public class ItemDTO
    {
        [JsonProperty("itemId")]
        public long Itemid { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("description")]
        public required string Description { get; set; }

    }
}
