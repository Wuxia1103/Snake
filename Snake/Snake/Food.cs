using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Food
{
    public Food()
    {
        //位置
        Point _origin;


        //     Point Origin
        //{
        //    get { return _origin; }
        //    set { _origin = value; }
        //}


        //显示食物
        void Display(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, _origin.X, _origin.Y, 1, 1);
        }
        //食物消失
        void UnDisplay(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);  //背景色
            g.FillRectangle(brush, _origin.X, _origin.Y, 1, 1);
        }
    }

}     
    //private static int unit = 1;
    ////场地长
    //private int length = unit * 1000;
    ////场地宽
    //private int width = unit * 500;


    
  


