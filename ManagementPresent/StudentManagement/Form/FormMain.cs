using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.Layout;
using StudentManagement.Globals;
using StudentManagement.Extendsion;

namespace StudentManagement
{
    public delegate void SendLogin(String FullNameValue, int RoleValue,int UserId);
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        //private static string FullName;
        //private static int? Role;
        public FormMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            random = new Random();
            btnCloseChildForm.Visible = false;

            //var Width = Screen.PrimaryScreen.WorkingArea.Width;
            //var Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void SetCurentUser(String FullNameValue, int RoleValue,int UserId) //get values receive form frmlogin
        {
            CurrentUser.FullName = FullNameValue;
            CurrentUser.Roles = RoleValue;
            CurrentUser.UserId = UserId;
            //FullName = FullNameValue;
            //Role = RoleValue;
            if (CurrentUser.Roles == (int)TypeUser.Adminstrator)
            {
                Role_Admin();
            }
            else if (CurrentUser.Roles == (int)TypeUser.Lecturer)
            {
                Role_Lecturers();
            }
            else if (CurrentUser.Roles == (int)TypeUser.Student)
            {
                Role_Student();
            }
            else
            {
                MessageBox.Show("Error , Cant confirm role your account");
                return;
            }
            string prefix = "Xin chào bạn : " + CurrentUser.FullName + "  ";
            linkUserLogin.Text = prefix + "Đăng xuất";
            linkUserLogin.LinkArea = new LinkArea(prefix.Length, linkUserLogin.Text.Length - prefix.Length);
            linkUserLogin.Visible = true;
            BtnLogin.Visible = false;
            btnCloseChildForm.Visible = false;
        }

        private void Logout()
        {
            ModuleDangkyhoc.Visible = false;
            ModuleProfileSV.Visible = false;
            ModuleSVXemDiem.Visible = false;
            ModuleProfileGV.Visible = false;
            ModuleGVNhapdiem.Visible = false;
            ModuleQLGV.Visible = false;
            ModuleQLDiem.Visible = false;
            ModuleQLKhoaDT.Visible = false;
            ModuleQLKhoaHoc.Visible = false;
            ModuleQLLop.Visible = false;
            ModuleQLLopHP.Visible = false;
            ModuleQLSV.Visible = false;
            ModuleQLKhoaHoc.Visible = false;
            ModuleQLMonhoc.Visible = false;
            ModuleChangePassword.Visible = false;
            ModuleReport.Visible =false;
        }


        private void Role_Student()
        {
            ModuleDangkyhoc.Visible = true;
            ModuleProfileSV.Visible = true;
            ModuleSVXemDiem.Visible = true;
            ModuleChangePassword.Visible = true;
        }

        private void Role_Lecturers()
        {
            ModuleProfileGV.Visible = true;
            ModuleGVNhapdiem.Visible = true;
            ModuleChangePassword.Visible = true;
        }

        private void Role_Admin()
        {
            ModuleReport.Visible = true;
            ModuleQLGV.Visible = true;
            ModuleQLDiem.Visible = true;
            ModuleQLKhoaDT.Visible = true;
            ModuleQLKhoaHoc.Visible = true;
            ModuleQLLop.Visible = true;
            ModuleQLLopHP.Visible = true;
            ModuleQLSV.Visible = true;
            ModuleQLKhoaHoc.Visible = true;
            ModuleQLMonhoc.Visible = true;
            ModuleChangePassword.Visible = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmStudentManagement(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisnableButton();
            lblTitle.Text = "Trang chủ";
            /*
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            */
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }

            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }



        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisnableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisnableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(31, 30, 68);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildFormLogin(Form childForm, object btnSender)
        {

            if (activeForm != null)
            {
                activeForm.Close();
            }
            //ActivateButton(btnSender);
            DisnableButton();
            btnCloseChildForm.Visible = true;
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.MdiParent = this;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnCloseChildForm_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            OpenChildFormLogin(new FrmLogin(SetCurentUser), sender);
        }

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkUserLogin.Visible = false;
            BtnLogin.Visible = true;
            CurrentUser.FullName = null;
            CurrentUser.Roles = null;
            CurrentUser.UserId = null;
            Logout();
            if (activeForm != null)
            {
                activeForm.Close();
            }
            linkUserLogin.Links.Clear();
            Reset();
        }

        private void ModuleProfileSV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmProfileStudent(Globals.CurrentUser.UserId), sender);
        }

        private void ModuleProfileGV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmProfieLecturer(Globals.CurrentUser.UserId), sender);
        }

        private void ModuleQLDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmScoreByAdmin(), sender);
        }

        private void ModuleDangkyhoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmStudentRegistSubject(Globals.CurrentUser.UserId), sender);
        }

        private void ModuleGVNhapdiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmScoreForLecturer(CurrentUser.UserId), sender);
        }

        private void ModuleQLMonhoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSubject(), sender);
        }

        private void ModuleQLKhoaHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCourse(), sender);
        }

        private void ModuleQLKhoaDT_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmFacutly(), sender);
        }

        private void ModuleQLLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmClassBase(), sender);
        }

        private void ModuleQLLopHP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmClassSubject(), sender);
        }

        private void ModuleSVXemDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmScoreByStudent(CurrentUser.UserId), sender);
        }

        private void ModuleQLGV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmLecturerManagement(), sender);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new FormChangePassword(CurrentUser.UserId), sender);
        }

        private void ModuleReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmReport(), sender);
        }
    }
}
