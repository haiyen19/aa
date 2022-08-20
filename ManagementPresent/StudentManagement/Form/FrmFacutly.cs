using StudentManagement.FacutlyService;
using StudentService.Model;
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
    public partial class FrmFacutly : Form
    {
        private readonly FacutlyServiceClient client;
        private static int? IdFacutly = null;
        public FrmFacutly()
        {
            InitializeComponent();
            client = new FacutlyServiceClient();
        }

        private bool ValidateFacutly()
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
            IdFacutly = null;
            txtName.Text = null;
            txtMota.Text = null;
            btnDelete.Visible = false;
            BtnCreate.Visible = false;
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ValidateFacutly();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFacutly() == false)
            {
                return;
            }
            else
            {
                var request = new Facutly()
                {
                    Id = IdFacutly,
                    Name = txtName.Text,
                    Description = txtMota.Text
                };
                var result = await client.SaveAsync(request);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                    CreateModel();
                    FrmFacutly_Load(sender, e);
                }
            }
        }

        private async void FrmFacutly_Load(object sender, EventArgs e)
        {
            var result = await client.FacutlysAsync();
            if (!result.Success)
            {
                MessageBox.Show("Có lỗi");
            }
            else
            {
                GridFacutly.DataSource = result.Data;
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateModel();
            BtnCreate.Visible = false;
            btnDelete.Visible = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            IdFacutly = IdFacutly != null ? IdFacutly : null;

            if (IdFacutly == null)
            {
                MessageBox.Show("Không có đối tượng cần xóa");
            }
            else
            {
                var result = await client.DeleteAsync((int)IdFacutly);
                MessageBox.Show(result.Message);
                FrmFacutly_Load(sender, e);
                CreateModel();
            }
        }

        private void GridFacutly_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            GridFacutly.ClearSelection();
        }

        private async void GridFacutly_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var Entity = GridFacutly.CurrentRow.Cells["Id"].Value.ToString();
            var result = await client.FacutlyAsync(int.Parse(Entity));

            if (result.Data != null)
            {
                IdFacutly = result.Data.Id;
                txtName.Text = result.Data.Name;
                txtMota.Text = result.Data.Description;
                BtnCreate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
    }
}
