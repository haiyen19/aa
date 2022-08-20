using System;
using StudentManagement.ClassService;
using StudentManagement.CourseService;
using StudentManagement.FacutlyService;
using StudentManagement.ScoreService;
using StudentManagement.ServiceStudent;
using StudentManagement.SubjectService;
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
using StudentManagement.UserService;
using StudentManagement.OpenClassService;

namespace StudentManagement
{
    public partial class FrmClassSubject : Form
    {

        private readonly ClassSubjectServiceClient _openClassServiceClien;
        private readonly FacutlyServiceClient _facutlyService;
        private readonly UserServiceClient _userServiceClient;
        private readonly SubjectServiceClient _subjectServiceClient;
        private static int? IdClassSubject = null;
        //private static string LocationExcel = null;


        public FrmClassSubject()
        {
            InitializeComponent();
            _facutlyService = new FacutlyServiceClient();
            _subjectServiceClient = new SubjectServiceClient();
            _userServiceClient = new UserServiceClient();
            _openClassServiceClien = new ClassSubjectServiceClient();
        }


        private void CreateModel()
        {
            IdClassSubject = null;
            txtName.Text = null;
            cbboxSubject.DataSource = null;
            cbboxLecture.DataSource = null;
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
            txtContent.Text = null;
            txtLocation.Text = null;
            txtNumberStudent.Text = "0";
        }

        private async void FrmClassSubject_Load(object sender, EventArgs e)
        {
            var SourceFacutly = await _facutlyService.FacutlysAsync();

            var TableFacutlyForm = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Facutly>(SourceFacutly.Data.ToList());
            var TableFacutlyFilter = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Facutly>(SourceFacutly.Data.ToList());


            DataRow DefaultSelectForm = TableFacutlyForm.NewRow();
            DefaultSelectForm[0] = DBNull.Value;
            DefaultSelectForm[1] = "== Chọn khoa đào tạo ==";
            DataRow DefaultSelectFilter = TableFacutlyFilter.NewRow();
            DefaultSelectFilter[0] = DBNull.Value;
            DefaultSelectFilter[1] = "== Tất cả khoa đào tạo ==";

            TableFacutlyForm.Rows.InsertAt(DefaultSelectForm, 0);
            TableFacutlyFilter.Rows.InsertAt(DefaultSelectFilter, 0);


            cbboxFacultyForm.DataSource = TableFacutlyForm;
            cbboxFacultyForm.DisplayMember = "Name";
            cbboxFacultyForm.ValueMember = "Id";

            cbboxFacutlyFilter.DataSource = TableFacutlyFilter;
            cbboxFacutlyFilter.DisplayMember = "Name";
            cbboxFacutlyFilter.ValueMember = "Id";
        }

        private bool ValidateClassSubject()
        {
            if (txtName.Text.Length == 0 || cbboxLecture.SelectedValue == System.DBNull.Value || cbboxLecture.SelectedValue == null
                || cbboxSubject.SelectedValue == System.DBNull.Value || cbboxSubject.SelectedValue == null)
            {
                if (txtName.Text.Length == 0)
                {
                    labelRequiredName.Visible = true;
                }
                else
                {
                    labelRequiredName.Visible = false;
                }

                if(cbboxLecture.SelectedValue == System.DBNull.Value || cbboxLecture.SelectedValue == null)
                {
                    lblRequiredLecture.Visible = true;
                }
                else
                {
                    lblRequiredLecture.Visible = false;
                }
                if (cbboxSubject.SelectedValue == System.DBNull.Value || cbboxSubject.SelectedValue == null)
                {
                    lblRequiredSubject.Visible = true;
                }
                else
                {
                    lblRequiredSubject.Visible = false;
                }

                return false;
            }
            else
            {
                lblRequiredLecture.Visible = false;
                lblRequiredSubject.Visible = false;
                labelRequiredName.Visible = false;
                return true;
            }
        }

        private async void cbboxFacultyForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            var facultyId = cbboxFacultyForm.SelectedValue.ToString();
            if (facultyId == "System.Data.DataRowView" || string.IsNullOrEmpty(facultyId))
            {
                cbboxLecture.DataSource = null;
                cbboxLecture.DataSource = null;
                return;
            }

            var request = new UserPaginationRequest()
            {
                pageIndex = 1,
                pageSize = 0,
                FacultyId = int.Parse(facultyId),
                TypeUser = (int)Globals.TypeUser.Lecturer
            };

            var SourceLecture = await _userServiceClient.UsersAsync(request);
            cbboxLecture.DataSource = SourceLecture.Data;
            cbboxLecture.DisplayMember = "FullName";
            cbboxLecture.ValueMember = "Id";

            var requestS = new FacutylePaginationRequest()
            {
                pageIndex = 1,
                pageSize = 0,
                FacultyId = int.Parse(facultyId)
            };

