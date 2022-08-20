using StudentManagement.UserService;
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
    public partial class FrmProfieLecturer : Form
    {
        private readonly UserServiceClient _userServiceClient;
        private int? LectureId = null;
        public FrmProfieLecturer(int? lectureId)
        {
            InitializeComponent();
            LectureId = lectureId;
            _userServiceClient = new UserServiceClient();
        }

        private async void FrmProfieLecturer_Load(object sender, EventArgs e)
        {
            if (LectureId == null)
            {
                return;
            }
            else
            {
                var model = await _userServiceClient.ProfileLectureAsync((int)LectureId);
                if (model != null)
                {
                    lblFullName.Text = "Họ và Tên : " + model.Data.FullName;
                    lblDayOfBirth.Text = "Ngày sinh : " + model.Data.DayOfBirth.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    lblGender.Text = "Giới tính :" + model.Data.Gender.ToString();
                    lblEmail.Text = "Email : " + model.Data.Email;
                    lblPhone.Text = "Phone : " + model.Data.Phone;
                    lblAddress.Text = "Địa chỉ : " + model.Data.Address;
                    lblIdCard.Text = "Số Căn cước : " + model.Data.IdCard;
                    fblFacultyName.Text = "Khoa đào tạo : " + model.Data.FacultyName;
                    Extendsion.Extendsion.SetImage(model.Data.Avatar, ref Avatar);
                }
            }
        }
    }
}
