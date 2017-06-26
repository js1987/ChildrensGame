using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrensGame.View
{
    public interface IChildrensGameView
    {
        int NumberOfChildren { get; }
        int EliminateEach { get; }

        void SetNumberOfChildren(decimal numberOfChildren);
        void SetEliminateEach(decimal eliminateEach);
        void SetChildrenEliminatedSequence(string eliminatedSequence);
        void SetWinningChildren(string winningChildren);
        void ShowLoading();
        void SetPostResult(string postResult);
        void HideLoading();
        void ShowErrorMessage(string errorMessage);
        event EventHandler NewGameButtonClicked;
    }
}
