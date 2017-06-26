using System.Threading.Tasks;
using ChildrensGame.Model;

namespace ChildrensGame.Repository
{
    public interface IGameRepository
    {
        string Url { get; }
        Task<GameParameter> GetGameParameter();
        Task<GameResultPostResponse> SetGameResult(GameResult gameResult);
    }
}
