using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChildrensGame.Model;
using ChildrensGame.View;
using ChildrensGame.Presenter;

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

            //Initialise presenter
            var presenter = new ChildrensGamePresenter(view, repository);     
            Application.Run(view);
        }
    }
}
