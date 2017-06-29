using System.Threading.Tasks;
using ChildrensGame.Model;

namespace ChildrensGame.Presenter
{
    public interface IChildrensGameManager
    {
        Task<GameResult> CalculateGameResult(GameParameter gameParameter);
    }
}
