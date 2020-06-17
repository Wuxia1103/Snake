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
    public partial class Form2 : Form
    {
        string key = "D";//记录键盘状态
        List<Label> labels = new List<Label>();//贪吃蛇身体数组
        Random R = new Random();//随机数,用于生成食物坐标
        int snakelen = 5;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Top = 120;
            this.Left = 120;
            this.Width = 1000;
            this.Height = 500;
            this.BackColor = Color.White;
            //贪吃蛇设置
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
                this.Controls.Add(label);
                labels.Add(label);
                i++;
            }
            display();
            timer1.Start();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
        /// <summary>
        /// 时间，定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Snake_move();
            eat_food();
        }
        /// <summary>
        /// 键盘响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
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
        
        //吃过食物，蛇的身体变长
        void Snake_eat()
        {
            Label lb = new Label();
            lb.BackColor = Color.Black;
            lb.AutoSize = false;
            lb.Size = new Size(10, 10);
            lb.Location =labels[snakelen-2].Location;
            this.Controls.Add(lb);
            labels.Add(lb);
            snakelen++;
        }
        /// <summary>
        /// 创建食物
        /// </summary>
        public void display()
        {
            int x, y;//表示食物点的坐标
            x = R.Next(38);
            y = R.Next(36);
            Label lb = new Label();
            lb.BackColor = Color.Red;
            lb.AutoSize = false;//如果不关闭的话不能够设置size属性
            lb.Size = new Size(10, 10);
            lb.Text = "";
            lb.Location = new Point(x * 10, y * 10);
            this.Controls.Add(lb);
            
        }
        /// <summary>
        /// 吃食物
        /// </summary>
        public void eat_food()
        {
            foreach (Label lb in this.Controls)
            {
                if (lb.BackColor == Color.Red)
                {
                    if (lb.Location == labels[0].Location)
                    {
                        this.Controls.Remove(lb);
                        display();
                        Snake_eat();
                    }
                }
            }
        }

       
    }
}
