using System;
using System.Windows.Forms;
using TimeClock;
using TimeClock.Reporting;

namespace TimeClock.GUI.Reporting
{
    public partial class ReportingWizard : Form
    {

        public ReportingWizard()
        {
            InitializeComponent();
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
            
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateControls(ReportingWizardTabPages currentPage)
        {

        }
    }

    public enum ReportingWizardTabPages
    {
        MainPage = 0,
        PayReport = 1,
        OtherReport = 2
    }
}
