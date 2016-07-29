using System;
using System.Windows.Forms;
using TimeClock;
using TimeClock.Helpers;
using TimeClockData;


namespace TimeClockGUI
{
    public partial class AddEmployeeForm : Form
    {
        private TimeClockProc _timeClock;
        private string _mode;
        private int? _id;
        private EmployeeInfo _loadedEmployee;

        public AddEmployeeForm(TimeClockProc procs, string mode, int? id = null)
        {
            InitializeComponent();
            _timeClock = procs;
            _mode = mode;
            _id = id;     
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case GUIConstants.MODE_ADD:
                    this.Text = "Add Employee";
                    break;

                case GUIConstants.MODE_EDIT:
                    this.Text = "Edit Employee";
                    if (_id.HasValue)
                    {
                        LoadEmployee(_id.Value);
                    }
                    DisableControls();
                    break;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // do submission        
            switch (_mode)
            {
                case "Add":
                    ExecuteAddEmployee();
                    break;

                case "Edit":
                    ExecuteEditEmployee();
                    break;
            }          
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisableControls()
        {
            this.txtFirstName.Enabled = false;
            this.txtLastName.Enabled = false;
            this.txtPay.Enabled = false;
            this.chkIsSalary.Enabled = false;
            this.dtDOB.Enabled = false;
        }

        private void ExecuteAddEmployee()
        {
            DateTime dob = DateTime.Parse(dtDOB.Text);
            decimal pay = ConvertStringPay(txtPay.Text);
            EmployeeInfo employee = ModelGeneration.GenerateEmployeeModel(txtFirstName.Text, txtLastName.Text, dob, txtPhone.Text, pay, chkIsSalary.Checked, true, txtPassword.Text, txtPosition.Text, true);
            if (_timeClock.ProcessEmployee(employee))
            {
                MessageBox.Show("Employee was added", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Employee was not added!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteEditEmployee()
        {
            decimal pay = ConvertStringPay(txtPay.Text);
            _loadedEmployee.PhoneNumber = txtPhone.Text;
            _loadedEmployee.Password = txtPassword.Text;
            _loadedEmployee.IsSalary = chkIsSalary.Checked;
            _loadedEmployee.Position = txtPosition.Text;
            if (_timeClock.ProcessEmployee(_loadedEmployee))
            {
                MessageBox.Show("Employee was updated", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Employee was not updated!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployee(int id)
        {
            _loadedEmployee = _timeClock.SearchEmployee(id);
            this.txtFirstName.Text = _loadedEmployee.FirstName;
            this.txtLastName.Text = _loadedEmployee.LastName;
            this.txtPay.Text = _loadedEmployee.Pay.ToString();
            this.dtDOB.Text = _loadedEmployee.DOB.ToString("MM/dd/yyyy");
            this.chkIsSalary.Checked = _loadedEmployee.IsSalary.Value;
            this.txtPhone.Text = _loadedEmployee.PhoneNumber;
            this.txtPassword.Text = _loadedEmployee.Password;
            this.txtPosition.Text = _loadedEmployee.Position;
        }

        private decimal ConvertStringPay(string rawString)
        {
            rawString = rawString.Replace(" ", "").Replace("$", "").Trim();
            return Convert.ToDecimal(rawString);
        }
        
    }
}
