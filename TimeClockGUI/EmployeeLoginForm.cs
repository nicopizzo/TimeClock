using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeClock;
using TimeClockData;

namespace TimeClockGUI
{
    public partial class EmployeeLoginForm : Form
    {
        private TimeClockProc _Procs;
        private int? _selectedId;
        private bool _IsClockInCommand;

        

        public EmployeeLoginForm(TimeClockProc procs, int? empId)
        {
            InitializeComponent();
            _Procs = procs;
            _selectedId = empId;
            _IsClockInCommand = !empId.HasValue;
        }

        private void EmployeeLoginForm_Load(object sender, EventArgs e)
        {
            SetupForm();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = (int)((ComboBoxItem)cmbEmployee.SelectedItem).Value;
            string pass = txtPassword.Text.Trim();
            if(_Procs.VerifyEmployeePassword(id, pass))
            {
                bool status = false;
                // do clock command
                if (_IsClockInCommand)
                {
                    status = _Procs.ClockInEmployee(id);
                }
                else
                {
                    status = _Procs.ClockOutEmployee(id);
                }            
                this.Close();
                if (status)
                {
                    MessageBox.Show("Successfully " + (_IsClockInCommand ? GUIConstants.CONFIRMINMESSAGE : GUIConstants.CONFIRMOUTMESSAGE) + " employee", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to " + (_IsClockInCommand ? GUIConstants.CONFIRMINMESSAGE : GUIConstants.CONFIRMOUTMESSAGE) + " employee", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid Name/Password Combination", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetupForm()
        {
            try
            {
                if (!_IsClockInCommand)
                {
                    // we have a selected employee
                    EmployeeInfo emp = _Procs.SearchEmployee(_selectedId.Value);
                    cmbEmployee.Items.Add(CovertEmployeeToComboBoxItem(emp));
                    cmbEmployee.SelectedIndex = 0;
                    cmbEmployee.Enabled = false;
                }
                else
                {
                    List<EmployeeInfo> emps = _Procs.GetClockedOutEmployees();
                    foreach (EmployeeInfo emp in emps)
                    {
                        cmbEmployee.Items.Add(CovertEmployeeToComboBoxItem(emp));
                    }
                }
            }
            catch(Exception ex)
            {
                this.ShowErrorMessage(ex.ToString());
            }
        }
            

        private ComboBoxItem CovertEmployeeToComboBoxItem(EmployeeInfo employee)
        {
            ComboBoxItem item = new ComboBoxItem();
            item.Text = $"{employee.FirstName} {employee.LastName}";
            item.Value = employee.EmployeeId;
            return item;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(sender, e);
            }
        }
    }
}
