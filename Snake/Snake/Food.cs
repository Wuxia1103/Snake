﻿using System;
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
     public class Food
    {
    //    List<Label> labels = new List<Label>();//贪吃蛇身体数组
    //    Random food = new Random();//随机数,用于生成食物
    //    int snakelen = 5;//蛇的初始长度
    //    Form2 Form2 = new Form2();

    //    // 利用随机函数生成食物
    //    public void display()
    //    {
    //        int x, y;//表示食物点的坐标
    //        x = food.Next(55);
    //        y = food.Next(66);
    //        Label lb = new Label();
    //        lb.BackColor = Color.Red;
    //        lb.AutoSize = false;
    //        lb.Size = new Size(10, 10);
    //        lb.Text = "";
    //        lb.Location = new Point(x * 10, y * 10);
    //        Form2.Controls.Add(lb);
    //    }
    //    ////吃到食物，蛇的身体变长
    //    public void Snake_eat()
    //    {
    //        Label lb = new Label();
    //        lb.BackColor = Color.Black;
    //        lb.AutoSize = false;
    //        lb.Size = new Size(10, 10);
    //        lb.Location = labels[snakelen - 2].Location;
    //        Form2.Controls.Add(lb);
    //        labels.Add(lb);
    //        snakelen++;
    //    }
    //    ////判断是否吃到食物以及吃到食物后的反应
    //    public void EatFood()
    //    {
    //        foreach (Label a1 in Form2.Controls)
    //        {
    //            if (a1.BackColor == Color.Red)
    //            {
    //                if (a1.Location == labels[0].Location)
    //                {
    //                    Form2.Controls.Remove(a1);
    //                    display();
    //                    Snake_eat();
    //                }
    //            }
    //        }
    //    }
    }
}
