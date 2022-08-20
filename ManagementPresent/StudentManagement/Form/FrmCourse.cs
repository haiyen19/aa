using StudentManagement.CourseService;
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
    public partial class FrmCourse : Form
    {
        private readonly CourseServiceClient client;
        private static int? IdCourse = null;
        private static int pageIndex;
        private static double Total_Page;
        private static int pageSize;
        public FrmCourse()
        {
            InitializeComponent();
            client = new CourseServiceClient();
            pageIndex = 1;
            pageSize = 13;
            Total_Page = 0;

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateCourse()
        {
            if (txtName.Text.Length == 0)
            {
                labelRequiredName.Visible = true;
                return false;
            }
            else
            {
                labelRequiredName.Visible = false;
                return true;
            }
        }

        private void CreateModel()
        {
            IdCourse = null;
            txtName.Text = null;
            CourseStartDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            CourseEndDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            CheckboxActive.Checked = false;
            btnDelete.Visible = false;
            BtnCreate.Visible = false;
        }


        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            ValidateCourse();
        }


        //Event Save Data
        private async void button3_Click(object sender, EventArgs e)
        {
            if (ValidateCourse() == false)
            {
                return;
            }
            else
            {
                var request = new CourseRequest()
                {
                    Id = IdCourse,
                    Name = txtName.Text,
                    CourseStart = CourseStartDate.Value,
                    CourseEnd = CourseEndDate.Value,
                    IsActive = CheckboxActive.Checked
                };
                var result = await client.SaveAsync(request);
                if(!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                    FrmCourse_Load(sender, e);
                    CreateModel();
                }
            }
        }


        //Event Get List Data
        private async void FrmCourse_Load(object sender, EventArgs e)
        {

            var request = new PaginationRequest();
            request.pageIndex = pageIndex;
            request.pageSize = pageSize;
            var result = await client.CoursesAsync(request);
            if(!result.Success)
            {
                MessageBox.Show("Có lỗi");
            }
            else
            {
                //Fill Data Return to DataGrid , Remove Column Total
                GridCourse.DataSource = result.Data.Select(c => new { 
                    Id = c.Id,
                    Name = c.Name,
                    CourseStart = c.CourseStart,
                    CourseEnd = c.CourseEnd
                }).ToList();

                //Get pagination result (Current page & Total page)
                var pagination = Extendsion.Extendsion.Pagination<Course>(result.Data.ToList(), request);

                //Set globals Total page
                Total_Page = pagination.TotalPage;

                //Set Display pagination UI
                LblPageIndex.Text = pageIndex + " / " + Total_Page;

                //if else ..
                if(pageIndex == 1) // you are stay top page
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

                if (Total_Page == 0 && pageIndex > 0)
                {
                    
                }

                if (Total_Page == 0 && pageIndex > 0)
                {
                    if (pageIndex == 1)
                    {
                        return;
                    }
                    else
                    {
                        pageIndex--;
                        FrmCourse_Load(sender, e);
                    }
                }
            }
        }


        //Event Create New Model
        private void button1_Click(object sender, EventArgs e)
        {
            CreateModel();
            BtnCreate.Visible = false;
            btnDelete.Visible = false;
        }

        private void GridCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GridCourse_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridCourse.ClearSelection();
        }


        //Top page
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
                FrmCourse_Load(sender, e);
            }
        }

        //Back page
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
                FrmCourse_Load(sender, e);
            }
        }
        //Next page
        private void BtnNextPage_Click(object sender, EventArgs e)
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
                pageIndex++;
                FrmCourse_Load(sender, e);
            }
        }
        //Last page
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
                FrmCourse_Load(sender, e);
            }
        }

        private async void GridCourse_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var Entity = GridCourse.CurrentRow.Cells["Id"].Value.ToString();
            var result = await client.CourseAsync(int.Parse(Entity));

            if (result.Data != null)
            {
                IdCourse = result.Data.Id;
                txtName.Text = result.Data.Name;
                CourseStartDate.Value = result.Data.CourseStart;
                CourseEndDate.Value = result.Data.CourseEnd;
                CheckboxActive.Checked = result.Data.IsActive;
                BtnCreate.Visible = true;
                btnDelete.Visible = true;
                //FrmCourse_Load(sender, e);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            IdCourse = IdCourse != null ? IdCourse : null;

            if (IdCourse == null)
            {
                MessageBox.Show("Không có đối tượng cần xóa");
            }
            else
            {
                var result = await client.DeleteAsync((int)IdCourse);
                MessageBox.Show(result.Message);
                FrmCourse_Load(sender, e);
                CreateModel();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
