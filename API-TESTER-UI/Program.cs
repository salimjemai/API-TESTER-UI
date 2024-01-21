using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_TESTER_UI.Utilities;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace API_TESTER_UI
{
    static class Program
    {
        //public static readonly log4net.ILog log = LogManager.GetLogger("MainLog");
        [STAThread]
        static void Main()
        {
            // Your initialization code here...

            Log.Info("Starting Api Tester Application {0}", "Main()");
            var app = new API_TESTER_UI.App();
            app.InitializeComponent();
            Log.Debug("Instantiating The Sqlite database {0}", "Main()");
            Database.DatabaseHelper.InitializeDatabase();
            app.Run();
        }
    }
}
