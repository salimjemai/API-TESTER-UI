using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace API_TESTER_UI
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            // Your initialization code here...

            var app = new API_TESTER_UI.App();
            app.InitializeComponent();
            Database.DatabaseHelper.InitializeDatabase();
            app.Run();
        }
    }
}
