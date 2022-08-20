using StudentManagement.ClassService;
using StudentManagement.CourseService;
using StudentManagement.FacutlyService;
using StudentManagement.UserService;
using StudentService.Model;
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

namespace StudentManagement
{
    public partial class FrmStudentManagement : Form
    {
        private readonly CourseServiceClient _courseService;
        private readonly FacutlyServiceClient _facutlyService;
        private readonly ClassServiceClient _classServiceClient;
        private readonly UserServiceClient _userServiceClient;
        private static int? IdStudent = null;
        private static int pageIndex;
        private static double Total_Page;
        private static int pageSize;
        private static string ImageLocation;
        private static byte[] ByteAvatar;
        public FrmStudentManagement()
        {
            InitializeComponent();
            _courseService = new CourseServiceClient();
            _facutlyService = new FacutlyServiceClient();
            _userServiceClient = new UserServiceClient();
            _classServiceClient = new ClassServiceClient();
            pageIndex = 1;
            pageSize = 18;
            Total_Page = 0;
        }

        private async void FrmStudentManagement_Load(object sender, EventArgs e)
        {
            var SourceClass= await _classServiceClient.ClassJonCourseJoinFacultyAsync();

            var TableClassForm = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<IdAndNameModel>(SourceClass.Data.ToList());
            var TableClassFilter = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<IdAndNameModel>(SourceClass.Data.ToList());


            DataRow DefaultSelectForm = TableClassFilter.NewRow();
            DefaultSelectForm[0] = DBNull.Value;
            DefaultSelectForm[1] = "== Tất cả sinh viên ==";

            TableClassFilter.Rows.InsertAt(DefaultSelectForm, 0);


            cbboxClassForm.DataSource = TableClassForm;
            cbboxClassForm.DisplayMember = "Name";
            cbboxClassForm.ValueMember = "Id";

            cbboxFilterStudent.DataSource = TableClassFilter;
            cbboxFilterStudent.DisplayMember = "Name";
            cbboxFilterStudent.ValueMember = "Id";

            cbboxGender.Text = "Nam";

            PaginationStudent();
        }

        private void CreateModel()
        {
            IdStudent = null;
            txtName.Text = null;
            txtIdCard.Text = null;
            txtEmail.Text = null;
            txtAddress.Text = null;
            txtPassword.Text = null;
            txtRePassword.Text = null;
            txtUserName.Text = null;
            txtPhone.Text = null;
            CheckboxActive.Checked = false;
            ImageLocation = null;
            Avatar.Image = null;
            btnDelete.Visible = false;
            BtnCreate.Visible = false;
            txtPassword.Enabled = true;
            txtRePassword.Enabled = true;
            txtUserName.Enabled = true;
            ByteAvatar = null;
        }


        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateModel();
            BtnCreate.Visible = false;
            btnDelete.Visible = false;
        }

