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
    public partial class Challenge : Form
    {
        string key = "D";//记录键盘状态
        List<Label> labels = new List<Label>();//贪吃蛇身体数组
        //Timer dt = new Timer();
        Random food = new Random();//随机数,用于生成食物
        int snakelen = 5;//蛇的初始长度；
        //得分
        int score = 0;
        int second;//存放时间
        int First = 0, Last = 0;
        List<int> la = new List<int>();//保存数据
        public Challenge()
        {
            InitializeComponent();
            
            //控件timer,每隔一段时间发生一次右移
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();
            timer2.Start();
            //键盘敲击事件
            this.KeyDown += new KeyEventHandler(Form6_keyDown);
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            int x = 10, y = 10;
            for (int i = 0; i < snakelen;)
            {
                Label label = new Label();
                label.BackColor = Color.Black;
                label.ForeColor = Color.Red;
                label.AutoSize = false;
                label.Size = new Size(10, 10);
                label.Location = new Point(x * 10, y * 10);
                x--;
                pictureBox1.Controls.Add(label);
                labels.Add(label);
                i++;
            }
            display();
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
                //更新新纪录，还有问题
                First = score;
                la.Add(First);
                int s = la[0];
                label6.Text = s.ToString();
                if (Last > First)
                {
                    Last = score;
                    label6.Text = Last.ToString();
                    First = Last;
                }
                //else
                //{
                //    score = First;
                //}
            }
        }
        //定时器
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Snake_move();
            eat_food();
        }
        /// <summary>
        /// 敲击键盘响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form6_keyDown(object sender, KeyEventArgs e)
        {
            string a = Convert.ToString(e.KeyCode);
            switch (a)
            {
                case "W": key = "W"; break;//上
                case "A": key = "A"; break;//左
                case "S": key = "S"; break;//下
                case "D": key = "D"; break;//右
                default: break;
            }
        }
        //蛇移动
        void Snake_move()
        {
            switch (key)
            {
                case "D":
                    for (int i = snakelen - 1; i > 0;)
                    {
                        labels[i].Left = labels[i - 1].Left;
                        labels[i].Top = labels[i - 1].Top;
                        labels[i - 1].Left += 10;
                        i--;
                    }
                    break;
                case "A":
                    for (int i = snakelen - 1; i > 0;)
                    {
                        labels[i].Left = labels[i - 1].Left;
                        labels[i].Top = labels[i - 1].Top;
                        labels[i - 1].Left -= 10;
                        i--;
                    }
                    break;
                case "S":
                    for (int i = snakelen - 1; i > 0;)
                    {
                        labels[i].Left = labels[i - 1].Left;
                        labels[i].Top = labels[i - 1].Top;
                        labels[i - 1].Top += 10;
                        i--;
                    }
                    break;
                case "W":
                    for (int i = snakelen - 1; i > 0;)
                    {
                        labels[i].Left = labels[i - 1].Left;
                        labels[i].Top = labels[i - 1].Top;
                        labels[i - 1].Top -= 10;
                        i--;
                    }
                    break;
            }
        }
        //食物随机出现
         void display()
        {
            int x, y;//表示食物点的坐标
            x = food.Next(20);
            y = food.Next(30);
            Label lb = new Label();
            lb.BackColor = Color.Red;
            lb.AutoSize = false;
            lb.Size = new Size(10, 10);
            lb.Text = "";
            lb.Location = new Point(x * 10, y * 10);
            pictureBox1.Controls.Add(lb);
        }
        //吃食物
         void eat_food()
        {
             foreach (Label a1 in pictureBox1.Controls)
            {
                if (a1.BackColor == Color.Red)
                {
                    if (a1.Location == labels[0].Location)
                    {
                        pictureBox1.Controls.Remove(a1);
                        display();
                        Snake_eat();
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
            lb.Location = labels[snakelen - 2].Location;
            pictureBox1.Controls.Add(lb);
            score = score + 1;
            label4.Text = score.ToString();
            labels.Add(lb);
            snakelen++; 
        }
    }
}
