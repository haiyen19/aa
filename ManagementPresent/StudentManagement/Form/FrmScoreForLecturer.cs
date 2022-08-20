using StudentManagement.OpenClassService;
using StudentManagement.ScoreService;
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
    public partial class FrmScoreForLecturer : Form
    {
        private readonly ClassSubjectServiceClient _openClassServiceClien;
        private readonly ScoreServiceClient _scoreServiceClient;
        private int? IdLecture;
        public FrmScoreForLecturer(int? CurrentId)
        {
            InitializeComponent();
            IdLecture = CurrentId;
            _openClassServiceClien = new ClassSubjectServiceClient();
            _scoreServiceClient = new ScoreServiceClient();
        }

        private void GetMyClass()
        {

        }

        private async void FrmScoreForLecturer_Load(object sender, EventArgs e)
        {
            var data = await _openClassServiceClien.OpenClassForLectureAsync((int)IdLecture);
            cbboxMyClass.DataSource = data.Data;
            cbboxMyClass.DisplayMember = "Name";
            cbboxMyClass.ValueMember = "Id";
        }

        private async void btnloadsv_Click(object sender, EventArgs e)
        {
            if(cbboxMyClass.DataSource == null)
            {
                MessageBox.Show("Không có lớp nào :((");
                return;
            }

            var t = cbboxMyClass.SelectedValue.ToString();
            if (t == "System.Data.DataRowView" || t == null || t == "")
            {
                return;
            }

            var data = await _scoreServiceClient.StudentsInsertScoreByLectureAsync(int.Parse(t));
            drgidScoreStudent.DataSource = data.Data;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ItemData = Extendsion.Extendsion.CreateRequestScoreByLecture(drgidScoreStudent);
            try
            {
                foreach (var item in ItemData)
                {
                    var reuslt = _scoreServiceClient.SaveScoreByLecture(item);
                }
                MessageBox.Show("Lưu thành công");
                btnloadsv_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
