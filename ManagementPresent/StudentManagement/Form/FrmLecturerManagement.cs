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
    public partial class FrmLecturerManagement : Form
    {
        private readonly CourseServiceClient _courseService;
        private readonly FacutlyServiceClient _facutlyService;
        private readonly ClassServiceClient _classServiceClient;
        private readonly UserServiceClient _userServiceClient;
        private static int? IdLecture = null;
        private static int pageIndex;
        private static double Total_Page;
        private static int pageSize;
        private static string ImageLocation;
        private static byte[] ByteAvatar;


        public FrmLecturerManagement()
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


        private void CreateModel()
        {
            IdLecture = null;
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

        private async void FrmLecturerManagement_Load(object sender, EventArgs e)
        {
            var SourceFacutly = await _facutlyService.FacutlysAsync();

            var TableFacutlyForm = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Facutly>(SourceFacutly.Data.ToList());
            var TableFacutlyFilter = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Facutly>(SourceFacutly.Data.ToList());


            //DataRow DefaultSelectForm = TableFacutlyForm.NewRow();
            //DefaultSelectForm[0] = DBNull.Value;
            //DefaultSelectForm[1] = "== Chọn khoa đào tạo ==";
            DataRow DefaultSelectFilter = TableFacutlyFilter.NewRow();
            DefaultSelectFilter[0] = DBNull.Value;
            DefaultSelectFilter[1] = "== Tất cả khoa đào tạo ==";

            //TableFacutlyForm.Rows.InsertAt(DefaultSelectForm, 0);
            TableFacutlyFilter.Rows.InsertAt(DefaultSelectFilter, 0);

            cbboxGender.Text = "Nam";
            cbboxFacultyForm.DataSource = TableFacutlyForm;
            cbboxFacultyForm.DisplayMember = "Name";
            cbboxFacultyForm.ValueMember = "Id";

            cbboxFilterFaculty.DataSource = TableFacutlyFilter;
            cbboxFilterFaculty.DisplayMember = "Name";
            cbboxFilterFaculty.ValueMember = "Id";

            PaginationLecture();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateModel();
            BtnCreate.Visible = false;
            btnDelete.Visible = false;
        }


        private async void PaginationLecture()
        {
            var request = new UserPaginationRequest();
            request.pageIndex = pageIndex;
            request.pageSize = pageSize;
            request.TypeUser = (int)Globals.TypeUser.Lecturer;
            request.ClassId = null;
            if (cbboxFilterFaculty.SelectedValue == System.DBNull.Value || cbboxFilterFaculty.SelectedValue == null)
            {
                request.FacultyId = null;
            }
            else
            {
                request.FacultyId = (int)cbboxFilterFaculty.SelectedValue;
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
                GridLecture.DataSource = result.Data.Select(c => new {
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
                        PaginationLecture();
                    }
                }

            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (IdLecture == null)
            {
                MessageBox.Show("Không xác định được giảng viên cần xóa");
                return;
            }
            else
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Xóa giảng viên", "Delete ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    var result = await _userServiceClient.DeleteAsync((int)IdLecture);
                    CreateModel();
                    PaginationLecture();
                }
            }
        }

        private bool ValidateLecture()
        {
            if (txtName.Text.Length == 0 || txtUserName.Text.Length == 0 || txtPassword.Text.Length == 0 || txtRePassword.Text.Length == 0 || txtPassword.Text != txtRePassword.Text)
            {
                if (txtName.Text.Length == 0)
                {
                    labelRequiredName.Visible = true;
                }
                else
                {
                    labelRequiredName.Visible = false;
                }
                if (txtUserName.Text.Length == 0)
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
                if (txtPassword.Text != txtRePassword.Text)
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
            if (ValidateLecture() == false)
            {
                return;
            }
            else
            {
                var request = new User()
                {
                    Id = IdLecture,
                    FullName = txtName.Text,
                    Gender = cbboxGender.Text,
                    IdCard = txtIdCard.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    UserLogin = txtUserName.Text,
                    Password = Extendsion.Extendsion.GetMD5(txtPassword.Text),
                    DayOfBirth = dateTimeDayofBirth.Value,
                    UserType = (int)Globals.TypeUser.Lecturer,
                    ClassId = null,
                    FacultyId = (int)cbboxFacultyForm.SelectedValue,
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
                    PaginationLecture();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PaginationLecture();
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
                PaginationLecture();
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
                PaginationLecture();
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
                PaginationLecture();
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
                PaginationLecture();
            }
        }

        private async void GridLecture_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Entity = GridLecture.CurrentRow.Cells["Id"].Value.ToString();
            var result = await _userServiceClient.UserAsync(int.Parse(Entity));

            if (result.Data != null)
            {
                IdLecture = result.Data.Id;
                txtName.Text = result.Data.FullName;
                txtAddress.Text = result.Data.Address;
                txtEmail.Text = result.Data.Email;
                txtIdCard.Text = result.Data.Email;
                txtUserName.Text = result.Data.UserLogin;
                cbboxGender.Text = result.Data.Gender;
                dateTimeDayofBirth.Value = result.Data.DayOfBirth;
                cbboxFacultyForm.SelectedValue = result.Data.FacultyId;
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

        private void GridLecture_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridLecture.ClearSelection();
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ValidateLecture();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            ValidateLecture();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateLecture();
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            ValidateLecture();
        }

        private void cbboxFilterFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = cbboxFilterFaculty.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {
                return;
            }
            pageIndex = 1;
            PaginationLecture();
        }
    }
}
