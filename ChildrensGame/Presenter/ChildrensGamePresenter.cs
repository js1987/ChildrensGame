using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildrensGame.Model;
using ChildrensGame.View;

namespace ChildrensGame.Presenter
{
    public class ChildrensGamePresenter
    {
        private readonly IChildrensGameView _gameView;
        private readonly IGameRepository _gameRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrensGamePresenter"/> class.
        /// </summary>
        /// <param name="gameView">The game view.</param>
        /// <param name="gameRepository">The game repository.</param>
        public ChildrensGamePresenter(IChildrensGameView gameView, IGameRepository gameRepository)
        {
            _gameView = gameView;
            _gameRepository = gameRepository;
            _gameView.NewGameButtonClicked += GameViewNewGameButtonClicked;
        }

        private async void GameViewNewGameButtonClicked(object sender, EventArgs e)
        {
            _gameView.ShowLoading();
            //Start a new game, load data  
            var gameParameter = await _gameRepository.GetGameParameter();
            if (gameParameter != null)
            {
                _gameView.SetNumberOfChildren(gameParameter.ChildrenCount);
                _gameView.SetEliminateEach(gameParameter.EliminateEach);
            }
            else
            {
                _gameView.ShowErrorMessage($@"Unable to get game parameter from {_gameRepository.Url}. Please check this Url is correct.");
                _gameView.HideLoading();
                return;
            }

            var gameManager = new ChildrensGameManager();
            //Calculate game result
            GameResult gameResult = null;
            gameResult = gameManager.CalculateGameResult(gameParameter);
            if (gameResult != null)
            {
                _gameView.SetWinningChildren(gameResult.LastChild.ToString());
            }
            else
            {
                _gameView.ShowErrorMessage($@"Unable to get game result from {_gameRepository.Url}. Please check this Url is correct.");
                _gameView.HideLoading();
                return;
            }

            string eliminateSeq = "";
            for (var i = 0; i < gameResult.OrderOfElimination.Length; i++)
            {
                eliminateSeq += gameResult.OrderOfElimination[i].ToString();
                eliminateSeq += i != gameResult.OrderOfElimination.Length - 1 ? ", " : "";
            }
            _gameView.SetChildrenEliminatedSequence(eliminateSeq);

            //Post game result
            if (Properties.Settings.Default.PostData)
            {
                GameResultPostResponse resultResponse = null;

                    resultResponse = await _gameRepository.SetGameResult(gameResult);
                    if (resultResponse != null)                    
                        _gameView.SetPostResult($@"{resultResponse.Id}, {resultResponse.Message}");                    
                    else
                        _gameView.ShowErrorMessage("Unable to post game result.");                
            }
            else            
                _gameView.SetPostResult("Post data is disabled");            

            _gameView.HideLoading();
        }
    }
}
