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
using StudentManagement.CourseService;
using StudentManagement.ScoreService;

namespace StudentManagement
{
    public partial class FrmScoreByStudent : Form
    {
        private int? StudentId;
        private readonly CourseServiceClient _courseServiceClient;
        private readonly ScoreServiceClient _scoreServiceclient;
        public FrmScoreByStudent(int? IdStudent)
        {
            InitializeComponent();
            StudentId = IdStudent;
            _courseServiceClient = new CourseServiceClient();
            _scoreServiceclient = new ScoreServiceClient();
        }

        private async void FrmScoreByStudent_Load(object sender, EventArgs e)
        {
            radioButtonAll.Checked = true;

            var Course = await _courseServiceClient.CourseByStudentIdAsync((int)StudentId);
            var YearStudy = Extendsion.Extendsion.ListYearStudy(Course.Data.CourseStart, Course.Data.CourseEnd);

            cbboxYearStudy.DataSource = YearStudy;
            cbboxYearStudy.DisplayMember = "Year";
            cbboxYearStudy.ValueMember = "Semester";
        }

        private void radioFollowYearSemester_CheckedChanged(object sender, EventArgs e)
        {
            cbboxYearStudy.Enabled = true;
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            cbboxYearStudy.Enabled = false;
        }

        private async void btnViewScore_Click(object sender, EventArgs e)
        {
            if(radioButtonAll.Checked==true)
            {
                var request = new StudentViewScoreRequest();
                request.StudentId = (int)StudentId;
                request.SemesterId = null;

                var data = await _scoreServiceclient.ScoreViewByStudentAsync(request);
                dgridScore.DataSource = data.Data;
            }
            else
            {
                var request = new StudentViewScoreRequest();
                request.StudentId = (int)StudentId;

                if (cbboxYearStudy.SelectedValue == System.DBNull.Value || cbboxYearStudy.SelectedValue == null)
                {
                    MessageBox.Show("Bạn chưa chọn năm học - học kỳ cần xem");
                    return;
                }
                else
                {
                    request.SemesterId = (int)cbboxYearStudy.SelectedValue;
                }

                var data = await _scoreServiceclient.ScoreViewByStudentAsync(request);
                dgridScore.DataSource = data.Data;
            }
        }


        private void dgridScore_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgridScore.ClearSelection();
        }
    }
}
