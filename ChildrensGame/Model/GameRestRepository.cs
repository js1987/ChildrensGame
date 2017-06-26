using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChildrensGame.Model
{
    public class GameRestRepository : IGameRepository
    {
        private readonly string _url;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRestRepository"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public GameRestRepository(string url)
        {
            _url = url;
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get{ return _url;}}

        /// <summary>
        /// Gets the game parameter.
        /// </summary>
        /// <returns></returns>
        public async Task<GameParameter> GetGameParameter()
        {            
            GameParameter gameParameter = null;
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(_url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (var content = response.Content)
                            {
                                var data = JsonConvert.DeserializeObject<GameParameter>(await content.ReadAsStringAsync());
                                gameParameter = data;
                            }
                        }                                                
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return gameParameter;
        }

        /// <summary>
        /// Sets the game result.
        /// </summary>
        /// <param name="gameResult">The game result.</param>
        /// <returns></returns>
        public async Task<GameResultPostResponse> SetGameResult(GameResult gameResult)
        {
            GameResultPostResponse postResponse = null;

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(gameResult), Encoding.UTF8, "application/json");
                    // HTTP POST
                    var response = await client.PostAsync($@"{_url}/{gameResult.Id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = JsonConvert.DeserializeObject<GameResultPostResponse>(await response.Content.ReadAsStringAsync());
                        postResponse = data;
                    }
                }
                return postResponse;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }


}
