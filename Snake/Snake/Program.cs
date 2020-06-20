using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    static class Program
    {
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form2());
            //Form1 form1 = new Form1();
            Form3 form3 = new Form3();
            //Form2 form2 = new Form2();
            //Application.Run(new Form1());
            //简单模式
            if (form3.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            //if (form1.ShowDialog() == DialogResult.OK)
            //{
            //Application.Run(new Form2());
            //}
            //高级模式
            if (form3.ShowDialog() == DialogResult.Yes)
            {
                Application.Run(new Form1());
            }
            //if (form1.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new Form2());
                //form2.Show();
                //form1.Close();
            //}



        }
    }
}
