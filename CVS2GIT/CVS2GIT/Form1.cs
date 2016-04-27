using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVS2GIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Perform run = new Perform(this);
            //run.DisplayLines("test");
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Perform run = new Perform(this);
            run.GenDats();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog cvs = new FolderBrowserDialog();
            if (DialogResult.OK == cvs.ShowDialog())
            {
                textBox1.Text = cvs.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog git = new FolderBrowserDialog();
            if (DialogResult.OK == git.ShowDialog())
            {
                textBox3.Text = git.SelectedPath;
            }
        }

        private void createGitButton_Click(object sender, EventArgs e)
        {
            Perform run = new Perform(this);
            run.CreateGit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Perform run = new Perform(this);
            run.pushGit();
        }
    }
}
