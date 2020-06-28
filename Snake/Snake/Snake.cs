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
        public string key = "D";//记录键盘状态
        public int snakelen = 5;//蛇的初始长度
        public Label[] labels = new Label[100];
        
        //蛇移动
        public void Snake_move()
        {
            switch (key)
            {
                case "D":
                    for (int i =snakelen-1; i > 0; i--)
                    {
                        labels[i].Left = labels[i - 1].Left;
                        labels[i].Top = labels[i - 1].Top;
                        labels[i - 1].Left += 10;
                        
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
        //敲击键盘响应
        public void Form1_keyDown(object sender, KeyEventArgs e)
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
        public Label length()
        {
            Label length = new Label();
            length.Width = 10;
            length.Height = 10;
            length.BackColor = Color.Black;
            length.Top = labels[snakelen - 2].Top;
            length.Left = labels[snakelen - 2].Left;
            labels[snakelen - 1] = length;
            return length;
        }

        private void Snake_Load(object sender, EventArgs e)
        {

        }
    }
}
