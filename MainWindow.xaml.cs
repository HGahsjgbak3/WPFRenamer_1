using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
namespace WPFRenamer_1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private System.Windows.Forms.FolderBrowserDialog dialog;
        public MainWindow() {
            InitializeComponent();
            dialog = new System.Windows.Forms.FolderBrowserDialog();
            TemplateBox.GotFocus += new RoutedEventHandler(Template_OnClick);
            Browse.Click += new RoutedEventHandler(Browse_OnClick);
            GO.Click += new RoutedEventHandler(GO_OnClick);
        }
        public void Template_OnClick(Object sender, EventArgs e) {
                TemplateBox.Text = "";
        }
        public void Browse_OnClick(Object sender, EventArgs e) {
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                PathBox.Text = dialog.SelectedPath;
            }
        }
        public void GO_OnClick(Object sender, EventArgs e) {
            new Thread(o => ProcessDirectory(Dispatcher.Invoke(() => currDir = new DirectoryInfo(PathBox.Text)))).Start();
        }
    }
}
