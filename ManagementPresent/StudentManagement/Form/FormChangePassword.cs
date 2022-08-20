using StudentManagement.UserService;
using StudentService.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class FormChangePassword : Form
    {
        private int? CurrentUser;
        private readonly UserServiceClient _userServiceClient;
        public FormChangePassword(int? currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            _userServiceClient = new UserServiceClient();
        }

        private bool ValidateForm()
        {
            if(txtNewPassword.Text.Length == 0 || txtOldPassword.Text.Length == 0 || txtReNewPassword.Text.Length == 0 || txtReNewPassword.Text != txtNewPassword.Text)
            {
                if(txtOldPassword.Text.Length == 0)
                {
                    labelRequiredOldPassword.Visible = true;
                }
                else
                {
                    labelRequiredOldPassword.Visible = false;
                }

                if(txtNewPassword.Text.Length == 0)
                {
                    labelRequiredNewPassword.Visible = true;
                }
                else
                {
                    labelRequiredNewPassword.Visible = false;
                }

                if (txtReNewPassword.Text != txtNewPassword.Text)
                {
                    lblRequiredReNewPassword.Visible = true;
                }
                else
                {
                    lblRequiredReNewPassword.Visible = false;
                }
                return false;
            }
            lblRequiredReNewPassword.Visible = false;
            labelRequiredNewPassword.Visible = false;
            labelRequiredOldPassword.Visible = false;
            return true;
        }

        private void createModel()
        {
            txtNewPassword.Text = null;
            txtReNewPassword.Text = null;
            txtOldPassword.Text = null;
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {

        }

        private async void btnchangePassword_Click(object sender, EventArgs e)
        {
            if(ValidateForm() == false)
            {
                return;
            }
            else
            {
                var request = new ChangePasswordRequest()
                {
                    Id = (int)CurrentUser,
                    OldPassword = Extendsion.Extendsion.GetMD5(txtOldPassword.Text),
                    NewPassword = Extendsion.Extendsion.GetMD5(txtNewPassword.Text)
                };

                var result = await _userServiceClient.ChangePasswordAsync(request);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                    createModel();
                }
                
            }
        }

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void txtReNewPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }
    }
}
