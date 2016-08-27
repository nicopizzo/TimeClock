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
using TimeClock.Data;

namespace TimeClock.GUI
{
    public partial class EmployeeSelectionForm : Form
    {
        private TimeClockProc _timeClock;
        private EmployeeInfo _selectedEmployee;

        public EmployeeSelectionForm(TimeClockProc procs)
        {
            InitializeComponent();
            _timeClock = procs;
        }

        private void EmployeeSelectionForm_Load(object sender, EventArgs e)
        {
            ddlUser.DataSource = _timeClock.GetAllEmployees();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var selected = (EmployeeInfo)ddlUser.SelectedItem;
            if(selected == null)
            {
                this.ShowErrorMessage("Please select a user.");
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
