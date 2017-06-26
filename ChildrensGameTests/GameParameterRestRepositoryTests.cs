using System;
using System.Text;
using System.Collections.Generic;
using ChildrensGame.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChildrensGameTests
{
    /// <summary>
    /// Summary description for GameParameterRestRepositoryTests
    /// </summary>
    [TestClass]
    public class GameParameterRestRepositoryTests
    {
        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/game")]
        public void GetGameParameter_ValidAddress_ShouldReturnNotNull(string url)
        {
            var repository = new GameRestRepository(url);
            var gameParameter = repository.GetGameParameter();
            Assert.IsNotNull(gameParameter);
        }

        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/gam")]
        public void GetGameParameter_InvalidAddress_ShouldReturnNull(string url)
        {
            var repository = new GameRestRepository(url);
            var gameParameter = repository.GetGameParameter();
            Assert.IsNull(gameParameter.Result);         
        }

        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/game", 81380, 3, new int[2] { 1, 2 })]
        public void SetGameResult_ValidResult_ShouldReturnSavedMessage(string url, int id, int lastChild, int[] orderOfElimination)
        {
            var repository = new GameRestRepository(url);
            var gameResult = new GameResult()
            {
                Id = id,
                LastChild = lastChild,
                OrderOfElimination = orderOfElimination
            };

            var postResponse = repository.SetGameResult(gameResult);

            Assert.IsTrue(postResponse.Result.Id == gameResult.Id);            
            Assert.IsTrue(postResponse.Result.Message.Equals("game results were saved", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        [DataRow("https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/gam", 81380, 3, new int[2] { 1, 2 })]
        public void SetGameResult_InvalidUrl_ShouldReturnNull(string url, int id, int lastChild, int[] orderOfElimination)
        {
            var repository = new GameRestRepository(url);
            var gameResult = new GameResult()
            {
                Id = id,
                LastChild = lastChild,
                OrderOfElimination = orderOfElimination
            };

            var postResponse = repository.SetGameResult(gameResult);

            Assert.IsNull(postResponse.Result);            
        }

    }
}
