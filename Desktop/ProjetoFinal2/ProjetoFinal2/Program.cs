using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProjetoFinal2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmSplashScreen frmSplash = new frmSplashScreen();
            frmSplash.Show();
            Application.DoEvents();
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            frmSplash.Dispose();
            
            /*frmLogin frmLogin = new frmLogin();
            frmLogin.Show();*/

            /*Application.Run(frmLogin);*/
            Application.Run(new frmMenu());
        }
    }
}
