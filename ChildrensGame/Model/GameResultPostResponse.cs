using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
