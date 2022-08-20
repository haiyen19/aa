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

namespace StudentManagement
{
    public partial class FrmSubject : Form
    {
        private readonly FacutlyServiceClient _facutlyService;
        private readonly SubjectServiceClient _subjectServiceClient;
        private static int? IdSubject = null;
        private static int pageIndex;
        private static double Total_Page;
        private static int pageSize;
        public FrmSubject()
        {
            InitializeComponent();
            _facutlyService = new FacutlyServiceClient();
            _subjectServiceClient = new SubjectServiceClient();
            pageIndex = 1;
            pageSize = 13;
            Total_Page = 0;
        }

        private void CreateModel()
        {
            IdSubject = null;
            txtName.Text = null;
            numericCredit.Value = 1;
            numericSemester.Value = 1;
            CheckboxUserCalculation.Checked = false;
            cbboxFacultyForm.SelectedValue = System.DBNull.Value;
            btnDelete.Visible = false;
            BtnCreate.Visible = false;
        }


        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateModel();
            BtnCreate.Visible = false;
            btnDelete.Visible = false;
        }


        private async void PaginationSubject()
        {
            var request = new FacutylePaginationRequest();
            request.pageIndex = pageIndex;
            request.pageSize = pageSize;
            
            if (cbboxFacutlyFilter.SelectedValue == System.DBNull.Value || cbboxFacutlyFilter.SelectedValue == null)
            {
                request.FacultyId = null;
            }
            else
            {
                request.FacultyId = (int)cbboxFacutlyFilter.SelectedValue;
            }


            var result = await _subjectServiceClient.SubjectsAsync(request);
            if (!result.Success)
            {
                MessageBox.Show("Có lỗi");
            }
            else
            {
                //Fill Data Return to DataGrid , Remove Column Total
                GridSubject.DataSource = result.Data.Select(c => new {
                    Id = c.Id,
                    Name = c.Name,
                    Credits = c.Credits,
                    Semester = c.Semester,
                    FacultyName = c.FacultyName
                }).ToList();

                //Get pagination result (Current page & Total page)
                var pagination = Extendsion.Extendsion.Pagination<Subject>(result.Data.ToList(), request);

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

                if (Total_Page == 0 && pageIndex > 0)
                {
                    if (pageIndex == 1)
                    {
                        return;
                    }
                    else
                    {
                        pageIndex--;
                        PaginationSubject();
                    }
                }

            }
        }

        private async void FrmSubject_Load(object sender, EventArgs e)
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

            
        }

        private void cbboxFacutlyFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = cbboxFacutlyFilter.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {
                return;
            }
            pageIndex = 1;
            PaginationSubject();
        }

        private bool ValidateSubject()
        {
            if (txtName.Text.Length == 0 || cbboxFacultyForm.SelectedValue == System.DBNull.Value)
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
                return false;
            }
            labelRequiredName.Visible = false;
            lblRequiredFacutly.Visible = false;
            return true;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateSubject() == false)
            {
                return;
            }
            else
            {
                var request = new Subject()
                {
                    Id = IdSubject,
                    Name = txtName.Text,
                    Semester = (int)numericSemester.Value,
                    UsedCalculate = CheckboxUserCalculation.Checked,
                    Credits = (int)numericCredit.Value,
                    FacultyId = (int)cbboxFacultyForm.SelectedValue
                };
                var result = await _subjectServiceClient.SaveAsync(request);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                    CreateModel();
                    PaginationSubject();
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (IdSubject == null)
            {
                MessageBox.Show("Không có đối tượng cần xóa");
            }
            else
            {
                var result = await _subjectServiceClient.DeleteAsync((int)IdSubject);
                MessageBox.Show(result.Message);
                PaginationSubject();
                CreateModel();
            }
        }

        private async void GridSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Entity = GridSubject.CurrentRow.Cells["Id"].Value.ToString();
            var result = await _subjectServiceClient.SubjectAsync(int.Parse(Entity));

            if (result.Data != null)
            {
                IdSubject = result.Data.Id;
                txtName.Text = result.Data.Name;
                numericCredit.Value = result.Data.Credits;
                numericSemester.Value = result.Data.Semester;
                CheckboxUserCalculation.Checked = result.Data.UsedCalculate;
                cbboxFacultyForm.SelectedValue = result.Data.FacultyId;
                BtnCreate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                MessageBox.Show(result.Message);
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
                PaginationSubject();
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
                PaginationSubject();
            }
        }

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
                PaginationSubject();
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
                PaginationSubject();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ValidateSubject();
        }

        private void cbboxFacultyForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateSubject();
        }

        private void GridSubject_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridSubject.ClearSelection();
        }
    }
}
