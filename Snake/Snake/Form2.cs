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
        string key = "start";//记录键盘状态
        Label[] labels = new Label[3000];//贪吃蛇身体数组
        Timer dt = new Timer();
        Random R = new Random();//随机数,用于生成食物
        int a = 0, b = 0;// 记录坐标
        /// <summary>
        /// 测试的内容，后期不需要
        /// </summary>
        //private void label1_Click(object sender, EventArgs e)
        //{
        //    label1.Text = "游戏正在进行中";
        //}

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