            var SourceSubject = await _subjectServiceClient.SubjectsAsync(requestS);

            cbboxSubject.DataSource = SourceSubject.Data;
            cbboxSubject.DisplayMember = "Name";
            cbboxSubject.ValueMember = "Id";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateClassSubject() == false)
            {
                return;
            }
            else
            {
                var request = new OpenClassRequest()
                {
                    Id = IdClassSubject,
                    Name = txtName.Text,
                    SubjectId = (int)cbboxSubject.SelectedValue,
                    LecturerId = (int)cbboxLecture.SelectedValue,
                    StartDate = dateStart.Value,
                    EndDate = dateEnd.Value,
                    Content = txtContent.Text,
                    Location = txtLocation.Text,
                    MaxStudent = int.Parse(txtNumberStudent.Text)
                };

                var result = _openClassServiceClien.SaveOpenClass(request);
                if(!result.Success)
                {
                    MessageBox.Show(result.Message);
                    return;
                }
                else
                {
                    MessageBox.Show(result.Message);
                    CreateModel();
                    ClassSubjects();
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ValidateClassSubject();
        }

        private void dgridClassSubject_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgridClassSubject.ClearSelection();
        }

        private async void ClassSubjects()
        {
            var t = cbboxFacutlyFilter.SelectedValue.ToString();
            int? requestT = null;
            if (t == "System.Data.DataRowView")
            {
                requestT = null;
            }

            if (cbboxFacutlyFilter.SelectedValue == System.DBNull.Value || cbboxFacutlyFilter.SelectedValue == null || cbboxFacutlyFilter.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                requestT = null;
            }
            else
            {
                requestT = (int)cbboxFacutlyFilter.SelectedValue;
            }

            var result = await _openClassServiceClien.OpenClassAsync(requestT);
            if (!result.Success)
            {
                MessageBox.Show("Có lỗi");
            }
            else
            {
                
                //Fill Data Return to DataGrid , Remove Column Total
                dgridClassSubject.AutoGenerateColumns = false;
                var data = result.Data.Select(c => new {
                    Id = c.Id,
                    Name = c.Name,
                    SubjectName = c.SubjectName,
                    LectureName = c.LectureName,
                    Time = c.Content + " Từ " + c.StartDate + " đến " + c.EndDate,
                    Location = c.Location,
                    Credits = c.Credits,
                    TotalRegist = c.TotalRegist,
                    MaxStudent = c.MaxStudent
                }).ToList();

                dgridClassSubject.DataSource = data;

                

            }
        }

        private void cbboxFacutlyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassSubjects();
        }

        private void txtNumberStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dgridClassSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Entity = dgridClassSubject.CurrentRow.Cells["Id"].Value.ToString();
            var result = _openClassServiceClien.GetById(int.Parse(Entity));

            if (result.Data != null)
            {
                var request1 = new UserPaginationRequest() {
                    pageIndex = 1,
                    pageSize = 0,
                    TypeUser = (int)Globals.TypeUser.Lecturer
                };
                var Users = _userServiceClient.Users(request1);
                cbboxLecture.DataSource = Users.Data;
                cbboxLecture.ValueMember = "Id";
                cbboxLecture.DisplayMember = "FullName";

                var request2 = new FacutylePaginationRequest()
                {
                    pageIndex = 1,
                    pageSize = 0,
                    FacultyId = null
                };

                var Subjects = _subjectServiceClient.Subjects(request2);
                cbboxSubject.DataSource = Subjects.Data;
                cbboxSubject.ValueMember = "Id";
                cbboxSubject.DisplayMember = "Name";



                IdClassSubject = result.Data.Id;
                txtName.Text = result.Data.Name;
                txtContent.Text = result.Data.Content;
                txtLocation.Text = result.Data.Location;
                txtNumberStudent.Text = result.Data.MaxStudent.ToString();
                dateStart.Value = result.Data.StartDate;
                dateEnd.Value = result.Data.EndDate;
                cbboxFacultyForm.SelectedValue = result.Data.FacultyId;
                cbboxLecture.SelectedValue = result.Data.LecturerId;
                cbboxSubject.SelectedValue = result.Data.SubjectId;
                BtnCreate.Visible = true;
                btnDelete.Visible = true;
            }

            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateModel();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (IdClassSubject == null)
            {
                MessageBox.Show("Không có đối tượng cần xóa");
            }
            else
            {
                var result = await _openClassServiceClien.DeleteAsync((int)IdClassSubject);
                MessageBox.Show(result.Message);
                ClassSubjects();
                CreateModel();
            }
        }

        private void cbboxLecture_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateClassSubject();
        }

        private void cbboxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateClassSubject();
        }
    }
}
