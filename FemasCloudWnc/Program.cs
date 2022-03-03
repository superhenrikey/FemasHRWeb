using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FemasCloudWnc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (FemasHelper.CheckHoliday())
                Environment.Exit(0);
#if !DEBUG
            System.Threading.Thread.Sleep((new Random()).Next(1, 10) * 60000);
#endif
            Application.Run(new FemasCloudWnc());
        }
    }
}
