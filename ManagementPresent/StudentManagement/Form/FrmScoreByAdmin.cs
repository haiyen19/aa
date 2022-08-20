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

namespace StudentManagement
{
    public partial class FrmScoreByAdmin : Form
    {
        private readonly CourseServiceClient _courseService;
        private readonly FacutlyServiceClient _facutlyService;
        private readonly ClassServiceClient _classServiceClient;
        private readonly StudentServiceClient _studentServiceClient;
        private readonly SubjectServiceClient _subjectServiceClient;
        private readonly ScoreServiceClient _scoreServiceClient;
        private static string LocationExcel = null;

        private static int? IdScore = null;

        public FrmScoreByAdmin()
        {
            InitializeComponent();
            _studentServiceClient =new StudentServiceClient();
            _courseService = new CourseServiceClient();
            _facutlyService = new FacutlyServiceClient();
            _classServiceClient = new ClassServiceClient();
            _subjectServiceClient = new SubjectServiceClient();
            _scoreServiceClient = new ScoreServiceClient();
        }

        private async void FrmScoreByAdmin_Load(object sender, EventArgs e)
        {
            var SourceFacutly = await _facutlyService.FacutlysAsync();

            var TableFacutlyFilter = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Facutly>(SourceFacutly.Data.ToList());


            DataRow DefaultSelectFilter = TableFacutlyFilter.NewRow();
            DefaultSelectFilter[0] = DBNull.Value;
            DefaultSelectFilter[1] = "== Chọn khoa đào tạo ==";

            TableFacutlyFilter.Rows.InsertAt(DefaultSelectFilter, 0);


            cbboxFaculty.DataSource = TableFacutlyFilter;
            cbboxFaculty.DisplayMember = "Name";
            cbboxFaculty.ValueMember = "Id";


            var request = new PaginationRequest()
            {
                pageIndex = 1,
                pageSize = 0
            };

            var SourceCourse = await _courseService.CoursesAsync(request);

            var TablecourseFilter = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Course>(SourceCourse.Data.ToList());


            DataRow DefaultSelectCoursefilter = TablecourseFilter.NewRow();
            DefaultSelectCoursefilter[0] = DBNull.Value;
            DefaultSelectCoursefilter[1] = "== Chọn khóa học ==";

            TablecourseFilter.Rows.InsertAt(DefaultSelectCoursefilter, 0);


            cbboxCourse.DataSource = TablecourseFilter;
            cbboxCourse.DisplayMember = "Name";
            cbboxCourse.ValueMember = "Id";

            radioInsertUpdate.Checked = true;
            btnDelete.Enabled = false;


        }

        private async void cbboxFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {

            string courseId = null;
            if(cbboxCourse.DataSource!= null)
            {
                courseId = cbboxCourse.SelectedValue.ToString();
                if(courseId == "")
                {
                    courseId = null;
                }
            }
            var facultyId = cbboxFaculty.SelectedValue.ToString();
            if (facultyId == "System.Data.DataRowView" || string.IsNullOrEmpty(facultyId) || courseId == "System.Data.DataRowView" || string.IsNullOrEmpty(courseId))
            {
                cbboxClass.DataSource = null;
                cbboxNamhoc.DataSource = null;
                return;
            }

            
            var request = new IdCourseAndFacultyRequest() { 
                pageIndex = 1,
                pageSize = 0,
                FacultyId = int.Parse(facultyId),
                CourseId = int.Parse(courseId)
            };
            var SourceClass = await _classServiceClient.ClassAllAsync(request);
            cbboxClass.DataSource = SourceClass.Data;
            cbboxClass.DisplayMember = "Name";
            cbboxClass.ValueMember = "Id";

            
            var Course = await _courseService.CourseAsync(int.Parse(courseId));

            cbboxNamhoc.DataSource = Extendsion.Extendsion.ListYearStudy(Course.Data.CourseStart, Course.Data.CourseEnd);
            cbboxNamhoc.DisplayMember = "Year";
            cbboxNamhoc.ValueMember = "Semester";
        }

