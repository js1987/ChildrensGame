using System;

namespace ChildrensGame.View
{
    public interface IChildrensGameView
    {
        string Winner { get; set; }
        decimal NumberOfChildren { get; set; }
        decimal EliminateEach { get; set; }
        string EliminatedSequence { get; set; }
        string PostResult { get; set; }


        void ShowLoading();
        void HideLoading();
        void ShowErrorMessage(string errorMessage);
        event EventHandler NewGameButtonClicked;
    }
}
