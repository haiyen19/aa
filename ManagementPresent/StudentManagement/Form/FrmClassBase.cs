using StudentManagement.ClassService;
using StudentManagement.CourseService;
using StudentManagement.FacutlyService;
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
    public partial class FrmClassBase : Form
    {
        private readonly CourseServiceClient _courseService;
        private readonly FacutlyServiceClient _facutlyService;
        private readonly ClassServiceClient _classServiceClient;
        private static int? IdClass = null;
        private static int pageIndex;
        private static double Total_Page;
        private static int pageSize;

        public FrmClassBase()
        {
            InitializeComponent();
            _courseService = new CourseServiceClient();
            _facutlyService = new FacutlyServiceClient();
            _classServiceClient = new ClassServiceClient();
            pageIndex = 1;
            pageSize = 13;
            Total_Page = 0;
        }

        private bool ValidateClass()
        {
            if (txtName.Text.Length == 0 || cbboxFacultyForm.SelectedValue == System.DBNull.Value || cbboxFacultyForm.SelectedValue == null
                || cbboxCourseForm.SelectedValue == System.DBNull.Value || cbboxCourseForm.SelectedValue == null)
            {
                if (txtName.Text.Length == 0)
                {
                    labelRequiredName.Visible = true;
                }
                else
                {
                    labelRequiredName.Visible = false;
                }
                if (cbboxFacultyForm.SelectedValue == System.DBNull.Value || cbboxFacultyForm.SelectedValue == null)
                {
                    lblRequiredFacutly.Visible = true;
                }
                else
                {
                    lblRequiredFacutly.Visible = false;
                }
                if (cbboxCourseForm.SelectedValue == System.DBNull.Value || cbboxCourseForm.SelectedValue == null)
                {
                    lblRequiredCourse.Visible = true;
                }
                else
                {
                    lblRequiredCourse.Visible = false;
                }
                return false;
            }
            labelRequiredName.Visible = false;
            lblRequiredFacutly.Visible = false;
            lblRequiredCourse.Visible = false;
            return true;
        }

        private void CreateModel()
        {
            IdClass = null;
            txtName.Text = null;
            txtMota.Text = null;
            cbboxCourseForm.SelectedValue = System.DBNull.Value;
            cbboxFacultyForm.SelectedValue = System.DBNull.Value;
            btnDelete.Visible = false;
            BtnCreate.Visible = false;
        }


        private async void PaginationClass()
        {
            var request = new IdCourseAndFacultyRequest();
            request.pageIndex = pageIndex;
            request.pageSize = pageSize;
            if(cbboxCourseFilter.SelectedValue == System.DBNull.Value || cbboxCourseFilter.SelectedValue == null)
            {
                request.CourseId = null;
            }
            else
            {
                request.CourseId = (int)cbboxCourseFilter.SelectedValue;
            }
            if (cbboxFacutlyFilter.SelectedValue == System.DBNull.Value || cbboxFacutlyFilter.SelectedValue == null)
            {
                request.FacultyId = null;
            }
            else
            {
                request.FacultyId = (int)cbboxFacutlyFilter.SelectedValue;
            }


            var result = await _classServiceClient.ClassAllAsync(request);
            if (!result.Success)
            {
                MessageBox.Show("Có lỗi");
            }
            else
            {
                //Fill Data Return to DataGrid , Remove Column Total
                GridClasBase.DataSource = result.Data.Select(c => new {
                    Id = c.Id,
                    Name = c.Name,
                    CourseName = c.CourseName,
                    FacultyName = c.FacultyName
                }).ToList();

                //Get pagination result (Current page & Total page)
                var pagination = Extendsion.Extendsion.Pagination<ClassViewModel>(result.Data.ToList(), request);

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

                if(Total_Page == 0 && pageIndex > 0)
                {
                    if (pageIndex == 1)
                    {
                        return;
                    }
                    else
                    {
                        pageIndex--;
                        PaginationClass();
                    }
                }

            }
        } 

        private async void FrmClassBase_Load(object sender, EventArgs e)
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




            var request = new PaginationRequest()
            {
                pageIndex = 1,
                pageSize = 0
            };

            var SourceCourse = await _courseService.CoursesAsync(request);

            var TablecourseForm= Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Course>(SourceCourse.Data.ToList());
            var TablecourseFilter = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Course>(SourceCourse.Data.ToList());

            DataRow DefaultSelectCourseForm = TablecourseForm.NewRow();
            DefaultSelectCourseForm[0] = DBNull.Value;
            DefaultSelectCourseForm[1] = "== Chọn khóa học ==";

            DataRow DefaultSelectCoursefilter = TablecourseFilter.NewRow();
            DefaultSelectCoursefilter[0] = DBNull.Value;
            DefaultSelectCoursefilter[1] = "== Tất cả khóa học ==";

            TablecourseForm.Rows.InsertAt(DefaultSelectCourseForm, 0);
            TablecourseFilter.Rows.InsertAt(DefaultSelectCoursefilter, 0);

            cbboxCourseForm.DataSource = TablecourseForm;
            cbboxCourseForm.DisplayMember = "Name";
            cbboxCourseForm.ValueMember = "Id";

            cbboxCourseFilter.DataSource = TablecourseFilter;
            cbboxCourseFilter.DisplayMember = "Name";
            cbboxCourseFilter.ValueMember = "Id";

            PaginationClass();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateModel();
            BtnCreate.Visible = false;
            btnDelete.Visible = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            IdClass = IdClass != null ? IdClass : null;

            if (IdClass == null)
            {
                MessageBox.Show("Không có đối tượng cần xóa");
            }
            else
            {
                var result = await _classServiceClient.DeleteAsync((int)IdClass);
                MessageBox.Show(result.Message);
                PaginationClass();
                CreateModel();
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateClass() == false)
            {
                return;
            }
            else
            {
                var request = new Class()
                {
                    Id = IdClass,
                    Name = txtName.Text,
                    Description = txtMota.Text,
                    FacultyId = (int)cbboxFacultyForm.SelectedValue,
                    CourseId = (int)cbboxCourseForm.SelectedValue
                };
                var result = await _classServiceClient.SaveAsync(request);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                    CreateModel();
                    PaginationClass();
                }
            }
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
                PaginationClass();
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
                PaginationClass();
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if(Total_Page == 0)
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
                PaginationClass();
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
                PaginationClass();
            }
        }

        private void cbboxCourseForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = cbboxCourseForm.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {
                return;
            }
            ValidateClass();
        }

        private void cbboxFacutlyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = cbboxFacutlyFilter.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {
                return;
            }
            pageIndex = 1;
            PaginationClass();
        }

        private void cbboxCourseFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = cbboxCourseFilter.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {
                return;
            }
            pageIndex = 1;
            PaginationClass();
        }

        private async void GridClasBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Entity = GridClasBase.CurrentRow.Cells["Id"].Value.ToString();
            var result = await _classServiceClient.ClassGetByIdAsync(int.Parse(Entity));

            if (result.Data != null)
            {
                IdClass = result.Data.Id;
                txtName.Text = result.Data.Name;
                cbboxCourseForm.SelectedValue = result.Data.CourseId;
                cbboxFacultyForm.SelectedValue = result.Data.FacultyId;
                BtnCreate.Visible = true;
                btnDelete.Visible = true;
                //FrmCourse_Load(sender, e);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ValidateClass();
        }

        private void cbboxFacultyForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = cbboxFacultyForm.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {
                return;
            }
            ValidateClass();
        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void GridClasBase_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridClasBase.ClearSelection();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
