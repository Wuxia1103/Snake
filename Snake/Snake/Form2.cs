using System;
using System.Drawing;
using System.Windows.Forms;


namespace Snake
{
    public partial class Form2 : Form
    {
        string key = "start";//记录键盘状态
        static Label[] labels = new Label[3000];//贪吃蛇身体数组
        Timer dt = new Timer();
        static Random food = new Random();//随机数,用于生成食物
        int a = 0, b = 0;// 记录坐标
        private int speed;//速度



        public Form2()
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
            //贪吃蛇设置
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.Width = label.Height = 10;
                label.Top = 400;
                label.Left = 400;
                label.BackColor = Color.Black;
                //获取或设置包含有关控件的数据的对象。
                label.Tag = i;
                labels[i] = label;
                this.Controls.Add(label);
            }
            //控件timer,每隔一段时间发生一次右移
            dt.Tick += new EventHandler(dt_Tick);
            //键盘敲击事件
            this.KeyDown += new KeyEventHandler(form_keyDown);
            dt.Start();//timer开始计时
            display();
            //EatFood();
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
        //吃过食物，蛇的身体变长
        void Snake_eat()
        {
            int i = 0;
            for (; labels[i] != null; i++) ;
            Label lb = new Label();
            lb.Top = b;
            lb.Left = a;
            lb.BackColor = Color.Black;
            lb.Tag = i;
            labels[i] = lb;
            this.Controls.Add(lb);
        }
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
        //判断是否吃到食物以及吃到食物后的反应
        void EatFood()
        {
            foreach (Label lb1 in this.Controls)
            {
                if (lb1.BackColor == Color.Red)
                {
                    if (lb1.Location == labels[0].Location)
                    {
                        this.Controls.Remove(lb1);
                        display();
                    }
                }
            }
        }
        //设定速度
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 1: speed = 500; break;
                case 2: speed = 450; break;
                case 3: speed = 400; break;
                case 4: speed = 350; break;
                case 5: speed = 300; break;
                case 6: speed = 250; break;
                case 7: speed = 200; break;
                case 8: speed = 150; break;
                case 9: speed = 100; break;
            }
            this.timer1.Interval = speed;
        }

        

    }
}
