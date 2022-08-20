using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.FacutlyService;
using StudentManagement.ServiceStudent;
using StudentService.Model;
using StudentService.Request;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        private static string ImageLocation;
        private readonly StudentServiceClient _serviceStudent;
        private readonly FacutlyServiceClient _facutlyServiceClient;
        private static int pageIndex;
        private static double Total_Page;
        private static int pageSize;
        private Student _model;
        public Form1()
        {
            InitializeComponent();
            _serviceStudent = new StudentServiceClient();
            _facutlyServiceClient = new FacutlyServiceClient();
            _model = new Student();
            pageIndex = 1;
            pageSize = 5;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _model.EntityId = _model.EntityId != 0 ? _model.EntityId : 0;
            _model.FullName = TextFullName.Text;
            _model.Mobile = TextMobile.Text;
            _model.Address = TextAddress.Text;
            _model.IdFacutly = (int)CboboxFacutly.SelectedValue;
            _model.Avatar = Avatar == null ? null : Extendsion.Extendsion.ByteForImage(ImageLocation);
            if (_model.EntityId == 0)
            {
                var result = _serviceStudent.Add(_model);
                MessageBox.Show(result.Message);
            }
            else
            {
                var result = _serviceStudent.Update(_model);
                MessageBox.Show(result.Message);
            }
            _model.EntityId = 0;
            //dataGridViewStudent.DataSource = _serviceStudent.Students().Data;
            TextFullName.Text = null;
            TextMobile.Text = null;
            TextAddress.Text = null;
            Form1_Load(sender, e);
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            var SourceFacutly = await _facutlyServiceClient.FacutlysAsync();

            var TableFacutly = Extendsion.Extendsion.CollectionToDataTableDefaultSelect<Facutly>(SourceFacutly.Data.ToList());

            DataRow DefaultSelect = TableFacutly.NewRow();
            DefaultSelect[0] = "0";
            DefaultSelect[1] = "== Chọn khoa ==";

            TableFacutly.Rows.InsertAt(DefaultSelect, 0);

            CboboxFacutly.DataSource = TableFacutly;
            CboboxFacutly.DisplayMember = "Name";
            CboboxFacutly.ValueMember = "Id";



            var request = new PaginationRequest();
            request.pageIndex = pageIndex;
            request.pageSize = pageSize;
            try
            {
                var data = _serviceStudent.Students(request).Data;
                dataGridViewStudent.DataSource = data.Select(c => new {c.Index, c.EntityId, c.FullName, c.Mobile, c.Address,c.FacutlyName }).ToList();

                var Total = data.FirstOrDefault() != null ? data.FirstOrDefault().Total : 0;
                var paging = Convert.ToDouble(Total / request.pageSize);
                paging = (Total % request.pageSize == 0 ? paging : paging + 1);

                Total_Page = Math.Round(paging, MidpointRounding.AwayFromZero);

                LblPageIndex.Text = pageIndex + " / " + Total_Page;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Entity = dataGridViewStudent.CurrentRow.Cells["EntityId"].Value.ToString();
            var result = _serviceStudent.GetById(int.Parse(Entity));

            if (result.Data != null)
            {
                _model.EntityId = result.Data.EntityId;
                TextFullName.Text = result.Data.FullName;
                TextMobile.Text = result.Data.Mobile;
                TextAddress.Text = result.Data.Address;
                CboboxFacutly.SelectedValue = result.Data.IdFacutly;
                Extendsion.Extendsion.SetImage(result.Data.Avatar, ref Avatar);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void dataGridViewStudent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewStudent.ClearSelection();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            _model.EntityId = _model.EntityId != 0 ? _model.EntityId : 0;

            if (_model.EntityId == 0)
            {
                MessageBox.Show("Không có đối tượng cần xóa");
            }
            else
            {
                var result = _serviceStudent.Delete(_model.EntityId);
                MessageBox.Show(result.Message);
            }
            //dataGridViewStudent.DataSource = _serviceStudent.Students().Data;
            _model.EntityId = 0;
            TextFullName.Text = null;
            TextMobile.Text = null;
            TextAddress.Text = null;
            Form1_Load(sender, e);
        }

        private void btnBeginPage_Click(object sender, EventArgs e)
        {
            if(pageIndex == 1)
            {
                MessageBox.Show("Bạn đang ở trang đầu tiên");
            }
            else
            {
                pageIndex = 1;
                Form1_Load(sender,e);
            }
        }

        private void btnBackpage_Click(object sender, EventArgs e)
        {
            if (pageIndex == 1)
            {
                MessageBox.Show("Bạn đang ở trang đầu tiên");
            }
            else
            {
                pageIndex--;
                Form1_Load(sender, e);
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (pageIndex == Total_Page)
            {
                MessageBox.Show("Bạn đang ở trang cuối cùng");
            }
            else
            {
                pageIndex++;
                Form1_Load(sender, e);
            }
        }

        private void BtnEndPage_Click(object sender, EventArgs e)
        {
            if (pageIndex == Total_Page)
            {
                MessageBox.Show("Bạn đang ở trang cuối cùng");
            }
            else
            {
                pageIndex = (int)Total_Page;
                Form1_Load(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _model.EntityId = 0;
            TextFullName.Text = null;
            TextMobile.Text = null;
            TextAddress.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Extendsion.Extendsion.ImageLocation(ref ImageLocation,ref Avatar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
