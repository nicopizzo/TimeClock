﻿using System;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;
using TimeClock.DisplayModels;
using TimeClockGUI;


namespace TimeClock
{
    public partial class GUI : Form
    {
        private TimeClockProc _timeClock;
        private Thread _clockThread;
        private DateTime _currentTime;

        public GUI()
        {
            InitializeComponent();
            this.Text = $"Timeclock - {ConfigurationManager.AppSettings["CompanyName"]}";
            _timeClock = new TimeClockProc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _clockThread = new Thread(new ThreadStart(GetCurrentTimeAsync));
            _clockThread.IsBackground = true;
            _clockThread.Start();
            SetupClockedInEmployeesGrid();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddEmployeeForm form = new AddEmployeeForm(_timeClock, GUIConstants.MODE_ADD);
                form.ShowDialog();
                SetupClockedInEmployeesGrid();
            }
            catch(Exception ex)
            {
                this.ShowErrorMessage(ex.ToString());
            }         
        }

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReportingSelection reporting = new ReportingSelection(_timeClock);
                reporting.ShowDialog();
                SetupClockedInEmployeesGrid();
            }
            catch(Exception ex)
            {
                this.ShowErrorMessage(ex.ToString());
            }
        }

        private void modifyEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddEmployeeForm form = new AddEmployeeForm(_timeClock, GUIConstants.MODE_EDIT, 1);
                form.ShowDialog();
                SetupClockedInEmployeesGrid();
            }
            catch(Exception ex)
            {
                this.ShowErrorMessage(ex.ToString());
            }           
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeLoginForm form = new EmployeeLoginForm(_timeClock, null);
                form.ShowDialog();
                SetupClockedInEmployeesGrid();
            }
            catch(Exception ex)
            {
                this.ShowErrorMessage(ex.ToString());
            }          
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridEmployees.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Please select an employee to clockout", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    var employee = (ClockedInEmployeeGridModel)gridEmployees.SelectedRows[0].DataBoundItem;
                    EmployeeLoginForm form = new EmployeeLoginForm(_timeClock, employee.GetEmployeeId());
                    form.ShowDialog();
                    SetupClockedInEmployeesGrid();
                }
            }
            catch(Exception ex)
            {
                this.ShowErrorMessage(ex.ToString());
            }                     
        }

        private void SetupClockedInEmployeesGrid()
        {
            try
            {
                var source = new BindingSource()
                {
                    DataSource = _timeClock.GetClockedInEmployeesView()
                };
                gridEmployees.DataSource = source;
            }
            catch(Exception ex)
            {
                this.ShowErrorMessage(ex.ToString());
            }
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Clock Management
        private void GetCurrentTimeAsync()
        {
            ClockManagement clock = new ClockManagement();
            while (true)
            {
                try
                {
                    _currentTime = clock.GetInternetTime();
                }
                catch
                {
                    // popup with error?
                    _currentTime = clock.GetComputerTime();
                }
                SetDate(_currentTime.ToString("MM/dd/yyyy"));
                SetTime(_currentTime.ToString("hh:mm:ss tt"));
            }
        }

        private void SetDate(string date)
        {
            if (dateClock.InvokeRequired)
            {
                this.dateClock.BeginInvoke((MethodInvoker)delegate() { this.dateClock.Text = date; });
            }
            else
            {
                this.dateClock.Text = date;
            }
        }

        private void SetTime(string time)
        {
            if (timeClock.InvokeRequired)
            {
                this.timeClock.BeginInvoke((MethodInvoker)delegate() { this.timeClock.Text = time; });
            }
            else
            {
                this.timeClock.Text = time;
            }
        }

        #endregion
    }
}