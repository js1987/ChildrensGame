using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildrensGame.Model;

namespace ChildrensGame.Presenter
{
    public interface IChildrensGameManager
    {
        Task<GameResult> CalculateGameResult(GameParameter gameParameter);
    }
}
