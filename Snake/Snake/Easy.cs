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
    public partial class Easy : Form
    {
        Food f = new Food();
        Snake s = new Snake();
        public Easy()
        {
            InitializeComponent();
            Label label2 = f.display();
            this.Controls.Add(label2);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Top = 120;
            this.Left = 120;
            this.Width = 1000;
            this.Height = 500;
            this.BackColor = Color.White;
            int x = 10, y = 10;
            for (int i = 0; i < s.snakelen;)
            {
                Label label = new Label();
                label.BackColor = Color.Black;
                label.ForeColor = Color.Red;
                label.AutoSize = false;
                label.Size = new Size(10, 10);
                label.Location = new Point(x * 10, y * 10);
                this.Controls.Add(label);
                x--;
                s.labels[i]=label;
                i++;
            }
            //控件timer,每隔一段时间发生一次右移
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            //键盘敲击事件
            this.KeyDown += new KeyEventHandler(s.Form1_keyDown);
        }
        //时间，定时器
        public void timer1_Tick(object sender, EventArgs e)
        {
            s.Snake_move();
            EatFood();
            CheckSnakeBodyInfrm();
        }
        //判断是否吃到食物以及吃到食物后的反应
        void EatFood()
        {
            foreach (Label a1 in this.Controls)
            {
                if (a1.BackColor == Color.Red)
                {
                    if (a1.Location == s.labels[0].Location)
                    {
                        this.Controls.Remove(a1);
                        Label label2 = f.display();
                        this.Controls.Add(label2);
                        Snake_eat();
                    }
                }
            }
        }
        //吃到食物，蛇的身体变长
        void Snake_eat()
        {
            Label lb = new Label();
            lb.BackColor = Color.Black;
            lb.AutoSize = false;
            lb.Size = new Size(10, 10);
            lb.Location = s.labels[s.snakelen - 2].Location;
            s.snakelen++;
            Label length = s.length();
            this.Controls.Add(s.length());
        }
        //撞墙死亡
        public void CheckSnakeBodyInfrm()
        {
            DialogResult myresult;
            if (s.labels[0].Left <= 9 || s.labels[0].Top <= 9 || s.labels[0].Right >= 1271 || s.labels[0].Bottom >= 655)
            {
                timer1.Stop();
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
