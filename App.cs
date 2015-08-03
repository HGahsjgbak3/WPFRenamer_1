using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading;
namespace WPFRenamer_1 {
    public class App : Application {
        [STAThread]
        static void Main(string[] args) {
            App app = new App();
            app.StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);
            app.Run();
        }
    }
}
