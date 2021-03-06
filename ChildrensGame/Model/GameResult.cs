﻿using Newtonsoft.Json;

namespace ChildrensGame.Model
{
    public class GameResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("last_child")]
        public int LastChild { get; set; }
        [JsonProperty("order_of_elimination")]
        public int[] OrderOfElimination { get; set; }
    }
}
