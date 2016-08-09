using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeClock;

namespace TimeClockGUI
{
    public partial class EmployeeSelectionForm : Form
    {
        private TimeClockProc _timeClock;

        public EmployeeSelectionForm(TimeClockProc procs)
        {
            InitializeComponent();
            _timeClock = procs;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
