using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.BatchQC.Controllers;
using Toxikon.BatchQC.Models;
using Toxikon.BatchQC.Views.Forms;

namespace Toxikon.BatchQC
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

            LoginInfo loginInfo = LoginInfo.GetInstance();
            if(loginInfo.UserName == "")
            {
                MessageBox.Show("Access is denied.");
            }
            else
            {
                MainView mainView = new MainView();
                MainController mainController = new MainController(mainView);
                mainController.LoadView();

                Application.Run(mainView);
            }
        }
    }
}
