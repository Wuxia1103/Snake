using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Snake.Components;

namespace Snake
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "insert into Logins(userInfo,password) values('" + textBox1.Text + "','" + textBox2.Text + "')";

            DBHelper.update(sqlstr);
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
