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
        public List<Label> labels = new List<Label>();//贪吃蛇身体数组
        Food f = new Food();
        Snake snake = new Snake();
        public Easy()
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
            f.display();
            snake.SetSnake();
            //控件timer,每隔一段时间发生一次右移
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            //键盘敲击事件
            this.KeyDown += new KeyEventHandler(snake.Form1_keyDown);
        }

        //时间，定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            snake.Snake_move();
            f.EatFood();
            CheckSnakeBodyInfrm();
        }
        //撞墙死亡
        public void CheckSnakeBodyInfrm()
        {
            DialogResult myresult;
            if (labels[0].Left <= 9 || labels[0].Top <= 9 || labels[0].Right >= 1271 || labels[0].Bottom >= 655)
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
