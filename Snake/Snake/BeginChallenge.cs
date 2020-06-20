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
    public partial class BeginChallenge : Form
    {
        public BeginChallenge()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Challenge cha = new Challenge();
            this.Hide();
            cha.ShowDialog();
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
