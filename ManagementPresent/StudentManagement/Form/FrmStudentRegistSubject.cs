using System;
using StudentManagement.FacutlyService;
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
using StudentManagement.OpenClassService;
using StudentManagement.CourseService;

namespace StudentManagement
{
    public partial class FrmStudentRegistSubject : Form
    {
        private int? StudentId;
        private int currentSemester;
        private readonly SubjectServiceClient _subjectServiceClient;
        private readonly ClassSubjectServiceClient _openClassServiceClien;
        private readonly CourseServiceClient _courseServiceClient;
        public FrmStudentRegistSubject(int? studentId)
        {
            InitializeComponent();
            StudentId = studentId;
            _subjectServiceClient = new SubjectServiceClient();
            _openClassServiceClien = new ClassSubjectServiceClient();
            _courseServiceClient = new CourseServiceClient();
        }
         
        private async void FrmStudentRegistSubject_Load(object sender, EventArgs e)
        {
            var Subjects = await _subjectServiceClient.SubjectHaveClassSubjectOpenAsync((int)StudentId);
            cbboxSubject.DataSource = Subjects.Data;
            cbboxSubject.ValueMember = "Id";
            cbboxSubject.DisplayMember = "Name";


            DataGridViewCheckBoxColumn checkRegist = new DataGridViewCheckBoxColumn();
            dgirdRegist.Columns.Add(checkRegist);
            checkRegist.HeaderText = "Chọn";
            checkRegist.Name = "checkboxRegist";


            DataGridViewCheckBoxColumn checkRegistResult = new DataGridViewCheckBoxColumn();
            dgirdResultRegist.Columns.Add(checkRegistResult);
            checkRegistResult.HeaderText = "Chọn";
            checkRegistResult.Name = "checkboxResultRegist";
            GetResult();


            var Course = await _courseServiceClient.CourseByStudentIdAsync((int)StudentId);

            currentSemester = Extendsion.Extendsion.GetSemesterByCourse(Course.Data.CourseStart, Course.Data.CourseEnd);
        }


        private async void GetResult()
        {
            var data = await _openClassServiceClien.ResultRegistClassSubjectByStudentAsync((int)StudentId);
            dgirdResultRegist.DataSource = data.Data.Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                SubjectName = c.SubjectName,
                Time = c.Content + " Từ " + c.StartDate + " đến " + c.EndDate,
                Location = c.Location,
                MaxStudent = c.MaxStudent,
                TotalRegist = c.TotalRegist,
                Credits = c.Credits,
            }).ToList();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(cbboxSubject.DataSource == null)
            {
                return;
            }

            var Idsubject = cbboxSubject.SelectedValue.ToString();

            if (Idsubject == "System.Data.DataRowView" || string.IsNullOrEmpty(Idsubject))
            {
                return;
            }
            else
            {
                var data = await _openClassServiceClien.OpenClassForRegistStudentAsync(int.Parse(Idsubject));
                dgirdRegist.DataSource = data.Data.Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    SubjectName = c.SubjectName,
                    Time = c.Content + " Từ " + c.StartDate + " đến " + c.EndDate,
                    Location = c.Location,
                    MaxStudent = c.MaxStudent,
                    TotalRegist = c.TotalRegist,
                    Credits = c.Credits,
                }).ToList();
            }
        }

        private async void btnRegist_Click(object sender, EventArgs e)
        {
            if (dgirdRegist.Rows.Count == 0)
            {
                MessageBox.Show("Ko Có Gì Hết");
            }
            else
            {
                int? IdOpenClass = null;
                int check = 0;
                
                for (int i = 0; i < dgirdRegist.Rows.Count; i++)
                {
                    if (dgirdRegist.Rows[i].Cells["checkboxRegist"].Value == null)
                    {

                    }
                    else
                    {
                        bool checkedCell = (bool)dgirdRegist.Rows[i].Cells["checkboxRegist"].Value;
                        if (checkedCell == true)
                        {
                            check++;
                            IdOpenClass = (int)dgirdRegist.Rows[i].Cells["Id"].Value;

                        }
                    }
                    if (i == dgirdRegist.Rows.Count - 1)
                    {
                        if (check > 1)
                        {
                            MessageBox.Show("Bạn chỉ có thể đăng ký 1 lần/1 lớp");
                        }
                        else if (check == 0)
                        {
                            MessageBox.Show("Bạn chưa Chọn Lớp.");
                        }
                        else
                        {
                            var request = new RegistOpenClassRequest()
                            {
                                IdStudent = (int)StudentId,
                                IdOpenClass = (int)IdOpenClass,
                                SemesterId = currentSemester
                            };

                            var result = await _openClassServiceClien.StudentRegistAsync(request);
                            if (!result.Success)
                            {
                                MessageBox.Show(result.Message);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(result.Message);
                                GetResult();
                            }
                        }
                    }
                }
            }
        }

        private async void btnCancelRegist_Click(object sender, EventArgs e)
        {
            if (dgirdResultRegist.Rows.Count == 0)
            {
                MessageBox.Show("Ko Có Gì Hết");
            }
            else
            {
                int? IdOpenClass = null;
                int check = 0;
                for (int i = 0; i < dgirdResultRegist.Rows.Count; i++)
                {
                    if (dgirdResultRegist.Rows[i].Cells["checkboxResultRegist"].Value == null)
                    {

                    }
                    else
                    {
                        bool checkedCell = (bool)dgirdResultRegist.Rows[i].Cells["checkboxResultRegist"].Value;
                        if (checkedCell == true)
                        {
                            check++;
                            IdOpenClass = (int)dgirdResultRegist.Rows[i].Cells["IdResult"].Value;
                        }
                    }
                    if (i == dgirdResultRegist.Rows.Count - 1)
                    {
                        if (check > 1)
                        {
                            MessageBox.Show("Bạn Chỉ Có Thể Hủy Từng Lớp 1");
                        }
                        else if (check == 0)
                        {
                            MessageBox.Show("Bạn chưa Chọn Lớp nào để hủy.");
                        }
                        else
                        {
                            var result = await _openClassServiceClien.StudentCancelRegistAsync((int)IdOpenClass,(int)StudentId);
                            if (!result.Success)
                            {
                                MessageBox.Show(result.Message);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(result.Message);
                                GetResult();
                            }
                        }
                    }
                }
            }
        }
    }
}
