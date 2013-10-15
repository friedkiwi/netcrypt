using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Netcrypt;

namespace SimplePacker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void twitterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://bit.ly/168dEqY");
        }

        private void sourceCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://bit.ly/1gIe8pZ");
        }

        private void packExecButton_Click(object sender, EventArgs e)
        {
            if (inputFileLocationLabel.Text == "(choose)")
            {
                MessageBox.Show("Please choose an input file first.");
                return;
            }

            if (outputFileLocationLabel.Text == "(choose)")
            {
                MessageBox.Show("Please choose an output file first.");
                return;
            }

            try
            {
                File.WriteAllBytes(outputFileLocationLabel.Text, Packer.Pack(File.ReadAllBytes(inputFileLocationLabel.Text)));
                MessageBox.Show("Packing completed succesfully.\n\nCross your fingers and try to execute the output file...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured while packing the executable.\nPlease note:\n* Only .NET executables will work\n* This is a proof-of-concept packer, designed as a learning aid for .NET developers. It might just not work on your executable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chooseInputButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                inputFileLocationLabel.Text = openFileDialog.FileName;
            }
        }

        private void chooseOutputButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputFileLocationLabel.Text = saveFileDialog.FileName;
            }
        }
    }
}
