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
    public partial class ReportingSelection : Form
    {
        private TimeClockProc _timeClockProcs;

        public ReportingSelection(TimeClockProc timeClockProcs)
        {
            InitializeComponent();
            _timeClockProcs = timeClockProcs;
        }

    }
}
