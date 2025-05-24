using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterGen
{
    public partial class CharacterGen : Form
    {
        public CharacterGen()
        {
            InitializeComponent();
        }

        async void FormLoad(object sender, EventArgs e)
        {
            await webViewDisplay.EnsureCoreWebView2Async(null);
        }
    }
}
