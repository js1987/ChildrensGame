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
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.ShowLoading()).Verifiable();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockView.Verify(m=>m.ShowLoading());
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClicked_ShouldCallRepositoryGetGameParameter()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockRepo.Setup(m => m.GetGameParameter()).Verifiable();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockRepo.Verify(m => m.GetGameParameter());
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameParameterIsNotNull_ShouldCallViewSetNumberOfChildren()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.SetNumberOfChildren(It.IsAny<decimal>())).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockView.Verify(m => m.SetNumberOfChildren(It.IsAny<decimal>()));
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameParameterIsNotNull_ShouldCallViewSetEliminateEach()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.SetEliminateEach(It.IsAny<decimal>())).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockView.Verify(m => m.SetEliminateEach(It.IsAny<decimal>()));
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameParameterIsNull_ShouldCallViewShowErrorMessage()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.ShowErrorMessage(It.IsAny<string>())).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult<GameParameter>(null));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockView.Verify(m => m.ShowErrorMessage(It.IsAny<string>()));
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGameParameterIsNull_ShouldCallViewHideLoading()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.HideLoading()).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult<GameParameter>(null));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockView.Verify(m => m.HideLoading());
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClicked_ShouldCallRepositorySetGameResult()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.HideLoading()).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult(new GameResultPostResponse()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Verifiable();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockRepo.Verify(m => m.SetGameResult(It.IsAny<GameResult>()));
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGamePostResponseIsNotNull_ShouldCallViewSetPostResult()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.SetPostResult(It.IsAny<string>())).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult(new GameResultPostResponse()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockView.Verify(m => m.SetPostResult(It.IsAny<string>()));
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClickedAndGamePostResponseIsNull_ShouldCallViewShowErrorMessage()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.ShowErrorMessage(It.IsAny<string>())).Verifiable();
            mockRepo.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter()));
            mockRepo.Setup(m => m.SetGameResult(It.IsAny<GameResult>())).Returns(Task.FromResult(new GameResultPostResponse()));
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockView.Verify(m => m.ShowErrorMessage(It.IsAny<string>()));
        }

        [TestMethod]
        public void GameViewNewGameButtonClicked_WhenButtonClicked_ShouldCallHideLoading()
        {
            var mockView = new Mock<IChildrensGameView>();
            var mockRepo = new Mock<IGameRepository>();

            mockView.Setup(m => m.HideLoading()).Verifiable();
            var presenter = new ChildrensGamePresenter(mockView.Object, mockRepo.Object);
            presenter.GameViewNewGameButtonClicked(mockView.Object, EventArgs.Empty);
            mockView.Verify(m => m.HideLoading());
        }
    }
}
