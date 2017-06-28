using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using ChildrensGame.Model;
using ChildrensGame.Repository;

namespace ChildrensGame.Presenter
{
    public class ChildrensGameManager
    {
        /// <summary>
        /// Calculates the game result.
        /// </summary>
        /// <param name="gameParameter">The game parameter.</param>
        /// <returns></returns>
        public GameResult CalculateGameResult(GameParameter gameParameter)
        {
            var gameResult = new GameResult();
            gameResult.Id = gameParameter.Id;
            try
            {
                const int start = 1;

                var eliminated = new int[gameParameter.ChildrenCount];
                var eliminateList = new ArrayList();
                var orderNum = 1;
                var suffix = (start - 1) % gameParameter.ChildrenCount;
                var countNumber = 0;
                var winner = 0;

                while (countNumber < gameParameter.ChildrenCount - 1)
                {
                    if (((orderNum % gameParameter.EliminateEach) | (eliminated[suffix])) == 0)
                    {
                        eliminated[suffix] = 1;
                        eliminateList.Add(suffix + 1);
                        countNumber++;
                        orderNum++;
                    }
                    if (eliminated[suffix] != 1)
                        orderNum++;

                    suffix++;
                    suffix %= gameParameter.ChildrenCount;
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
