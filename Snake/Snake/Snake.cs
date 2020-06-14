using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    class Snake:Form1
    {
        string key = "start";//记录键盘状态
        Label[] labels = new Label[3000];//贪吃蛇身体数组
        Timer dt = new Timer();
        Random R = new Random();//随机数,用于生成食物
        int a = 0, b = 0;// 记录坐标
        void snake()
        {
            this.Top = 120;
            this.Left = 120;
            this.Width = 800;
            this.Height = 800;
            this.BackColor = Color.White;
            //贪吃蛇设置
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.Width = label.Height = 10;
                //蛇的位置
                label.Top = 00;
                label.Left = 400 - i * 10;
                label.BackColor = Color.Black;
                label.Text = "▉";
                //获取或设置包含有关控件的数据的对象。
                label.Tag = i;
                labels[i] = label;
                this.Controls.Add(label);
            }
            //控件Timer，每隔一段时间发生一次右移（start）
            dt.Tick += new EventHandler(dt_Tick);
            //键盘敲击事件
            //this.KeyDown += new KeyEventHandler(form_keyDown);
            dt.Start();//timer开始计时
        }
        //蛇移动
        void Snake_move(int m, int n)
        {
            int x = 0, y = 0;
            for (int i = 1; labels[i] != null; i++)
            {
                if (i >= 3)
                {
                    x = a;
                    y = b;
                }
                if (i == 1)
                {
                    x = labels[i].Left;
                    y = labels[i].Top;
                    labels[i].Left = m;
                    labels[i].Top = n;
                }
                else
                {
                    a = labels[i].Left;
                    b = labels[i].Top;
                    labels[i].Left = x;
                    labels[i].Top = y;
                }
            }
        }
        //吃过食物，蛇的身体变长
        void Snake_eat()
        {
            int i = 0;
            for (; labels[i] != null; i++) ;
            Label lb = new Label();
            lb.Top = b;
            lb.Left = a;
            lb.BackColor = Color.Black;
            lb.Text = "▉";
            lb.Tag = i;
            labels[i] = lb;
            //this.Controls.Add(lb);
        }
        /// <summary>
        /// 键盘按键输入的响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dt_Tick(object sender, EventArgs e)
        {
            int m, n;
            m = labels[0].Left;
            n = labels[0].Top;
            if (key == "start")
            {
                labels[0].Left = m + 10;
                Snake_move(m, n);
            }
            //右
            if (key == "D")
            {
                labels[0].Left = m + 10;
                Snake_move(m, n);
            }
            //左
            if (key == "A")
            {
                labels[0].Left = m - 10;
                Snake_move(m, n);
            }
            //上
            if (key == "W")
            {
                labels[0].Top = n - 10;
                Snake_move(m, n);
            }
            //下
            if (key == "S")
            {
                labels[0].Top = n + 10;
                Snake_move(m, n);
            }
            //每按一次，判断是否与食物重合
           // eat_time();
        }
        /// <summary>
        /// 敲击键盘响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void form_keyDown(object sender, KeyEventArgs e)
        {
            int m, n;
            m = labels[0].Left;
            n = labels[0].Top;
            //获取按了什么键
            key = e.KeyCode.ToString();
            //右
            if (e.KeyCode.ToString() == "D")
            {
                labels[0].Left = m + 10;
            }
            //左
            if (e.KeyCode.ToString() == "A")
            {
                labels[0].Left = m - 10;
            }
            //上
            if (e.KeyCode.ToString() == "W")
            {
                labels[0].Top = n - 10;
            }
            //下
            if (e.KeyCode.ToString() == "S")
            {
                labels[0].Top = n + 10;
            }
            //eat_time();
        }
    }
}
