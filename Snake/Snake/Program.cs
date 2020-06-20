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
            Application.Run(new Form3());
            //简单模式
            //if (form3.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new BejinEasy());
            //}
            //高级模式
            //if (form3.ShowDialog() == DialogResult.Yes)
            //{
            //    Application.Run(new BejinEasy());
            //}


            

        }
    }
}
