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
                var playerList = new int[gameParameter.ChildrenCount];
                var eliminateList = new ArrayList();
                var roundNumber = 1;
                var startingIndex = 0;
                var eliminatedCounter = 0;
                var winner = 0;

                // Continue eliminating untile 1 player left
                while (eliminatedCounter < gameParameter.ChildrenCount - 1)
                {
                    if (((roundNumber % gameParameter.EliminateEach) | playerList[startingIndex]) == 0)
                    {
                        playerList[startingIndex] = 1;
                        eliminateList.Add(startingIndex + 1);
                        eliminatedCounter++;
                        roundNumber++;
                    }
                    if (playerList[startingIndex] != 1)
                        roundNumber++;

                    startingIndex++;
                    startingIndex %= gameParameter.ChildrenCount;
                }

                for (var i = 0; i < gameParameter.ChildrenCount; i++)
                    if (playerList[i] == 0)
                        winner = i + 1;

                gameResult.OrderOfElimination = eliminateList.Cast<int>().ToArray();
                gameResult.LastChild = winner;

                return await Task.FromResult(gameResult);

            }
            catch (Exception)
            {
                return null;
            }

        }
    }

}
