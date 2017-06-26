using Newtonsoft.Json;

namespace ChildrensGame.Model
{
    public class GameParameter
    {        
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("children_count")]
        public int ChildrenCount { get; set; }
        [JsonProperty("eliminate_each")]
        public int EliminateEach { get; set; }

    }
}
