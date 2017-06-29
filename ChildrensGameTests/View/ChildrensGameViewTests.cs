using System;
using System.Text;
using System.Collections.Generic;
using ChildrensGame.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChildrensGameTests.View
{
    /// <summary>
    /// Summary description for ChildrensGameViews
    /// </summary>
    [TestClass]
    public class ChildrensGameViewTests
    {
        [TestMethod]
        [DataRow("some text")]
        public void PropertyWinner_SetValue_ShouldSetLabelWinnerText(string expectedResult)
        {
            //Arrange
            var childrensGameView = new ChildrensGameView();

            //Act
            childrensGameView.Winner = expectedResult;

            //Assert
            Assert.IsTrue(childrensGameView.Winner == expectedResult);
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("100")]
        [DataRow("1000")]
        [DataRow("32768")]
        [DataRow("3276008")]
        [DataRow("79228162514264337593543950335")]
        public void PropertyNumberOfChildren_SetValue_ShouldSetNumericUpAndDownNumberOfChildren(string expectedResult)
        {
            //Arrange
            var childrensGameView = new ChildrensGameView();
            var expectedResultDecimal = Convert.ToDecimal(expectedResult);

            //Act
            childrensGameView.NumberOfChildren = expectedResultDecimal;

            //Assert
            Assert.IsTrue(childrensGameView.NumberOfChildren == expectedResultDecimal);
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("100")]
        [DataRow("1000")]
        [DataRow("32768")]
        [DataRow("3276008")]
        [DataRow("79228162514264337593543950335")]
        public void PropertyEliminateEach_SetValue_ShouldSetNumericUpAndDownEliminateEach(string expectedResult)
        {
            //Arrange
            var childrensGameView = new ChildrensGameView();
            var expectedResultDecimal = Convert.ToDecimal(expectedResult);

            //Act
            childrensGameView.EliminateEach = expectedResultDecimal;

            //Assert
            Assert.IsTrue(childrensGameView.EliminateEach == expectedResultDecimal);
        }

        [TestMethod]
        [DataRow("1, 2, 3, 4, 5")]
        [DataRow("15, 78, 52, 96, 21, 47, 102, 541, 236")]
        public void PropertyEliminatedSequence_SetValue_ShouldSetRichTextBoxEliminatedSequence(string expectedResult)
        {
            //Arrange
            var childrensGameView = new ChildrensGameView();

            //Act
            childrensGameView.EliminatedSequence = expectedResult;

            //Assert
            Assert.IsTrue(childrensGameView.EliminatedSequence == expectedResult);
        }

        [TestMethod]        
        [DataRow("some text")]
        public void PropertyPostResult_SetValue_ShouldSetTextBoxPostResult(string expectedResult)
        {
            //Arrange
            var childrensGameView = new ChildrensGameView();

            //Act
            childrensGameView.PostResult = expectedResult;

            //Assert
            Assert.IsTrue(childrensGameView.PostResult == expectedResult);
        }
    }
}
