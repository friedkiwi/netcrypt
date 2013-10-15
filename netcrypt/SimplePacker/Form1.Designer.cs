namespace SimplePacker
{
    partial class Form1
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
            this.twitterLink = new System.Windows.Forms.LinkLabel();
            this.sourceCodeLink = new System.Windows.Forms.LinkLabel();
            this.madeByLabel = new System.Windows.Forms.Label();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.outputFileLabel = new System.Windows.Forms.Label();
            this.inputFileLocationLabel = new System.Windows.Forms.Label();
            this.outputFileLocationLabel = new System.Windows.Forms.Label();
            this.chooseInputButton = new System.Windows.Forms.Button();
            this.chooseOutputButton = new System.Windows.Forms.Button();
            this.packExecButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // twitterLink
            // 
            this.twitterLink.AutoSize = true;
            this.twitterLink.Location = new System.Drawing.Point(70, 71);
            this.twitterLink.Name = "twitterLink";
            this.twitterLink.Size = new System.Drawing.Size(56, 13);
            this.twitterLink.TabIndex = 0;
            this.twitterLink.TabStop = true;
            this.twitterLink.Text = "@friedkiwi";
            this.twitterLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.twitterLink_LinkClicked);
            // 
            // sourceCodeLink
            // 
            this.sourceCodeLink.AutoSize = true;
            this.sourceCodeLink.Location = new System.Drawing.Point(132, 71);
            this.sourceCodeLink.Name = "sourceCodeLink";
            this.sourceCodeLink.Size = new System.Drawing.Size(66, 13);
            this.sourceCodeLink.TabIndex = 1;
            this.sourceCodeLink.TabStop = true;
            this.sourceCodeLink.Text = "source code";
            this.sourceCodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.sourceCodeLink_LinkClicked);
            // 
            // madeByLabel
            // 
            this.madeByLabel.AutoSize = true;
            this.madeByLabel.Location = new System.Drawing.Point(13, 71);
            this.madeByLabel.Name = "madeByLabel";
            this.madeByLabel.Size = new System.Drawing.Size(51, 13);
            this.madeByLabel.TabIndex = 2;
            this.madeByLabel.Text = "Made by ";
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Location = new System.Drawing.Point(13, 13);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(47, 13);
            this.inputFileLabel.TabIndex = 3;
            this.inputFileLabel.Text = "Input file";
            // 
            // outputFileLabel
            // 
            this.outputFileLabel.AutoSize = true;
            this.outputFileLabel.Location = new System.Drawing.Point(13, 37);
            this.outputFileLabel.Name = "outputFileLabel";
            this.outputFileLabel.Size = new System.Drawing.Size(55, 13);
            this.outputFileLabel.TabIndex = 4;
            this.outputFileLabel.Text = "Output file";
            // 
            // inputFileLocationLabel
            // 
            this.inputFileLocationLabel.Location = new System.Drawing.Point(75, 13);
            this.inputFileLocationLabel.Name = "inputFileLocationLabel";
            this.inputFileLocationLabel.Size = new System.Drawing.Size(245, 13);
            this.inputFileLocationLabel.TabIndex = 5;
            this.inputFileLocationLabel.Text = "(choose)";
            // 
            // outputFileLocationLabel
            // 
            this.outputFileLocationLabel.Location = new System.Drawing.Point(75, 37);
            this.outputFileLocationLabel.Name = "outputFileLocationLabel";
            this.outputFileLocationLabel.Size = new System.Drawing.Size(245, 13);
            this.outputFileLocationLabel.TabIndex = 6;
            this.outputFileLocationLabel.Text = "(choose)";
            // 
            // chooseInputButton
            // 
            this.chooseInputButton.Location = new System.Drawing.Point(344, 8);
            this.chooseInputButton.Name = "chooseInputButton";
            this.chooseInputButton.Size = new System.Drawing.Size(48, 23);
            this.chooseInputButton.TabIndex = 7;
            this.chooseInputButton.Text = "...";
            this.chooseInputButton.UseVisualStyleBackColor = true;
            this.chooseInputButton.Click += new System.EventHandler(this.chooseInputButton_Click);
            // 
            // chooseOutputButton
            // 
            this.chooseOutputButton.Location = new System.Drawing.Point(344, 37);
            this.chooseOutputButton.Name = "chooseOutputButton";
            this.chooseOutputButton.Size = new System.Drawing.Size(48, 23);
            this.chooseOutputButton.TabIndex = 8;
            this.chooseOutputButton.Text = "...";
            this.chooseOutputButton.UseVisualStyleBackColor = true;
            this.chooseOutputButton.Click += new System.EventHandler(this.chooseOutputButton_Click);
            // 
            // packExecButton
            // 
            this.packExecButton.Location = new System.Drawing.Point(317, 66);
            this.packExecButton.Name = "packExecButton";
            this.packExecButton.Size = new System.Drawing.Size(75, 23);
            this.packExecButton.TabIndex = 9;
            this.packExecButton.Text = "Pack!";
            this.packExecButton.UseVisualStyleBackColor = true;
            this.packExecButton.Click += new System.EventHandler(this.packExecButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = ".NET executables (*.exe) |*.exe";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = ".NET executables (*.exe) |*.exe";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 98);
            this.Controls.Add(this.packExecButton);
            this.Controls.Add(this.chooseOutputButton);
            this.Controls.Add(this.chooseInputButton);
            this.Controls.Add(this.outputFileLocationLabel);
            this.Controls.Add(this.inputFileLocationLabel);
            this.Controls.Add(this.outputFileLabel);
            this.Controls.Add(this.inputFileLabel);
            this.Controls.Add(this.madeByLabel);
            this.Controls.Add(this.sourceCodeLink);
            this.Controls.Add(this.twitterLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "SimplePacker (netcrypt sample)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel twitterLink;
        private System.Windows.Forms.LinkLabel sourceCodeLink;
        private System.Windows.Forms.Label madeByLabel;
        private System.Windows.Forms.Label inputFileLabel;
        private System.Windows.Forms.Label outputFileLabel;
        private System.Windows.Forms.Label inputFileLocationLabel;
        private System.Windows.Forms.Label outputFileLocationLabel;
        private System.Windows.Forms.Button chooseInputButton;
        private System.Windows.Forms.Button chooseOutputButton;
        private System.Windows.Forms.Button packExecButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

