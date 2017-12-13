using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Import;

namespace ImportPhoto
{
    public sealed class Class1
    {
        private async void button1_Click(object sender, EventArgs e)
        {
            //Windows.Foundation.IAsyncOperation<IReadOnlyCollection<PhotoImportSource>> 
            var sources = await PhotoImportManager.FindAllSourcesAsync();


        }
    }
}
