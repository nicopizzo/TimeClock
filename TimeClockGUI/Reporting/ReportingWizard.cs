using System;
using System.Windows.Forms;
using TimeClock;

namespace TimeClockGUI.Reporting
{
    public partial class ReportingWizard : Form
    {
        private TimeClockProc _timeClock { get; }

        public ReportingWizard(TimeClockProc timeClockProcs)
        {
            InitializeComponent();
            _timeClock = timeClockProcs;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
