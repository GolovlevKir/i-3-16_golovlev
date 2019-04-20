using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ortoped_Store
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Autoriz());
        }
        public static string Log;
        public static int acc = 0, Prof = 0, Cli = 0, Sot = 0, Vid = 0, Fir = 0, Col = 0,
            Pol = 0, Tov = 0, Skl = 0, Pri = 0, Che = 0, System_Access = 0;
    }
}
