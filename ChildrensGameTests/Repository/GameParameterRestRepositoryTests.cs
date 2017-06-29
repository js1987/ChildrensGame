using System;
using ChildrensGame.Model;
using ChildrensGame.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChildrensGameTests.Repository
{
    [TestClass]
    public class GameParameterRestRepositoryTests
    {
        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/game")]
        public void GameRestRepository_WhenConstructorIsCalled_ShouldSetUrl(String url)
        {
            //Arrange & Act
            var repository = new GameRestRepository(url);

            Assert.AreEqual(repository.Url, url);
        }

        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/game")]
        public void GetGameParameter_ValidAddress_ShouldReturnNotNull(string url)
        {
            //Arrange
            var repository = new GameRestRepository(url);

            //Act
            var gameParameter = repository.GetGameParameter();

            //Assert
            Assert.IsNotNull(gameParameter);
        }

        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/gam")]
        public void GetGameParameter_InvalidAddress_ShouldReturnNull(string url)
        {

            //Arrange
            var repository = new GameRestRepository(url);

            //Act
            var gameParameter = repository.GetGameParameter();

            //Assert
            Assert.IsNull(gameParameter.Result);         
        }

        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/game", 81380, 3, new [] { 1, 2 })]
        public void SetGameResult_ValidResult_ShouldReturnSavedMessage(string url, int id, int lastChild, int[] orderOfElimination)
        {
            //Arrange
            var repository = new GameRestRepository(url);
            var gameResult = new GameResult()
            {
                Id = id,
                LastChild = lastChild,
                OrderOfElimination = orderOfElimination
            };

            //Act
            var postResponse = repository.SetGameResult(gameResult);

            //Assert
            Assert.IsTrue(postResponse.Result.Id == gameResult.Id);            
            Assert.IsTrue(postResponse.Result.Message.Equals("game results were saved", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/gam", 81380, 3, new [] { 1, 2 })]
        public void SetGameResult_InvalidUrl_ShouldReturnNull(string url, int id, int lastChild, int[] orderOfElimination)
        {
            //Arrange
            var repository = new GameRestRepository(url);
            var gameResult = new GameResult()
            {
                Id = id,
                LastChild = lastChild,
                OrderOfElimination = orderOfElimination
            };

            //Act
            var postResponse = repository.SetGameResult(gameResult);

            //Assert
            Assert.IsNull(postResponse.Result);            
        }

    }
}
