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
        Random food = new Random();//随机数,用于生成食物
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
            int x = 10,y = 10;
            for (int i = 0; i < snakelen;)
            {
                Label label = new Label();
                label.BackColor = Color.Black;
                label.ForeColor = Color.Red;
                label.AutoSize = false;
                label.Size = new Size(10,10);
                label.Location = new Point(x * 10,y * 10);
                x--;
                this.Controls.Add(label);
                labels.Add(label);
                i++;
            }
            //控件timer,每隔一段时间发生一次右移
            //dt.Tick += new EventHandler(dt_Tick);
            display();
            timer1.Start();
            //键盘敲击事件
            this.KeyDown += new KeyEventHandler(Form1_keyDown);
        }

        //时间，定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            Snake_move();
            EatFood();
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
        /// <summary>
        /// 敲击键盘响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_keyDown(object sender, KeyEventArgs e)
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
        // 利用随机函数生成食物
         void display()
        {
            int x, y;//表示食物点的坐标
            x = food.Next(55);
            y = food.Next(66);
            Label lb = new Label();
            lb.BackColor = Color.Red;
            lb.AutoSize = false;
            lb.Size = new Size(10, 10);
            lb.Text = "hhhh";
            lb.Location = new Point(x * 10, y * 10);
            this.Controls.Add(lb);
        }
        //吃到食物，蛇的身体变长
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
        //判断是否吃到食物以及吃到食物后的反应
        void EatFood()
        {
            foreach (Label a1 in this.Controls)
            {
                if (a1.BackColor == Color.Red)
                {
                    if (a1.Location == labels[0].Location)
                    {
                        this.Controls.Remove(a1);
                        display();
                        Snake_eat();
                    }
                }
            }
        }
        //设定速度
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (comboBox1.SelectedIndex)
        //    {
        //        case 1: speed = 500; break;
        //        case 2: speed = 450; break;
        //        case 3: speed = 400; break;
        //        case 4: speed = 350; break;
        //        case 5: speed = 300; break;
        //        case 6: speed = 250; break;
        //        case 7: speed = 200; break;
        //        case 8: speed = 150; break;
        //        case 9: speed = 100; break;
        //    }
        //    this.timer1.Interval = speed;
        //}
    }
}
