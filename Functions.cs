using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using System.Windows.Threading;

namespace WPFRenamer_1 {
    public partial class MainWindow : Window {
        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e) {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());

        }
        private DirectoryInfo currDir;
        private bool check = true;
        private bool OK;
        private void ProcessDirectory(DirectoryInfo newDir) {
                foreach(DirectoryInfo d in newDir.GetDirectories()) {
                    Thread.Sleep(1);
                   while(check) {
                    Dispatcher.Invoke(() =>
                        resultBox.AppendText(newDir.FullName + "\n"));
                        foreach(FileInfo f in newDir.GetFiles()) {
                            Thread.Sleep(1);
                        Dispatcher.Invoke(() =>
                            resultBox.AppendText(f.Name + "\n"));

                        if(Dispatcher.Invoke(() => TemplateBox.Text == "")) {
                                continue;
                            }
                            else if(f.Name.Contains(Dispatcher.Invoke(() => TemplateBox.Text))) {
                                string sf = f.FullName.Remove(f.FullName.LastIndexOf(Dispatcher.Invoke(() => TemplateBox.Text)),
                                                            Dispatcher.Invoke(() => TemplateBox.Text.Length));
                                if(File.Exists(sf)) {
                                    sf = sf.Insert(sf.LastIndexOf('.'), "(ex)");
                                    File.Move(f.FullName, sf);
                                }
                                else
                                    File.Move(f.FullName, sf);
                            }
                        Dispatcher.Invoke(() =>
                            resultBox.ScrollToEnd());
                        }
                    check = false;
                    }
                Dispatcher.Invoke(() =>
                    resultBox.AppendText(d.FullName + "\n"));
                    foreach(FileInfo f in d.GetFiles()) {
                        Thread.Sleep(1);
                    Dispatcher.Invoke(() =>
                        resultBox.AppendText("------Sub file: " + f.Name + "\n"));
                        if(Dispatcher.Invoke(() => TemplateBox.Text == "")) {
                            continue;
                        }
                        else if(f.Name.Contains(Dispatcher.Invoke(() => TemplateBox.Text))) {
                            string sf = f.FullName.Remove(f.FullName.LastIndexOf(Dispatcher.Invoke(() => TemplateBox.Text)),
                                                            Dispatcher.Invoke(() => TemplateBox.Text.Length));
                        OK = true;
                            while(OK) {
                            if(File.Exists(sf)) {
                                sf = sf.Insert(sf.LastIndexOf('.'), "(ex)");
                                if(File.Exists(sf))
                                    continue;
                                else {
                                    File.Move(f.FullName, sf);
                                    OK = false;
                                }
                            }
                            else {
                                File.Move(f.FullName, sf);
                                OK = false;
                            }
                            }
                        }
                    Dispatcher.Invoke(() =>
                        resultBox.ScrollToEnd());
                    }
                ProcessDirectory(d);
                    if(Dispatcher.Invoke(() => TemplateBox.Text == ""))
                        continue;
                    else if(d.Name.Contains(Dispatcher.Invoke(() => TemplateBox.Text))) {

                        string s = d.FullName.Remove(d.FullName.LastIndexOf(Dispatcher.Invoke(() => TemplateBox.Text)),
                                                    Dispatcher.Invoke(() => TemplateBox.Text.Length));
                        if(Directory.Exists(s)) {
                            s += "(ex)";
                            Directory.Move(d.FullName, s);
                        }
                        else
                            Directory.Move(d.FullName, s);
                    }
                Dispatcher.Invoke(() =>
                    resultBox.ScrollToEnd());
                }
           
        }
    }
}
