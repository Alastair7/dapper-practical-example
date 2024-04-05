using DapperPracticalExample.Models.Entities;
using Newtonsoft.Json;

namespace DapperPracticalExample.Models.DTO
{
    public class ItemDTO
    {
        [JsonProperty("itemId")]
        public long Itemid { get; set; }

        [JsonProperty("name")]
        public  string Name { get; set; }

        [JsonProperty("description")]
        public  string Description { get; set; }

    }
}
