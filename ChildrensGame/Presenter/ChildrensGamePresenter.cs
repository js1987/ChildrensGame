using System;
using ChildrensGame.Repository;
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

        public async void GameViewNewGameButtonClicked(object sender, EventArgs e)
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
                _gameView.ShowErrorMessage($@"Unable to get game parameter from {_gameRepository.Url}. Please check the internet connection and if this Url is correct.");
                _gameView.HideLoading();
                return;
            }

            //Calculate game result
            var gameManager = new ChildrensGameManager();
            var gameResult = gameManager.CalculateGameResult(gameParameter); 
            if (gameResult != null)
            {
                //Display winning
                _gameView.SetWinningChildren(gameResult.LastChild.ToString());

                //Display eliminated list
                string eliminateSeq = "";
                for (var i = 0; i < gameResult.OrderOfElimination.Length; i++)
                {
                    eliminateSeq += gameResult.OrderOfElimination[i].ToString();
                    eliminateSeq += i != gameResult.OrderOfElimination.Length - 1 ? ", " : "";
                }
                _gameView.SetChildrenEliminatedSequence(eliminateSeq);
            }
            else
            {
                _gameView.ShowErrorMessage($@"Unable to get game result from {_gameRepository.Url}. Please check this Url is correct.");
                _gameView.HideLoading();
            }

            //Post game result
            if (Properties.Settings.Default.PostData)
            {
                var resultResponse = await _gameRepository.SetGameResult(gameResult);
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
