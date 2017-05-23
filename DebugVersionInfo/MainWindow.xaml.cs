using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DebugVersionInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog OFD = new Microsoft.Win32.OpenFileDialog();
            if (OFD.ShowDialog() == true)
            {
                textBox.Text = OFD.FileName;

                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(textBox.Text);

                if (fvi.IsDebug)
                {
                    System.Windows.MessageBox.Show("DEBUG MODULE");
                    return;
                }

                try
                {
                    object[] attributes = Assembly.LoadFile(textBox.Text).GetCustomAttributes(typeof(DebuggableAttribute), true);
                    if ((attributes != null) && (attributes.Length > 0))
                    {
                        DebuggableAttribute att = attributes[0] as DebuggableAttribute;
                        if (att.DebuggingFlags > DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)
                            System.Windows.MessageBox.Show("DEBUG MODULE");
                        else
                            System.Windows.MessageBox.Show("RELEASE MODULE");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("RELEASE MODULE");
                    }
                }
                catch(Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