        private async void cbboxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string facultyId = null;
            if (cbboxFaculty.DataSource != null) ;
            {
                facultyId = cbboxFaculty.SelectedValue.ToString();
                if(facultyId == "")
                {
                    facultyId = null;
                }
            }
            var courseId = cbboxCourse.SelectedValue.ToString();
            if (facultyId == "System.Data.DataRowView" || string.IsNullOrEmpty(facultyId) || courseId == "System.Data.DataRowView" || string.IsNullOrEmpty(courseId))
            {
                cbboxClass.DataSource = null;
                cbboxNamhoc.DataSource = null;
                return;
            }

            var request = new IdCourseAndFacultyRequest() { 
                pageIndex = 1,
                pageSize = 0,
                FacultyId = int.Parse(facultyId),
                CourseId = int.Parse(courseId)
            };
            var SourceClass = await _classServiceClient.ClassAllAsync(request);
            cbboxClass.DataSource = SourceClass.Data;
            cbboxClass.DisplayMember = "Name";
            cbboxClass.ValueMember = "Id";

            var Course = await _courseService.CourseAsync(int.Parse(courseId));

            cbboxNamhoc.DataSource = Extendsion.Extendsion.ListYearStudy(Course.Data.CourseStart, Course.Data.CourseEnd);
            cbboxNamhoc.DisplayMember = "Year";
            cbboxNamhoc.ValueMember = "Semester";

        }

        private async void cbboxNamhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var facultyId = cbboxFaculty.SelectedValue.ToString();
            var SemesterId = cbboxNamhoc.SelectedValue.ToString();

            if (facultyId == "System.Data.DataRowView" || string.IsNullOrEmpty(facultyId) || SemesterId == "System.Data.DataRowView" || string.IsNullOrEmpty(SemesterId) || SemesterId =="")
            {
                cbboxSubject.DataSource = null;
                return;
            }

            var request = new FacultyAndSemesterRequest
            {
                FacultyId = int.Parse(facultyId),
                SemeterId = int.Parse(SemesterId)
            };

            var SubjectSource = await _subjectServiceClient.SubjectByFacultyAndSemesterAsync(request);


