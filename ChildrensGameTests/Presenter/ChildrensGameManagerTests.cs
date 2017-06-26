using System.Threading.Tasks;
using ChildrensGame.Model;
using ChildrensGame.Presenter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChildrensGameTests.Presenter
{
    [TestClass()]
    public class ChildrensGameManagerTests
    {
        [TestMethod]
        [DataRow(3, 1, 3, new int[2] { 1, 2 })]
        [DataRow(10, 3, 4, new int[9] { 3, 6, 9, 2, 7, 1, 8, 5, 10})]
        [DataRow(1, 1, 1, new int[0])]

        public void CalculateGameResult_PassInChildrenCountAndEliminateEach_ShouldReturnEexpectedResult(int childrenCount, int eliminateEach, int lastChild, int[] orderOfElimination)
        {
            //Arrange
            var manager = new ChildrensGameManager();
            var mock = new Mock<IGameRepository>();
            mock.Setup(m => m.GetGameParameter()).Returns(Task.FromResult(new GameParameter() { ChildrenCount = childrenCount, EliminateEach = eliminateEach }));

            //Act
            var actualGameResult = manager.CalculateGameResult(mock.Object.GetGameParameter().Result);
            var expectGameResult = new GameResult() { LastChild = lastChild, OrderOfElimination = orderOfElimination };

            //Assert
            Assert.IsTrue(actualGameResult.LastChild == expectGameResult.LastChild);
            CollectionAssert.AreEqual(actualGameResult.OrderOfElimination, expectGameResult.OrderOfElimination);
        }
    }
}