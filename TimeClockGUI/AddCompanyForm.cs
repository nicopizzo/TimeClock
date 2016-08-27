using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeClock;
using TimeClock.Helpers;
using TimeClock.Data;
using TimeClock.Security;
using System.Windows.Forms;

namespace TimeClock.GUI
{
    public partial class AddCompanyForm : Form
    {
        private Guid? _id;
        private TimeClockProc _timeClock;
        private string _mode;
        private Company _loadedCompany;

        public AddCompanyForm(TimeClockProc procs, string mode, Guid? companyId = null)
        {
            InitializeComponent();
            _timeClock = procs;
            _id = companyId;
            _mode = mode;
        }

        private void AddCompany_Load(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case GUIConstants.MODE_ADD:
                    this.Text = "Add Company";
                    break;

                case GUIConstants.MODE_EDIT:
                    this.Text = "Edit Company";
                    if (_id.HasValue)
                    {
                        LoadCompany(_id.Value);
                    }
                    DisableControls();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        private void DisableControls()
        {
            this.txtCompanyName.Enabled = false;
        }

        private void LoadCompany(Guid id)
        {
            _loadedCompany = _timeClock.GetCompany(id);
            this.txtCompanyName.Text = _loadedCompany.CompanyName;
            this.txtAddress.Text = _loadedCompany.Address;
            this.txtCity.Text = _loadedCompany.City;
            this.txtState.Text = _loadedCompany.State;
            this.txtZip.Text = _loadedCompany.Zip;
            this.txtPhone.Text = _loadedCompany.PhoneNumber;
            this.txtFax.Text = _loadedCompany.FaxNumber;
            this.txtWebsite.Text = _loadedCompany.Website;
        }

        private void txtSubmit_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case GUIConstants.MODE_ADD:
                    ExecuteAddCompany();
                    break;

                case GUIConstants.MODE_EDIT:
                    ExecuteModifyCompany();
                    break;

                default:
                    throw new NotSupportedException();
            }
            this.Close();
        }

        private void ExecuteAddCompany()
        {
            Company company = ModelGeneration.GenerateCompanyModel(txtCompanyName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text, txtFax.Text, txtWebsite.Text, txtPassword.Text);
            if (_timeClock.ProcessCompany(company))
            {
                _timeClock.SaveCompanyGuid(company.CompanyId);
                MessageBox.Show("Company was added", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Company was not added!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteModifyCompany()
        {
            _loadedCompany.Address = txtAddress.Text;
            _loadedCompany.City = txtCity.Text;
            _loadedCompany.State = txtState.Text;
            _loadedCompany.Zip = txtZip.Text;
            _loadedCompany.PhoneNumber = txtPhone.Text;
            _loadedCompany.FaxNumber = txtFax.Text;
            _loadedCompany.Website = txtWebsite.Text;

            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                _loadedCompany.CompanyPassword = UserSecurity.CreateHash(txtPassword.Text);
            }

            if (_timeClock.ProcessCompany(_loadedCompany))
            {
                MessageBox.Show("Company was updated", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Company was not updated!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }
}
