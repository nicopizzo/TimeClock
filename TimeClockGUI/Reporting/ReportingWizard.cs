using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeClock;
using TimeClock.Reporting;
using TimeClock.Reporting.Converters;

namespace TimeClock.GUI.Reporting
{
    public partial class ReportingWizard : Form
    {

        private TimeClockProc _timeClock;

        public ReportingWizard(TimeClockProc procs)
        {
            InitializeComponent();
            _timeClock = procs;
            UpdateControls(ReportingWizardTabPages.MainPage);
        }

        private ReportingWizardTabPages GetNextPage(ReportingWizardTabPages currentPage)
        {
            var nextPage = ReportingWizardTabPages.MainPage;

            switch (currentPage)
            {
                case ReportingWizardTabPages.MainPage:
                    if (rdoPayReport.Checked)
                    {
                        nextPage = ReportingWizardTabPages.PayReport;
                    }
                    else if (rdoOtherReport.Checked)
                    {
                        nextPage = ReportingWizardTabPages.OtherReport;
                    }
                    break;

                case ReportingWizardTabPages.PayReport:

                    break;
            }

            return nextPage;
        }

        private ReportingWizardTabPages GetPreviousPage(ReportingWizardTabPages currentPage)
        {
            var previousPage = ReportingWizardTabPages.MainPage;

            switch (currentPage)
            {
                case ReportingWizardTabPages.PayReport:
                case ReportingWizardTabPages.OtherReport:
                    previousPage = ReportingWizardTabPages.MainPage;
                    break;
            }

            return previousPage;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var selectedTab = (ReportingWizardTabPages)wizardPages1.SelectedIndex;
            var nextTab = GetNextPage(selectedTab);
            wizardPages1.SelectedIndex = (int)nextTab;
            UpdateControls(nextTab);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            var selectedTab = (ReportingWizardTabPages)wizardPages1.SelectedIndex;
            var prevTab = GetPreviousPage(selectedTab);
            wizardPages1.SelectedIndex = (int)prevTab;
            UpdateControls(prevTab);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            IConverter converter = new HTMLReportConverter();
            IReport report = new PayReport(_timeClock.Company);
            report.GenerateReport(new List<int>() { 2 }, DateTime.MinValue, DateTime.MaxValue);
            var reportLoc = report.ConvertReport(converter);
            var htmlviewer = new HTMLViewer(reportLoc);
            htmlviewer.Show();
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateControls(ReportingWizardTabPages currentPage)
        {
            switch (currentPage)
            {
                case ReportingWizardTabPages.MainPage:
                default:
                    btnPrevious.Enabled = false;
                    btnFinish.Enabled = false;
                    btnNext.Enabled = true;
                    break;

                case ReportingWizardTabPages.PayReport:
                    btnPrevious.Enabled = true;
                    btnFinish.Enabled = true;
                    btnNext.Enabled = false;
                    break;
            }
        }
    }

    public enum ReportingWizardTabPages
    {
        MainPage = 0,
        PayReport = 1,
        OtherReport = 2,
        EmployeeSelect = 3,
        OutputSelection = 4
    }
}
