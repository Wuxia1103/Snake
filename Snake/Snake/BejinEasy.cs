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

    public partial class BejinEasy : Form
    {
        public BejinEasy()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Top = 120;
            this.Left = 120;    
            this.Width = 1000;
            this.Height = 550;
            this.BackColor = Color.White;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            Easy form2 = new Easy();
            this.Hide();
            form2.ShowDialog();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Dispose();
        }
    }
}
