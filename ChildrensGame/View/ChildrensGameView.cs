using System;
using System.Windows.Forms;

namespace ChildrensGame.View
{
    public partial class ChildrensGameView : Form, IChildrensGameView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChildrensGameView"/> class.
        /// </summary>
        public ChildrensGameView()
        {
            InitializeComponent();
            lblWinner.Text = "";
            rtbChildrenEliminateSequence.Text = "";
            lblPostResult.Text = "";
        }

        public string Winner { get { return lblWinner.Text; } set { lblWinner.Text = value; } }
        public decimal NumberOfChildren
        {
            get { return nudNumberOfChildren.Value; }
            set
            {
                if (value > nudNumberOfChildren.Maximum)
                    nudNumberOfChildren.Maximum = value;
                nudNumberOfChildren.Value = value;
            }
        }

        public decimal EliminateEach
        {
            get { return nudEliminateEach.Value; }
            set
            {
                if (value > nudEliminateEach.Maximum)
                    nudEliminateEach.Maximum = value;
                nudEliminateEach.Value = value;
            }
        }

        public string EliminatedSequence
        {
            get { return rtbChildrenEliminateSequence.Text; }
            set
            {
                rtbChildrenEliminateSequence.Text = value;
            }
        }

        public string PostResult { get { return lblPostResult.Text; } set { lblPostResult.Text = value; } }        

        /// <summary>
        /// Occurs when [new game button clicked].
        /// </summary>
        public event EventHandler NewGameButtonClicked;

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (NewGameButtonClicked != null) NewGameButtonClicked(sender, e);
        }

        /// <summary>
        /// Show loading image, overlaying Button New Game
        /// </summary>
        public void ShowLoading()
        {
            btnNewGame.Enabled = false;
            pbLoading.Visible = true;
        }

        /// <summary>
        /// Hides the loading.
        /// </summary>
        public void HideLoading()
        {
            btnNewGame.Enabled = true;
            pbLoading.Visible = false;
        }

        /// <summary>
        /// Shows the error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }
    }
}
