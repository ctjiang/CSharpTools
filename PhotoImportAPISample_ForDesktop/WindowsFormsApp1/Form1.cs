using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.Import;
using Windows.UI.Xaml.Controls;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Windows.Foundation.IAsyncOperation<IReadOnlyCollection<PhotoImportSource>> 
            var sources = await PhotoImportManager.FindAllSourcesAsync();
            
            foreach (PhotoImportSource source in sources)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = source.DisplayName;
                item.Tag = source;
                sourceCB.Items.Add(item);
            }

        }
    }
}
