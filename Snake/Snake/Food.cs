using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Food
    {
        //位置
        private Point _origin;
        private static int unit = 1;
        //场地长
        private int length = unit * 80;
        //场地宽
        private int width = unit *60;

        
        public Point Origin{
            get{return _origin;}
            set{_origin = value;}
        }


        //显示食物
        public void Display(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush,_origin.X,_origin.Y,1,1);
        }
        //食物消失
         public void UnDisplay(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);  //背景色
            g.FillRectangle(brush,_origin.X,_origin.Y,1,1);
        }
        //产生随机食物
        public Food RandomFood()
        {
            Random random = new Random();
            int x = random.Next(length/unit-2)+1;
            int y = random.Next(width/unit-2)+1;
            Point d = new Point();
            Food f = new Food();
            f.Origin = d;
            return f;
        }
        //显示新食物
        public void DisplayFood(Graphics g)
        {
            Food food = new Food();
            food.UnDisplay(g);
            food.RandomFood();
            food.Display(g);
        }
    }
}
