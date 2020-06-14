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

    public partial class Form1 : Form
    {
        string key = "start";//记录键盘状态
        Label[] labels = new Label[3000];//贪吃蛇身体数组

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
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
            //dt.Tick += new EventHandler(dt_Tick);
            //键盘敲击事件
            //this.KeyDown += new KeyEventHandler(form_keyDown);
            dt.Start();//timer开始计时
        }    
    }
}
