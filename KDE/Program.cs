using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SecureApp;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Drawing.Printing;

namespace KDE
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
            //string abc = @"Software\Tanmay\Protection";
            //Secure scr = new Secure();
            //bool logic = scr.Algorithm("skD@85-dfLj$598-ldkf%Jo5-654&654D", abc);
            //if (logic == true)
            //{
            Application.Run(new Login());
            //}
        }
    }
}
