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
    public partial class Food : Form
    {
        public Food()
        {
            InitializeComponent();
        }

        //List<Label> labels = new List<Label>();//贪吃蛇身体数组
        Random food = new Random();//随机数,用于生成食物
        //int snakelen = 5;//蛇的初始长度
        Snake s = new Snake();

        // 利用随机函数生成食物
        public void display()
        {
            int x, y;//表示食物点的坐标
            x = food.Next(500);
            y = food.Next(66);
            Label lb = new Label();
            lb.BackColor = Color.Red;
            lb.AutoSize = false;
            lb.Size = new Size(10, 10);
            lb.Text = "";
            lb.Location = new Point(x * 10, y * 10);
            this.Controls.Add(lb);
        }
        //吃到食物，蛇的身体变长
        public void Snake_eat()
        {
            Label lb = new Label();
            lb.BackColor = Color.Black;
            lb.AutoSize = false;
            lb.Size = new Size(10, 10);
            lb.Location = s.labels[s.snakelen - 2].Location;
            this.Controls.Add(lb);
            s.labels.Add(lb);
            s.snakelen++;
        }
        //判断是否吃到食物以及吃到食物后的反应
        public void EatFood()
        {
            foreach (Label a1 in this.Controls)
            {
                if (a1.BackColor == Color.Red)
                {
                    if (a1.Location == s.labels[0].Location)
                    {
                        this.Controls.Remove(a1);
                        display();
                        Snake_eat();
                    }
                }
            }
        }
    }
}
