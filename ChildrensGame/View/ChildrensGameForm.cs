using System;
using System.Threading.Tasks;
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
            lblWinning.Text = "";
            rtbChildrenEliminateSequence.Text = "";
            lblPostResult.Text = "";
        }

        /// <summary>
        /// Gets the number of children.
        /// </summary>
        /// <value>
        /// The number of children.
        /// </value>
        public int NumberOfChildren
        {
            get { return (int)nudNumberOfChildren.Value; }
        }

        /// <summary>
        /// Gets the eliminate each.
        /// </summary>
        /// <value>
        /// The eliminate each.
        /// </value>
        public int EliminateEach
        {
            get { return (int)nudEliminateEach.Value; }
        }

        /// <summary>
        /// Sets the number of children.
        /// </summary>
        /// <param name="numberOfChildren">The number of children.</param>
        public void SetNumberOfChildren(decimal numberOfChildren)
        {
            nudNumberOfChildren.Value = numberOfChildren;
        }

        /// <summary>
        /// Sets the eliminate each.
        /// </summary>
        /// <param name="eliminateEach">The eliminate each.</param>
        public void SetEliminateEach(decimal eliminateEach)
        {
            nudEliminateEach.Value = eliminateEach;
        }

        /// <summary>
        /// Sets the children eliminated sequence.
        /// </summary>
        /// <param name="eliminatedSequence">The eliminated sequence.</param>
        public void SetChildrenEliminatedSequence(string eliminatedSequence)
        {
            rtbChildrenEliminateSequence.Text = eliminatedSequence;
        }

        /// <summary>
        /// Sets the winning children.
        /// </summary>
        /// <param name="winningChildren">The winning children.</param>
        public void SetWinningChildren(string winningChildren)
        {
            lblWinning.Text = winningChildren;
        }

        /// <summary>
        /// Sets the post result.
        /// </summary>
        /// <param name="postResult">The post result.</param>
        public void SetPostResult(string postResult)
        {
            lblPostResult.Text = postResult;
        }

        /// <summary>
        /// Occurs when [new game button clicked].
        /// </summary>
        public event EventHandler NewGameButtonClicked;

        private void btnNewGame_Click(object sender, System.EventArgs e)
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
