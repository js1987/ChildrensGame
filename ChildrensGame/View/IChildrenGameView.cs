using System;

namespace ChildrensGame.View
{
    public interface IChildrensGameView
    {
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