        private async void PaginationStudent()
        {
            var request = new UserPaginationRequest();
            request.pageIndex = pageIndex;
            request.pageSize = pageSize;
            request.TypeUser = (int)Globals.TypeUser.Student;
            request.FacultyId = null;
            if (cbboxFilterStudent.SelectedValue == System.DBNull.Value || cbboxFilterStudent.SelectedValue == null)
            {
                request.ClassId = null;
            }
            else
            {
                request.ClassId = (int)cbboxFilterStudent.SelectedValue;
            }
            request.NameSearch = txtSearch.Text.Length == 0 ? null : txtSearch.Text.Trim();



            var result = await _userServiceClient.UsersAsync(request);
            if (!result.Success)
            {
                MessageBox.Show("Có lỗi");
            }
            else
            {
                //Fill Data Return to DataGrid , Remove Column Total
                GridStudent.DataSource = result.Data.Select(c => new {
                    Id = c.Id,
                    FullName = c.FullName,
                    Gender = c.Gender,
                    Phone = c.Phone,
                    DayOfBirth = c.DayOfBirth
                }).ToList();

                //Get pagination result (Current page & Total page)
                var pagination = Extendsion.Extendsion.Pagination<UserViewModel>(result.Data.ToList(), request);

                //Set globals Total page
                Total_Page = pagination.TotalPage;

                //Set Display pagination UI
                LblPageIndex.Text = pageIndex + " / " + Total_Page;

                //if else ..
                if (pageIndex == 1) // you are stay top page
                {
                    btnBackpage.Enabled = false;
                    btnBeginPage.Enabled = false;
                }
                else
                {
                    btnBackpage.Enabled = true;
                    btnBeginPage.Enabled = true;
                }

                if (pageIndex == Total_Page) // you are stay last page
                {
                    BtnNextPage.Enabled = false;
                    BtnEndPage.Enabled = false;
                }
                else
                {
                    BtnNextPage.Enabled = true;
                    BtnEndPage.Enabled = true;
                }

                if (Total_Page == 0 && pageIndex > 0)
                {
                    if (pageIndex == 1)
                    {
                        return;
                    }
                    else
                    {
                        pageIndex--;
                        PaginationStudent();
                    }
                }

            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (IdStudent == null)
            {
                MessageBox.Show("Không có đối tượng cần xóa");
            }
            else
            {
                var result = await _userServiceClient.DeleteAsync((int)IdStudent);
                MessageBox.Show(result.Message);
                PaginationStudent();
                CreateModel();
            }
        }

        private bool ValidateStudent()
        {
            if (txtName.Text.Length == 0 || txtUserName.Text.Length ==0 || txtPassword.Text.Length == 0 || txtRePassword.Text.Length == 0 || txtPassword.Text != txtRePassword.Text)
            {
                if (txtName.Text.Length == 0)
                {
                    labelRequiredName.Visible = true;
                }
                else
                {
                    labelRequiredName.Visible = false;
                }
                if(txtUserName.Text.Length == 0)
                {
                    lblRequiredUserName.Visible = true;
                }
                else
                {
                    lblRequiredUserName.Visible = false;
                }
                if (txtPassword.Text.Length == 0)
                {
                    lblRequiredPassword.Visible = true;
                }
                else
                {
                    lblRequiredPassword.Visible = false;
                }
                if (txtRePassword.Text.Length == 0)
                {
                    lblRequiredRePassword.Visible = true;
                }
                else
                {
                    lblRequiredRePassword.Visible = false;
                }
                if(txtPassword.Text != txtRePassword.Text)
                {
                    lblRequiredRePassword.Visible = true;
                }
                else
                {
                    lblRequiredRePassword.Visible = false;
                }
                return false;
            }
            labelRequiredName.Visible = false;
            lblRequiredPassword.Visible = false;
            lblRequiredUserName.Visible = false;
            lblRequiredRePassword.Visible = false;
            return true;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateStudent() == false)
            {
                return;
            }
            else
            {
                var request = new User()
                {
                    Id = IdStudent,
                    FullName = txtName.Text,
                    Gender = cbboxGender.Text,
                    IdCard = txtIdCard.Text,
                    Email = txtEmail.Text,
                    Address =txtAddress.Text,
                    Phone = txtPhone.Text,
                    UserLogin = txtUserName.Text,
                    Password = Extendsion.Extendsion.GetMD5(txtPassword.Text),
                    DayOfBirth = dateTimeDayofBirth.Value,
                    UserType = (int)Globals.TypeUser.Student,
                    ClassId = (int)cbboxClassForm.SelectedValue,
                    FacultyId = null,
                    Active = CheckboxActive.Checked,
                    Avatar = ImageLocation == null ? ByteAvatar : Extendsion.Extendsion.ByteForImage(ImageLocation)
                };
                var result = await _userServiceClient.SaveAsync(request);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                    CreateModel();
                    PaginationStudent();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PaginationStudent();
        }

        private void btnBeginPage_Click(object sender, EventArgs e)
        {
            if (Total_Page == 0)
            {
                return;
            };
            if (pageIndex == 1)
            {
                MessageBox.Show("Bạn đang ở trang đầu tiên");
            }
            else
            {
                pageIndex = 1;
                PaginationStudent();
            }
        }

        private void btnBackpage_Click(object sender, EventArgs e)
        {
            if (Total_Page == 0)
            {
                return;
            };
            if (pageIndex == 1)
            {
                MessageBox.Show("Bạn đang ở trang đầu tiên");
            }
            else
            {
                pageIndex--;
                PaginationStudent();
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (Total_Page == 0)
            {
                return;
            };
            if (pageIndex == Total_Page)
            {
                MessageBox.Show("Bạn đang ở trang cuối cùng");
            }
            else
            {
                pageIndex++;
                PaginationStudent();
            }
        }

        private void BtnEndPage_Click(object sender, EventArgs e)
        {
            if (Total_Page == 0)
            {
                return;
            };
            if (pageIndex == Total_Page)
            {
                MessageBox.Show("Bạn đang ở trang cuối cùng");
            }
            else
            {
                pageIndex = (int)Total_Page;
                PaginationStudent();
            }
        }

        private async void GridStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Entity = GridStudent.CurrentRow.Cells["Id"].Value.ToString();
            var result = await _userServiceClient.UserAsync(int.Parse(Entity));

            if (result.Data != null)
            {
                IdStudent = result.Data.Id;
                txtName.Text = result.Data.FullName;
                txtAddress.Text = result.Data.Address;
                txtEmail.Text = result.Data.Email;
                txtIdCard.Text = result.Data.Email;
                txtUserName.Text = result.Data.UserLogin;
                cbboxGender.Text = result.Data.Gender;
                dateTimeDayofBirth.Value = result.Data.DayOfBirth;
                cbboxClassForm.SelectedValue = result.Data.ClassId;
                txtPhone.Text = result.Data.Phone;
                txtPassword.Text = result.Data.Password;
                txtRePassword.Text = result.Data.Password;
                txtPassword.Enabled = false;
                txtRePassword.Enabled = false;
                txtUserName.Enabled = false;
                CheckboxActive.Checked = result.Data.Active;
                Extendsion.Extendsion.SetImage(result.Data.Avatar, ref Avatar);
                ByteAvatar = result.Data.Avatar;
                BtnCreate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Extendsion.Extendsion.ImageLocation(ref ImageLocation, ref Avatar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbboxFilterStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = cbboxFilterStudent.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {
                return;
            }
            pageIndex = 1;
            PaginationStudent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ValidateStudent();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            ValidateStudent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateStudent();
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            ValidateStudent();
        }

        private void GridStudent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridStudent.ClearSelection();
        }
    }
}
