using StudentManagement.CourseService;
using StudentManagement.FacutlyService;
using StudentManagement.ScoreService;
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
    public partial class FrmReport : Form
    {
        private readonly CourseServiceClient _courseService;
        private readonly FacutlyServiceClient _facutlyService;
        private readonly ScoreServiceClient _scoreServiceClient;
        private static string LocationExcel = null;

        public FrmReport()
        {
            InitializeComponent();
            _courseService = new CourseServiceClient();
            _facutlyService = new FacutlyServiceClient();
            _scoreServiceClient = new ScoreServiceClient();
        }

        private async void FrmReport_Load(object sender, EventArgs e)
        {
            var SourceFacutly = await _facutlyService.FacutlysAsync();

            var TableFacutlyFilter = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Facutly>(SourceFacutly.Data.ToList());


            DataRow DefaultSelectFilter = TableFacutlyFilter.NewRow();
            DefaultSelectFilter[0] = DBNull.Value;
            DefaultSelectFilter[1] = "== Chọn khoa đào tạo ==";

            TableFacutlyFilter.Rows.InsertAt(DefaultSelectFilter, 0);


            cbboxFacutly.DataSource = TableFacutlyFilter;
            cbboxFacutly.DisplayMember = "Name";
            cbboxFacutly.ValueMember = "Id";

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
        }

        private void cbboxFacutly_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbboxFacutly.DataSource != null && cbboxFacutly.SelectedValue != System.DBNull.Value && cbboxFacutly.SelectedValue != null
                && cbboxCourse.DataSource != null && cbboxCourse.SelectedValue != System.DBNull.Value && cbboxCourse.SelectedValue != null)
            {
                var t = cbboxFacutly.SelectedValue.ToString();
                if (t == "System.Data.DataRowView")
                {
                    return;
                }
                cbboxCourse_SelectedValueChanged(sender, e);
            }
            else
            {
                cbboxYearStudy.DataSource = null;
            }
        }

        private void cbboxCourse_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbboxFacutly.DataSource != null && cbboxFacutly.SelectedValue != System.DBNull.Value && cbboxFacutly.SelectedValue != null
                && cbboxCourse.DataSource != null && cbboxCourse.SelectedValue != System.DBNull.Value && cbboxCourse.SelectedValue != null)
            {
                var IdCourse = cbboxCourse.SelectedValue.ToString();
                if (IdCourse == "System.Data.DataRowView")
                {
                    return;
                }

                var currentCourse = _courseService.Course(int.Parse(IdCourse)).Data;

                var data = Extendsion.Extendsion.ListYearStudy(currentCourse.CourseStart, currentCourse.CourseEnd);
                cbboxYearStudy.DataSource = data;
                cbboxYearStudy.DisplayMember = "Year";
                cbboxYearStudy.ValueMember = "Semester";
            }
            else
            {
                cbboxYearStudy.DataSource = null;
            }
        }

        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            LocationExcel = Extendsion.Extendsion.GetLocationForExcel();
            lblLocation.Text = "=> " + LocationExcel;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgridScore.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }
            if (LocationExcel == null)
            {
                MessageBox.Show("Chưa có đường dẫn để xuất dữ liệu");
                return;
            }
            Extendsion.Extendsion.ExporttoExcel(dgridScore, LocationExcel);
            MessageBox.Show("Xuất excel thành công vào đường dẫn '" + LocationExcel + "'");
            LocationExcel = null;
            lblLocation.Text = "=> ";
        }

        private void btnListStudent_Click(object sender, EventArgs e)
        {
            if(cbboxYearStudy.DataSource!= null && cbboxYearStudy.SelectedValue != System.DBNull.Value && cbboxYearStudy.SelectedValue != null)
            {
                var request = new TopStudentRequest()
                {
                    FacultyId = (int)cbboxFacutly.SelectedValue,
                    SemesterId = (int)cbboxYearStudy.SelectedValue,
                    CourseId = (int)cbboxCourse.SelectedValue
                };
                var data = _scoreServiceClient.TopStudent(request);
                dgridScore.DataSource = data.Data;
            }
            else
            {
                dgridScore.DataSource = new List<TopStudentVm>();
            }
        }
    }
}
