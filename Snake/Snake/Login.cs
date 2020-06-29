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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox_Username_Leave(object sender, EventArgs e)
        {
            if (textBox_Username.Text == "")
            {
                textBox_Username.Text = "用户名不可为空";
                textBox_Password.ForeColor = Color.Gray;
            }
            //当当前控件失去焦点时，设置背景颜色为白色
            textBox_Username.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBHelper.open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DBHelper.conn;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select userInfo,password from Logins where userInfo='" + textBox_Username.Text + "' and password='" + textBox_Password.Text + "'";

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["userInfo"].ToString() != null && sqlDataReader["password"].ToString() != null)
                {


                    //if (textBox2.Text == sqlDataReader["password"].ToString())
                    //{
                    MessageBox.Show("登录成功！");

                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.ShowDialog();
                    this.Dispose();

                    //}


                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入！");
                }

            }
            sqlDataReader.Close();
            DBHelper.close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
            this.Dispose();
        }
    }
}
