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
    public partial class FrmProfileStudent : Form
    {
        private readonly UserServiceClient _userServiceClient;
        private int? StudentId = null;
        public FrmProfileStudent(int? studentId)
        {
            InitializeComponent();
            StudentId = studentId;
            _userServiceClient = new UserServiceClient();
        }

        private async void FrmProfileStudent_Load(object sender, EventArgs e)
        {
            if(StudentId == null)
            {
                return;
            }
            else
            {
                var model = await _userServiceClient.ProfileStudentAsync((int)StudentId);
                if(model!= null)
                {
                    lblFullName.Text = "Họ và Tên : " + model.Data.FullName;
                    lblDayOfBirth.Text = "Ngày sinh : " + model.Data.DayOfBirth.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    lblGender.Text = "Giới tính :" + model.Data.Gender.ToString();
                    lblEmail.Text = "Email : " + model.Data.Email;
                    lblPhone.Text = "Phone : " + model.Data.Phone;
                    lblAddress.Text = "Địa chỉ : " + model.Data.Address;
                    lblIdCard.Text = "Số Căn cước : " + model.Data.IdCard;
                    lblClassName.Text = "Lớp học : " + model.Data.ClassName;
                    lblCourseName.Text = "Khóa : " + model.Data.CourseName;
                    fblFacultyName.Text = "Khoa đào tạo : " + model.Data.FacultyName;
                    Extendsion.Extendsion.SetImage(model.Data.Avatar, ref Avatar);
                }
            }
        }
    }
}
