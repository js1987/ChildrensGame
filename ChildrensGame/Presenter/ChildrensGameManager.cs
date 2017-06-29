using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using ChildrensGame.Model;

namespace ChildrensGame.Presenter
{
    public class ChildrensGameManager: IChildrensGameManager
    {
        /// <summary>
        /// Calculates the game result.
        /// </summary>
        /// <param name="gameParameter">The game parameter.</param>
        /// <returns></returns>
        public async Task<GameResult> CalculateGameResult(GameParameter gameParameter)
        {
            var gameResult = new GameResult {Id = gameParameter.Id};
            try
            {
                const int start = 1;

                var eliminated = new int[gameParameter.ChildrenCount];
                var eliminateList = new ArrayList();
                var orderNum = 1;
                var remaining = (start - 1) % gameParameter.ChildrenCount;
                var countNumber = 0;
                var winner = 0;

                while (countNumber < gameParameter.ChildrenCount - 1)
                {
                    if (((orderNum % gameParameter.EliminateEach) | eliminated[remaining]) == 0)
                    {
                        eliminated[remaining] = 1;
                        eliminateList.Add(remaining + 1);
                        countNumber++;
                        orderNum++;
                    }
                    if (eliminated[remaining] != 1)
                        orderNum++;

                    remaining++;
                    remaining %= gameParameter.ChildrenCount;
                }
                for (var i = 0; i < gameParameter.ChildrenCount; i++)
                    if (eliminated[i] == 0)
                        winner = i + 1;

                gameResult.OrderOfElimination = eliminateList.Cast<int>().ToArray();
                gameResult.LastChild = winner;

                return gameResult;

            }
            catch (Exception)
            {
                return null;
            }

        }
    }

}
