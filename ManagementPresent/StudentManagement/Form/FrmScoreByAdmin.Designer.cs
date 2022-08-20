
namespace StudentManagement
{
    partial class FrmScoreByAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgridScoreStudent = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioView = new System.Windows.Forms.RadioButton();
            this.radioInsertUpdate = new System.Windows.Forms.RadioButton();
            this.cbboxSubject = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbboxCourse = new System.Windows.Forms.ComboBox();
            this.cbboxFaculty = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbboxNamhoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbboxClass = new System.Windows.Forms.ComboBox();
            this.btnListStudent = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.lblIdXoadiem = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnSelectLocation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgridScoreStudent)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxAction.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgridScoreStudent
            // 
            this.dgridScoreStudent.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgridScoreStudent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridScoreStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgridScoreStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridScoreStudent.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridScoreStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgridScoreStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridScoreStudent.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgridScoreStudent.EnableHeadersVisualStyles = false;
            this.dgridScoreStudent.Location = new System.Drawing.Point(41, 165);
            this.dgridScoreStudent.Name = "dgridScoreStudent";
            this.dgridScoreStudent.RowHeadersVisible = false;
            this.dgridScoreStudent.RowHeadersWidth = 51;
            this.dgridScoreStudent.RowTemplate.Height = 24;
            this.dgridScoreStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgridScoreStudent.Size = new System.Drawing.Size(1590, 606);
            this.dgridScoreStudent.TabIndex = 8;
            this.dgridScoreStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridScoreStudent_CellContentClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioView);
            this.groupBox5.Controls.Add(this.radioInsertUpdate);
            this.groupBox5.Location = new System.Drawing.Point(41, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(204, 145);
            this.groupBox5.TabIndex = 131;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CHẾ ĐỘ";
            // 
            // radioView
            // 
            this.radioView.AutoSize = true;
            this.radioView.Location = new System.Drawing.Point(32, 91);
            this.radioView.Name = "radioView";
            this.radioView.Size = new System.Drawing.Size(95, 21);
            this.radioView.TabIndex = 1;
            this.radioView.Text = "XEM ĐIỂM";
            this.radioView.UseVisualStyleBackColor = true;
            this.radioView.CheckedChanged += new System.EventHandler(this.radioView_CheckedChanged);
            // 
            // radioInsertUpdate
            // 
            this.radioInsertUpdate.AutoSize = true;
            this.radioInsertUpdate.Location = new System.Drawing.Point(32, 46);
            this.radioInsertUpdate.Name = "radioInsertUpdate";
            this.radioInsertUpdate.Size = new System.Drawing.Size(140, 21);
            this.radioInsertUpdate.TabIndex = 0;
            this.radioInsertUpdate.TabStop = true;
            this.radioInsertUpdate.Text = "NHẬP/ SỬA ĐIỂM";
            this.radioInsertUpdate.UseVisualStyleBackColor = true;
            this.radioInsertUpdate.CheckedChanged += new System.EventHandler(this.radioInsertUpdate_CheckedChanged);
            // 
            // cbboxSubject
            // 
            this.cbboxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxSubject.FormattingEnabled = true;
            this.cbboxSubject.Location = new System.Drawing.Point(95, 99);
            this.cbboxSubject.Name = "cbboxSubject";
            this.cbboxSubject.Size = new System.Drawing.Size(367, 24);
            this.cbboxSubject.TabIndex = 137;
            this.cbboxSubject.SelectedIndexChanged += new System.EventHandler(this.cbboxSubject_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(7, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 136;
            this.label10.Text = "Môn học :";
            // 
            // cbboxCourse
            // 
            this.cbboxCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxCourse.FormattingEnabled = true;
            this.cbboxCourse.Location = new System.Drawing.Point(415, 21);
            this.cbboxCourse.Name = "cbboxCourse";
            this.cbboxCourse.Size = new System.Drawing.Size(220, 24);
            this.cbboxCourse.TabIndex = 135;
            this.cbboxCourse.SelectedIndexChanged += new System.EventHandler(this.cbboxCourse_SelectedIndexChanged);
            // 
            // cbboxFaculty
            // 
            this.cbboxFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxFaculty.FormattingEnabled = true;
            this.cbboxFaculty.Location = new System.Drawing.Point(95, 21);
            this.cbboxFaculty.Name = "cbboxFaculty";
            this.cbboxFaculty.Size = new System.Drawing.Size(247, 24);
            this.cbboxFaculty.TabIndex = 134;
            this.cbboxFaculty.SelectedIndexChanged += new System.EventHandler(this.cbboxFaculty_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(354, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 17);
            this.label11.TabIndex = 133;
            this.label11.Text = "Khóa :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(34, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 17);
            this.label13.TabIndex = 132;
            this.label13.Text = "Khoa :";
            // 
            // cbboxNamhoc
            // 
            this.cbboxNamhoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxNamhoc.FormattingEnabled = true;
            this.cbboxNamhoc.Location = new System.Drawing.Point(95, 60);
            this.cbboxNamhoc.Name = "cbboxNamhoc";
            this.cbboxNamhoc.Size = new System.Drawing.Size(247, 24);
            this.cbboxNamhoc.TabIndex = 139;
            this.cbboxNamhoc.SelectedIndexChanged += new System.EventHandler(this.cbboxNamhoc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(15, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 138;
            this.label1.Text = "Năm học :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbboxClass);
            this.groupBox1.Controls.Add(this.btnListStudent);
            this.groupBox1.Controls.Add(this.cbboxNamhoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbboxSubject);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbboxCourse);
            this.groupBox1.Controls.Add(this.cbboxFaculty);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(252, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 144);
            this.groupBox1.TabIndex = 140;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(354, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 143;
            this.label2.Text = "Lớp :";
            // 
            // cbboxClass
            // 
            this.cbboxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxClass.FormattingEnabled = true;
            this.cbboxClass.Location = new System.Drawing.Point(415, 60);
            this.cbboxClass.Name = "cbboxClass";
            this.cbboxClass.Size = new System.Drawing.Size(220, 24);
            this.cbboxClass.TabIndex = 142;
            // 
            // btnListStudent
            // 
            this.btnListStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListStudent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnListStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListStudent.Location = new System.Drawing.Point(468, 94);
            this.btnListStudent.Name = "btnListStudent";
            this.btnListStudent.Size = new System.Drawing.Size(167, 34);
            this.btnListStudent.TabIndex = 141;
            this.btnListStudent.Text = "Cập nhật sinh viên";
            this.btnListStudent.UseVisualStyleBackColor = true;
            this.btnListStudent.Click += new System.EventHandler(this.btnListStudent_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(16, 46);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 32);
            this.btnSave.TabIndex = 142;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(16, 94);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(250, 32);
            this.btnDelete.TabIndex = 143;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.Controls.Add(this.lblIdXoadiem);
            this.groupBoxAction.Controls.Add(this.btnDelete);
            this.groupBoxAction.Controls.Add(this.btnSave);
            this.groupBoxAction.Location = new System.Drawing.Point(903, 14);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Size = new System.Drawing.Size(285, 144);
            this.groupBoxAction.TabIndex = 144;
            this.groupBoxAction.TabStop = false;
            // 
            // lblIdXoadiem
            // 
            this.lblIdXoadiem.AutoSize = true;
            this.lblIdXoadiem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblIdXoadiem.Location = new System.Drawing.Point(13, 18);
            this.lblIdXoadiem.Name = "lblIdXoadiem";
            this.lblIdXoadiem.Size = new System.Drawing.Size(125, 17);
            this.lblIdXoadiem.TabIndex = 146;
            this.lblIdXoadiem.Text = "Identity xóa điểm : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExportExcel);
            this.groupBox3.Controls.Add(this.lblLocation);
            this.groupBox3.Controls.Add(this.btnSelectLocation);
            this.groupBox3.Location = new System.Drawing.Point(1194, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 143);
            this.groupBox3.TabIndex = 145;
            this.groupBox3.TabStop = false;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(104, 101);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(250, 32);
            this.btnExportExcel.TabIndex = 144;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblLocation.Location = new System.Drawing.Point(64, 63);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(24, 17);
            this.lblLocation.TabIndex = 145;
            this.lblLocation.Text = "=>";
            // 
            // btnSelectLocation
            // 
            this.btnSelectLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectLocation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectLocation.Location = new System.Drawing.Point(137, 16);
            this.btnSelectLocation.Name = "btnSelectLocation";
            this.btnSelectLocation.Size = new System.Drawing.Size(171, 32);
            this.btnSelectLocation.TabIndex = 144;
            this.btnSelectLocation.Text = "Chọn đường dẫn";
            this.btnSelectLocation.UseVisualStyleBackColor = true;
            this.btnSelectLocation.Click += new System.EventHandler(this.btnSelectLocation_Click);
            // 
            // FrmScoreByAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(209)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1673, 803);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxAction);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dgridScoreStudent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScoreByAdmin";
            this.Text = "Quản lý điểm sinh viên";
            this.Load += new System.EventHandler(this.FrmScoreByAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridScoreStudent)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxAction.ResumeLayout(false);
            this.groupBoxAction.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridScoreStudent;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioView;
        private System.Windows.Forms.RadioButton radioInsertUpdate;
        private System.Windows.Forms.ComboBox cbboxSubject;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbboxCourse;
        private System.Windows.Forms.ComboBox cbboxFaculty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbboxNamhoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnListStudent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBoxAction;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnSelectLocation;
        private System.Windows.Forms.Label lblIdXoadiem;
        private System.Windows.Forms.ComboBox cbboxClass;
        private System.Windows.Forms.Label label2;
    }
}