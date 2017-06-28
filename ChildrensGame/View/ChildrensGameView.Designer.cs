namespace ChildrensGame.View
{
    partial class ChildrensGameView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildrensGameView));
            this.label1 = new System.Windows.Forms.Label();
            this.nudNumberOfChildren = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudEliminateEach = new System.Windows.Forms.NumericUpDown();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.rtbChildrenEliminateSequence = new System.Windows.Forms.RichTextBox();
            this.lblWinning = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.gbPostResult = new System.Windows.Forms.GroupBox();
            this.lblPostResult = new System.Windows.Forms.Label();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.gbWelcome = new System.Windows.Forms.GroupBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEliminateEach)).BeginInit();
            this.gbInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.gbPostResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.gbWelcome.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Children";
            // 
            // nudNumberOfChildren
            // 
            this.nudNumberOfChildren.Enabled = false;
            this.nudNumberOfChildren.Location = new System.Drawing.Point(106, 13);
            this.nudNumberOfChildren.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudNumberOfChildren.Name = "nudNumberOfChildren";
            this.nudNumberOfChildren.Size = new System.Drawing.Size(48, 20);
            this.nudNumberOfChildren.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Eliminate Each";
            // 
            // nudEliminateEach
            // 
            this.nudEliminateEach.Enabled = false;
            this.nudEliminateEach.Location = new System.Drawing.Point(106, 37);
            this.nudEliminateEach.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudEliminateEach.Name = "nudEliminateEach";
            this.nudEliminateEach.Size = new System.Drawing.Size(48, 20);
            this.nudEliminateEach.TabIndex = 3;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.label1);
            this.gbInput.Controls.Add(this.nudEliminateEach);
            this.gbInput.Controls.Add(this.nudNumberOfChildren);
            this.gbInput.Controls.Add(this.label2);
            this.gbInput.Location = new System.Drawing.Point(9, 137);
            this.gbInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbInput.Name = "gbInput";
            this.gbInput.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbInput.Size = new System.Drawing.Size(161, 65);
            this.gbInput.TabIndex = 4;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Input";
            // 
            // gbOutput
            // 
            this.gbOutput.Controls.Add(this.rtbChildrenEliminateSequence);
            this.gbOutput.Controls.Add(this.lblWinning);
            this.gbOutput.Controls.Add(this.label4);
            this.gbOutput.Controls.Add(this.label3);
            this.gbOutput.Location = new System.Drawing.Point(9, 207);
            this.gbOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbOutput.Size = new System.Drawing.Size(232, 117);
            this.gbOutput.TabIndex = 5;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // rtbChildrenEliminateSequence
            // 
            this.rtbChildrenEliminateSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChildrenEliminateSequence.Location = new System.Drawing.Point(7, 54);
            this.rtbChildrenEliminateSequence.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbChildrenEliminateSequence.Name = "rtbChildrenEliminateSequence";
            this.rtbChildrenEliminateSequence.ReadOnly = true;
            this.rtbChildrenEliminateSequence.Size = new System.Drawing.Size(222, 58);
            this.rtbChildrenEliminateSequence.TabIndex = 4;
            this.rtbChildrenEliminateSequence.TabStop = false;
            this.rtbChildrenEliminateSequence.Text = "{{Eliminate Sequence}}";
            // 
            // lblWinning
            // 
            this.lblWinning.AutoSize = true;
            this.lblWinning.Location = new System.Drawing.Point(53, 15);
            this.lblWinning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWinning.Name = "lblWinning";
            this.lblWinning.Size = new System.Drawing.Size(62, 13);
            this.lblWinning.TabIndex = 2;
            this.lblWinning.Text = "{{Winning}}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Winning:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Children Eliminate Sequence:";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewGame.Location = new System.Drawing.Point(175, 140);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(66, 38);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // gbPostResult
            // 
            this.gbPostResult.Controls.Add(this.lblPostResult);
            this.gbPostResult.Location = new System.Drawing.Point(9, 321);
            this.gbPostResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbPostResult.Name = "gbPostResult";
            this.gbPostResult.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbPostResult.Size = new System.Drawing.Size(232, 54);
            this.gbPostResult.TabIndex = 7;
            this.gbPostResult.TabStop = false;
            this.gbPostResult.Text = "Post Result";
            // 
            // lblPostResult
            // 
            this.lblPostResult.AutoSize = true;
            this.lblPostResult.Location = new System.Drawing.Point(4, 15);
            this.lblPostResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPostResult.Name = "lblPostResult";
            this.lblPostResult.Size = new System.Drawing.Size(74, 13);
            this.lblPostResult.TabIndex = 0;
            this.lblPostResult.Text = "{{PostResult}}";
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::ChildrensGame.Properties.Resources.ajax_loader;
            this.pbLoading.Location = new System.Drawing.Point(175, 180);
            this.pbLoading.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(66, 22);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLoading.TabIndex = 1;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // gbWelcome
            // 
            this.gbWelcome.Controls.Add(this.lblWelcome);
            this.gbWelcome.Location = new System.Drawing.Point(8, 10);
            this.gbWelcome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbWelcome.Name = "gbWelcome";
            this.gbWelcome.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbWelcome.Size = new System.Drawing.Size(232, 123);
            this.gbWelcome.TabIndex = 8;
            this.gbWelcome.TabStop = false;
            this.gbWelcome.Text = "Welcome";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Location = new System.Drawing.Point(5, 15);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(223, 97);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = resources.GetString("lblWelcome.Text");
            // 
            // ChildrensGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 383);
            this.Controls.Add(this.gbWelcome);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.gbPostResult);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChildrensGameView";
            this.Text = "Children\'s Game";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEliminateEach)).EndInit();
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.gbPostResult.ResumeLayout(false);
            this.gbPostResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.gbWelcome.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudNumberOfChildren;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudEliminateEach;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Label lblWinning;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbChildrenEliminateSequence;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.GroupBox gbPostResult;
        private System.Windows.Forms.Label lblPostResult;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.GroupBox gbWelcome;
        private System.Windows.Forms.Label lblWelcome;
    }
}

