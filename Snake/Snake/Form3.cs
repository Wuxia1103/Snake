using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        //简单模式
        private void button1_Click(object sender, EventArgs e)
        {
            BejinEasy beea = new BejinEasy();
            beea.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Top = 120;
            this.Left = 120;
            this.Width = 600;
            this.Height = 550;
            this.BackColor = Color.White;
        }
        //高级模式
        private void button2_Click(object sender, EventArgs e)
        {
            BejinSmart besmart = new BejinSmart();
            besmart.ShowDialog();
        }
        //挑战模式
        private void button3_Click(object sender, EventArgs e)
        {
            BeginChallenge becha = new BeginChallenge();
            becha.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

