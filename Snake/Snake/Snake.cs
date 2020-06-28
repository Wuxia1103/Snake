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
    public partial class Snake : Form
    {
        public Snake()
        {
            InitializeComponent();
        }
        string key = "D";//记录键盘状态
        List<Label> labels = new List<Label>();//贪吃蛇身体数组
        int snakelen = 5;//蛇的初始长度
        Food f = new Food();
        Easy easy = new Easy();

        public void SetSnake()
        {
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
        }

        //蛇移动
        public void Snake_move()
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
       // 敲击键盘响应
        public void Form1_keyDown(object sender, KeyEventArgs e)
        {
            string a = Convert.ToString(e.KeyCode);
            switch (a)
            {
                case "W": key = "W"; break;//上
                case "A": key = "A"; break;//左
                case "S": key = "S"; break;//下
                case "D": key = "D"; break;//右
                //case "1": key = "1"; break;
                default: break;
            }
        }
        //撞墙死亡
            public void CheckSnakeBodyInfrm()
        {
            DialogResult myresult;
            if (labels[0].Left <= 9 || labels[0].Top <= 9 || labels[0].Right >= 1271 || labels[0].Bottom >= 655)
            {
                easy.timer1.Stop();
                MessageBox.Show("Game Over!");
                myresult = MessageBox.Show("Game Over!", "提示", MessageBoxButtons.OK);
                if (myresult == DialogResult.OK)
                {
                    this.Dispose();
                }
            }
        }

    }
}
