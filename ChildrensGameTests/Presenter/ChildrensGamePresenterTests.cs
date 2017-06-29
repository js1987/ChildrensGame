using System;
using System.Threading.Tasks;
using ChildrensGame.Model;
using ChildrensGame.Presenter;
using ChildrensGame.Repository;
using ChildrensGame.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChildrensGameTests.Presenter
{
    [TestClass]
    public class ChildrensGamePresenterTests
    {
        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClicked_ShouldCallViewShowLoadingOnce()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockView.Setup(m => m.ShowLoading()).Verifiable();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.Verify(m => m.ShowLoading(), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClicked_ShouldCallRepositoryGetGameParameter()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockRepo.Setup(m => m.GetGameParameter()).Verifiable();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockRepo.Verify(m => m.GetGameParameter(), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameParameterIsNotNull_ShouldUpdateViewNumberOfChildren()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.VerifySet(m => m.NumberOfChildren = It.IsAny<decimal>(), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameParameterIsNotNull_ShouldUpdateViewEliminateEach()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();    
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.VerifySet(m => m.EliminateEach = It.IsAny<decimal>(), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameParameterIsNull_ShouldCallViewShowErrorMessage()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            mockView.Setup(m => m.ShowErrorMessage(It.IsAny<string>())).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult<GameParameter>(null));
            var mockGameManager = new Mock<IChildrensGameManager>();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.Verify(m => m.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameParameterIsNull_ShouldCallViewHideLoading()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockView.Setup(m => m.HideLoading()).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult<GameParameter>(null));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.Verify(m => m.HideLoading(), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClicked_ShouldCallRepositorySetGameResult()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockView.Setup(m => m.HideLoading()).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult(new GameResultPostResponse()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Verifiable();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockRepo.Verify(m => m.SetGameResult(It.IsAny<GameResult>()), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGamePostResponseIsNotNull_ShouldUpdateViewPostResult()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult(new GameResultPostResponse()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.VerifySet(m => m.PostResult = It.IsAny<string>(), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGamePostResponseIsNull_ShouldCallViewShowErrorMessage()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockView.Setup(m => m.ShowErrorMessage(It.IsAny<string>())).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult(new GameResultPostResponse()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.Verify(m => m.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameResultIsNotNull_ShouldUpdateViewWinner()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult(new GameResultPostResponse()));
            mockGameManager.Setup(m=>m.CalculateGameResult(It.IsAny<GameParameter>())).Returns(Task.FromResult(new GameResult()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.VerifySet(m => m.Winner = It.IsAny<string>(), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameResultIsNotNull_ShouldUpdateViewEliminatedSequence()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult(new GameResultPostResponse()));
            mockGameManager.Setup(m => m.CalculateGameResult(It.IsAny<GameParameter>())).Returns(Task.FromResult(new GameResult() {OrderOfElimination = new [] {1, 2, 3}}));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.VerifySet(m => m.EliminatedSequence = It.IsAny<string>(), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameResultIsNull_ShouldCallViewShowErrorMessage()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockView.Setup(m => m.ShowErrorMessage(It.IsAny<string>())).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter())); 
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult<GameResultPostResponse>(null));
            mockGameManager.Setup(m => m.CalculateGameResult(It.IsAny<GameParameter>())).Returns(Task.FromResult(new GameResult() { OrderOfElimination = new [] { 1, 2, 3 } }));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.Verify(m => m.ShowErrorMessage(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameResultIsNull_ShouldCallHideLoading()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockView.Setup(m => m.HideLoading()).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult<GameResultPostResponse>(null));
            mockGameManager.Setup(m => m.CalculateGameResult(It.IsAny<GameParameter>())).Returns(Task.FromResult(new GameResult() { OrderOfElimination = new [] { 1, 2, 3 } }));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.Verify(m => m.HideLoading(), Times.Once);
        }


        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClicked_ShouldCallHideLoading()
        {
            //Arrange
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();
            var mockGameManager = new Mock<IChildrensGameManager>();
            mockView.Setup(m => m.HideLoading()).Verifiable();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object, mockGameManager.Object);

            //Act
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);

            //Assert
            mockView.Verify(m => m.HideLoading(), Times.Once);
        }
    }
}
