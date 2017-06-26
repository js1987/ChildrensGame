using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrensGame.Model
{
    public interface IGameRepository
    {
        string Url { get; }
        Task<GameParameter> GetGameParameter();
        Task<GameResultPostResponse> SetGameResult(GameResult gameResult);
    }
}