            cbboxSubject.DataSource = SubjectSource.Data;
            cbboxSubject.DisplayMember = "Name";
            cbboxSubject.ValueMember = "Id";
        }

        private void cbboxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnListStudent_Click(object sender, EventArgs e)
        {
            if(cbboxSubject.DataSource == null || cbboxClass.DataSource == null)
            {
                MessageBox.Show("Ko có môn học hoặc lớp được chọn");
                return;
            }
            else
            {
                int subjectId = (int)cbboxSubject.SelectedValue;
                int classId = (int)cbboxClass.SelectedValue;

                var request = new SubjectAndClassIdRequest()
                {
                    ClassId = classId,
                    SubjectId = subjectId
                };
                if (radioInsertUpdate.Checked == true)
                {
                    dgridScoreStudent.DataSource = null;
                    dgridScoreStudent.ColumnCount = 6;
                    dgridScoreStudent.Columns[0].Name = "Mã SV";
                    dgridScoreStudent.Columns[0].DataPropertyName = "Id";
                    dgridScoreStudent.Columns[1].Name = "Họ Tên";
                    dgridScoreStudent.Columns[1].DataPropertyName = "FullName";
                    dgridScoreStudent.Columns[2].Name = "Lần Học";
                    dgridScoreStudent.Columns[2].DataPropertyName = "NumberStudy";
                    dgridScoreStudent.Columns[3].Name = "Điểm TP1";
                    dgridScoreStudent.Columns[3].DataPropertyName = "Score1";
                    dgridScoreStudent.Columns[4].Name = "Điểm TP2";
                    dgridScoreStudent.Columns[4].DataPropertyName = "Score2";
                    dgridScoreStudent.Columns[5].Name = "Điểm Thi";
                    dgridScoreStudent.Columns[5].DataPropertyName = "Score3";

                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    var SourceStudent = await _scoreServiceClient.StudentsInsertScoreAsync(request);
                    dgridScoreStudent.DataSource = SourceStudent.Data;
                }
                if(radioView.Checked ==true)
                {
                    dgridScoreStudent.DataSource = null;
                    dgridScoreStudent.ColumnCount = 10;
                    dgridScoreStudent.Columns[0].Name = "Mã Điểm";
                    dgridScoreStudent.Columns[0].DataPropertyName = "Id";
                    dgridScoreStudent.Columns[1].Name = "Họ Tên";
                    dgridScoreStudent.Columns[1].DataPropertyName = "FullName";
                    dgridScoreStudent.Columns[2].Name = "Lần Học";
                    dgridScoreStudent.Columns[2].DataPropertyName = "NumberStudy";
                    dgridScoreStudent.Columns[3].Name = "Điểm TP1";
                    dgridScoreStudent.Columns[3].DataPropertyName = "Score1";
                    dgridScoreStudent.Columns[4].Name = "Điểm TP2";
                    dgridScoreStudent.Columns[4].DataPropertyName = "Score2";
                    dgridScoreStudent.Columns[5].Name = "Điểm Thi";
                    dgridScoreStudent.Columns[5].DataPropertyName = "Score3";
                    dgridScoreStudent.Columns[6].Name = "Điểm Tổng Kết";
                    dgridScoreStudent.Columns[6].DataPropertyName = "SummaryScore";
                    dgridScoreStudent.Columns[7].Name = "Điểm Tổng Kết Hệ 4";
                    dgridScoreStudent.Columns[7].DataPropertyName = "SummaryScore4";
                    dgridScoreStudent.Columns[8].Name = "Điểm Chữ";
                    dgridScoreStudent.Columns[8].DataPropertyName = "Scoreword";
                    dgridScoreStudent.Columns[9].Name = "Đánh Giá";
                    dgridScoreStudent.Columns[9].DataPropertyName = "Evaluate";

                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                    var SourceStudent = await _scoreServiceClient.StudentsScoreViewAsync(request);
                    dgridScoreStudent.DataSource = SourceStudent.Data;
                }

                IdScore = null;
                lblIdXoadiem.Text = "Identity xóa điểm : ";
            }
        }

        private void radioInsertUpdate_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void radioView_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(radioInsertUpdate.Checked==false)
            {
                MessageBox.Show("Chức năng này chỉ hoạt động ở mục nhập/sửa điểm");
                return;
            }
            if(cbboxSubject.DataSource == null || cbboxNamhoc.DataSource == null)
            {
                MessageBox.Show("Không có môn học và năm học được chọn");
                return;
            }
            var ItemData = Extendsion.Extendsion.CreateRequestScore(dgridScoreStudent, (int)cbboxSubject.SelectedValue, (int)cbboxNamhoc.SelectedValue);
            try
            {
                foreach (var item in ItemData) {
                    var reuslt = await _scoreServiceClient.SaveScoreAdminAsync(item);
                }
                MessageBox.Show("Lưu thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IdScore == null)
            {
                MessageBox.Show("Không xác định được điểm cần xóa");
                return;
            }
            else
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Xóa điểm của sinh viên Sinh Vien", "Delete ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    var result = _scoreServiceClient.Delete((int)IdScore);
                    btnListStudent_Click(sender, e);
                }
            }
        }

        private void dgridScoreStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioView.Checked==true)
            {
                IdScore = int.Parse(dgridScoreStudent.CurrentRow.Cells[0].Value.ToString());
                lblIdXoadiem.Text = "Identity xóa điểm : " + IdScore;
            }
        }

        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            LocationExcel = Extendsion.Extendsion.GetLocationForExcel();
            lblLocation.Text = "=> " +LocationExcel;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgridScoreStudent.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }
            if (LocationExcel == null)
            {
                MessageBox.Show("Chưa có đường dẫn để xuất dữ liệu");
                return;
            }
            Extendsion.Extendsion.ExporttoExcel(dgridScoreStudent, LocationExcel);
            MessageBox.Show("Xuất excel thành công vào đường dẫn '"+ LocationExcel+"'");
            LocationExcel = null;
            lblLocation.Text = "=> ";
        }
    }
}
