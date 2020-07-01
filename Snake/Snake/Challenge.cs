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
    public partial class Challenge : Form
    {
        Food f = new Food();
        Snake s = new Snake();
        //得分
        int score = 0;
        int second;//存放时间
        public Challenge()
        {
            InitializeComponent();
            Label label2 = f.display();
            pictureBox1.Controls.Add(label2);
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
        }
        //倒计时
        private void timer2_Tick(object sender, EventArgs e)
        {
            second = int.Parse(label5.Text);
            second--;
            this.label5.Text = second.ToString();
            if (second == 0)
            {
                this.label5.Enabled = false;
                this.label5.Enabled = true;
                timer2.Stop();
                timer1.Stop();
                MessageBox.Show("Game over!");
                this.label6.Text = score.ToString();
                //更新新纪录，还有问题
                //DBHelper.open();
                //SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.Connection = DBHelper.conn;
                //sqlCommand.CommandType = CommandType.Text;
                ////sqlCommand.CommandText = "select 最高得分 from Logins where 最高得分='" + label6.Text ;
                //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                //DataSet myDataSet = new DataSet();
                //string myString = myDataSet.Tables["Logins"].Rows[3]["最高得分"].ToString();
                //while (sqlDataReader.Read())
                //{
                //    if (sqlDataReader["最高得分"].ToString() != null)
                //    {
                //        //数据库中得分数不为0
                //    }
                //    else
                //    {
                //        //数据库中的得分数为0,第一次
                //        myString = label6.Text;
                //    }

                //}
                //sqlDataReader.Close();
                //DBHelper.close();
            }
        }
        //定时器
        private void Timer1_Tick(object sender, EventArgs e)
        {
            s.Snake_move();
            eat_food();
            CheckSnakeBodyInfrm();
        }
        //吃食物
         void eat_food()
        {
             foreach (Label a1 in pictureBox1.Controls)
            {
                if (a1.BackColor == Color.Red)
                {
                    if (a1.Location == s.labels[0].Location)
                    {
                        pictureBox1.Controls.Remove(a1);
                        Label label2 = f.display();
                        pictureBox1.Controls.Add(label2);
                        Snake_eat();
                        score = score + 1;
                        label4.Text = score.ToString();
                    }
                }
            }
        }
        //小蛇吃食物长身体
        void Snake_eat()
        {
            Label lb = new Label();
            lb.BackColor = Color.Black;
            lb.AutoSize = false;
            lb.Size = new Size(10, 10);
            lb.Location = s.labels[s.snakelen - 2].Location;
            s.snakelen++;
            Label length = s.length();
            pictureBox1.Controls.Add(s.length());
            
        }
        //撞墙判断
        public void CheckSnakeBodyInfrm()
        {
            DialogResult myresult;
            if (s.labels[0].Left <= 0 || s.labels[0].Left >= 420 || s.labels[0].Top <= 0 || s.labels[0].Top >= 315)
            {
                timer1.Stop();
                timer2.Stop();
                myresult=MessageBox.Show("Game over!","提示",MessageBoxButtons.OK);
                if (myresult == DialogResult.OK)
                {
                    this.Dispose();
                }
                this.label6.Text = score.ToString();
                ////更新新纪录，还有问题
                //this.label6.Text = score.ToString();
                //DBHelper.open();
                //SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.Connection = DBHelper.conn;
                //sqlCommand.CommandType = CommandType.Text;
                //sqlCommand.CommandText = "select 最高得分 from Logins where 最高得分='" + label6.Text ;
                //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                //DataSet myDataSet = new DataSet();
                //string myString = myDataSet.Tables["Logins"].Rows[3]["最高得分"].ToString();
                //while (sqlDataReader.Read())
                //{
                //    if (sqlDataReader["最高得分"].ToString() != null)
                //    {
                //        //数据库中得分数不为0


                //    }
                //    else
                //    {
                //        //数据库中的得分数为0,第一次
                //        myString = label6.Text;
                //    }

                //}
                //sqlDataReader.Close();
                //DBHelper.close();
            }
        }

        private void Challenge_Load(object sender, EventArgs e)
        {
            //贪吃蛇设置
            int x = 10, y = 10;
            for (int i = 0; i < s.snakelen;)
            {
                Label label = new Label();
                label.BackColor = Color.Black;
                label.ForeColor = Color.Red;
                label.AutoSize = false;
                label.Size = new Size(10, 10);
                label.Location = new Point(x * 10, y * 10);
                x--;
                pictureBox1.Controls.Add(label);
                s.labels[i] = label;
                i++;
            }
            //控件timer,每隔一段时间发生一次右移
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();
            timer2.Start();
            //键盘敲击事件
            this.KeyDown += new KeyEventHandler(s.Form1_keyDown);
        }
    }
}
