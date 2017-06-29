using System;
using System.Windows.Forms;
using ChildrensGame.View;
using ChildrensGame.Presenter;
using ChildrensGame.Repository;

namespace ChildrensGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialise view
            var view = new ChildrensGameView();

            //Intialise repository
            IGameRepository repository = new GameRestRepository(Properties.Settings.Default.GameParameterAPIAddress);

            //Initialise game manager
            IChildrensGameManager gameManager = new ChildrensGameManager();

            //Initialise presenter
            var presenter = new ChildrensGamePresenter(view, repository, gameManager);     
            Application.Run(view);
        }
    }
}
