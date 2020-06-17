using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Food
    {
        List<Label> labels = new  List<Label>();
        Random food = new Random();
        int snakelen = 5;
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
    }
}
