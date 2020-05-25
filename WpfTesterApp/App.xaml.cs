using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTesterApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            var result =
                (from arg in e.Args
                where arg.Equals("/kingmode", StringComparison.OrdinalIgnoreCase)
                select arg).FirstOrDefault();
            this.Properties["KingMode"] = string.IsNullOrEmpty(result) ? false : true;
                
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            
        }
    }
}
