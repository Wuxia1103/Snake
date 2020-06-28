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

        Random food = new Random();//随机数,用于生成食物
        // 利用随机函数生成食物
        public Label display()
        {
            int x, y;//表示食物点的坐标
            x = food.Next(20);
            y = food.Next(30);
            Label lb = new Label();
            lb.BackColor = Color.Red;
            lb.AutoSize = false;
            lb.Size = new Size(10, 10);
            lb.Text = "";
            lb.Location = new Point(x * 10, y * 10);
            this.Controls.Add(lb);
            return lb;
        }

        private void Food_Load(object sender, EventArgs e)
        {

        }
    }
}
