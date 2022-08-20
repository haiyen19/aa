using StudentManagement.UserService;
using StudentService.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.Extendsion;

namespace StudentManagement
{
    public partial class FrmLogin : Form
    {
        private readonly UserServiceClient _userServiceClient;
        public SendLogin send;
        public FrmLogin(SendLogin sender)
        {
            InitializeComponent();
            _userServiceClient = new UserServiceClient();
            this.send = sender;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if(txtUsername.Text.Length == 0)
            {
                labelRequiredUserName.Visible = true;
            }
            else
            {
                labelRequiredUserName.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                labelRequiredPassword.Visible = true;
            }
            else
            {
                labelRequiredPassword.Visible = false;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                labelRequiredUserName.Visible = true;
            }
            if (txtPassword.Text.Length == 0)
            {
                labelRequiredPassword.Visible = true;
            }

            if(txtUsername.Text.Length != 0 && txtPassword.Text.Length!= 0)
            {
                var request = new LoginRequest()
                {
                    UserName = txtUsername.Text,
                    Password = Extendsion.Extendsion.GetMD5(txtPassword.Text)
                };
                var response = await _userServiceClient.LoginAsync(request);
                if(!response.Success)
                {
                    MessageBox.Show(response.Message);
                }
                else
                {
                    this.Close();
                    this.send(response.Data.FullName, response.Data.UserType,response.Data.Id);
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
