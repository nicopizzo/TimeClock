using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TimeClock.GUI.Reporting
{
    public partial class HTMLViewer : Form
    {
        public HTMLViewer(string url)
        {
            InitializeComponent();
            SetupStartUrl(url);
        }

        private void SetupStartUrl(string url)
        {
            if (File.Exists(url))
            {
                // local file
                url = $"file:///{url}";
            }
            this.webBrowser1.Url = new Uri(url);
        }
    }
}
