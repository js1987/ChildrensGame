using System;
using ChildrensGame.Repository;
using ChildrensGame.View;

namespace ChildrensGame.Presenter
{
    public class ChildrensGamePresenter
    {
        private readonly IChildrensGameView _gameView;
        private readonly IGameRepository _gameRepository;
        private readonly IChildrensGameManager _gameManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrensGamePresenter"/> class.
        /// </summary>
        /// <param name="gameView">The game view.</param>
        /// <param name="gameRepository">The game repository.</param>
        /// <param name="gameManager">The game manager.</param>
        public ChildrensGamePresenter(IChildrensGameView gameView, IGameRepository gameRepository, IChildrensGameManager gameManager)
        {
            _gameView = gameView;
            _gameRepository = gameRepository;
            _gameManager = gameManager;
            _gameView.NewGameButtonClicked += GameViewNewGameButtonClicked;
        }

        public async void GameViewNewGameButtonClicked(object sender, EventArgs e)
        {
            _gameView.ShowLoading();

            //Start a new game, load data  
            var gameParameter = await _gameRepository.GetGameParameter();
            if (gameParameter != null)
            {
                _gameView.NumberOfChildren = gameParameter.ChildrenCount;
                _gameView.EliminateEach = gameParameter.EliminateEach;
            }
            else
            {
                _gameView.ShowErrorMessage($@"Unable to get game parameter from {_gameRepository.Url}. Please check the internet connection and if this Url is correct.");
                _gameView.HideLoading();
                return;
            }

            //Calculate game result
            var gameResult = await _gameManager.CalculateGameResult(gameParameter);
            if (gameResult != null)
            {
                //Display winning
                _gameView.Winner = gameResult.LastChild.ToString();

                //Display eliminated list
                var eliminateSeq = "";
                for (var i = 0; i < gameResult.OrderOfElimination.Length; i++)
                {
                    eliminateSeq += gameResult.OrderOfElimination[i].ToString();
                    eliminateSeq += i != gameResult.OrderOfElimination.Length - 1 ? ", " : "";
                }
                _gameView.EliminatedSequence = eliminateSeq;
            }
            else
            {
                _gameView.ShowErrorMessage($@"Sorry, we are unable to calculate the result for {gameParameter.ChildrenCount} children and eliminate every {gameParameter.EliminateEach}");
                _gameView.HideLoading();
            }

            //Post game result
            var resultResponse = await _gameRepository.SetGameResult(gameResult);
            if (resultResponse != null)
                _gameView.PostResult = $@"{resultResponse.Id}, {resultResponse.Message}";
            else
                _gameView.ShowErrorMessage("Unable to post game result.");

            _gameView.HideLoading();
        }
    }
}
