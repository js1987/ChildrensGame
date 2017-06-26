using Newtonsoft.Json;

namespace ChildrensGame.Model
{
    public class GameResultPostResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
