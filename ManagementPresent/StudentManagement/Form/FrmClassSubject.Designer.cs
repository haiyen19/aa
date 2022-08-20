
namespace StudentManagement
{
    partial class FrmClassSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClassSubject));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbboxFacutlyFilter = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRequiredLecture = new System.Windows.Forms.Label();
            this.lblRequiredSubject = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.labelRequiredName = new System.Windows.Forms.Label();
            this.cbboxLecture = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumberStudent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.cbboxSubject = new System.Windows.Forms.ComboBox();
            this.cbboxFacultyForm = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgridClassSubject = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiangVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridClassSubject)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.cbboxFacutlyFilter);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(56, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 65);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            // 
            // cbboxFacutlyFilter
            // 
            this.cbboxFacutlyFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxFacutlyFilter.FormattingEnabled = true;
            this.cbboxFacutlyFilter.Location = new System.Drawing.Point(70, 21);
            this.cbboxFacutlyFilter.Name = "cbboxFacutlyFilter";
            this.cbboxFacutlyFilter.Size = new System.Drawing.Size(547, 24);
            this.cbboxFacutlyFilter.TabIndex = 65;
            this.cbboxFacutlyFilter.SelectedIndexChanged += new System.EventHandler(this.cbboxFacutlyFilter_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 64;
            this.label13.Text = "KHOA :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.lblRequiredLecture);
            this.groupBox1.Controls.Add(this.lblRequiredSubject);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.BtnCreate);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.labelRequiredName);
            this.groupBox1.Controls.Add(this.cbboxLecture);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNumberStudent);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtContent);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Controls.Add(this.dateEnd);
            this.groupBox1.Controls.Add(this.dateStart);
            this.groupBox1.Controls.Add(this.cbboxSubject);
            this.groupBox1.Controls.Add(this.cbboxFacultyForm);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(100, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1308, 255);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TẠO LỚP";
            // 
            // lblRequiredLecture
            // 
            this.lblRequiredLecture.AutoSize = true;
            this.lblRequiredLecture.ForeColor = System.Drawing.Color.Red;
            this.lblRequiredLecture.Location = new System.Drawing.Point(148, 116);
            this.lblRequiredLecture.Name = "lblRequiredLecture";
            this.lblRequiredLecture.Size = new System.Drawing.Size(129, 17);
            this.lblRequiredLecture.TabIndex = 77;
            this.lblRequiredLecture.Text = "Chưa có giảng viên";
            this.lblRequiredLecture.Visible = false;
            // 
            // lblRequiredSubject
            // 
            this.lblRequiredSubject.AutoSize = true;
            this.lblRequiredSubject.ForeColor = System.Drawing.Color.Red;
            this.lblRequiredSubject.Location = new System.Drawing.Point(562, 73);
            this.lblRequiredSubject.Name = "lblRequiredSubject";
            this.lblRequiredSubject.Size = new System.Drawing.Size(118, 17);
            this.lblRequiredSubject.TabIndex = 76;
            this.lblRequiredSubject.Text = "Chưa có môn học";
            this.lblRequiredSubject.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(1120, 208);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 40);
            this.btnDelete.TabIndex = 75;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // BtnCreate
            // 
            this.BtnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreate.Image = ((System.Drawing.Image)(resources.GetObject("BtnCreate.Image")));
            this.BtnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCreate.Location = new System.Drawing.Point(968, 42);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(146, 40);
            this.BtnCreate.TabIndex = 74;
            this.BtnCreate.Text = "Tạo mới";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Visible = false;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // labelRequiredName
            // 
            this.labelRequiredName.AutoSize = true;
            this.labelRequiredName.ForeColor = System.Drawing.Color.Red;
            this.labelRequiredName.Location = new System.Drawing.Point(148, 158);
            this.labelRequiredName.Name = "labelRequiredName";
            this.labelRequiredName.Size = new System.Drawing.Size(218, 17);
            this.labelRequiredName.TabIndex = 73;
            this.labelRequiredName.Text = "Tên lớp học không được để trống";
            this.labelRequiredName.Visible = false;
            // 
            // cbboxLecture
            // 
            this.cbboxLecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxLecture.FormattingEnabled = true;
            this.cbboxLecture.Location = new System.Drawing.Point(151, 89);
            this.cbboxLecture.Name = "cbboxLecture";
            this.cbboxLecture.Size = new System.Drawing.Size(263, 24);
            this.cbboxLecture.TabIndex = 63;
            this.cbboxLecture.SelectedIndexChanged += new System.EventHandler(this.cbboxLecture_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 17);
            this.label11.TabIndex = 62;
            this.label11.Text = "GIẢNG VIÊN :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(851, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 17);
            this.label9.TabIndex = 61;
            this.label9.Text = "SĨ SỐ :";
            // 
            // txtNumberStudent
            // 
            this.txtNumberStudent.Location = new System.Drawing.Point(909, 48);
            this.txtNumberStudent.Name = "txtNumberStudent";
            this.txtNumberStudent.Size = new System.Drawing.Size(53, 22);
            this.txtNumberStudent.TabIndex = 60;
            this.txtNumberStudent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberStudent_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(848, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 59;
            this.label8.Text = "CHI TIẾT :";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(935, 117);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(263, 53);
            this.txtContent.TabIndex = 58;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1120, 42);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 40);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(565, 92);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(267, 22);
            this.txtLocation.TabIndex = 55;
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "dd-MM-yyyy";
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(725, 139);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(107, 22);
            this.dateEnd.TabIndex = 54;
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "dd-MM-yyyy";
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.Location = new System.Drawing.Point(565, 139);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(108, 22);
            this.dateStart.TabIndex = 53;
            // 
            // cbboxSubject
            // 
            this.cbboxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxSubject.FormattingEnabled = true;
            this.cbboxSubject.Location = new System.Drawing.Point(565, 46);
            this.cbboxSubject.Name = "cbboxSubject";
            this.cbboxSubject.Size = new System.Drawing.Size(267, 24);
            this.cbboxSubject.TabIndex = 11;
            this.cbboxSubject.SelectedIndexChanged += new System.EventHandler(this.cbboxSubject_SelectedIndexChanged);
            // 
            // cbboxFacultyForm
            // 
            this.cbboxFacultyForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxFacultyForm.FormattingEnabled = true;
            this.cbboxFacultyForm.Location = new System.Drawing.Point(151, 46);
            this.cbboxFacultyForm.Name = "cbboxFacultyForm";
            this.cbboxFacultyForm.Size = new System.Drawing.Size(263, 24);
            this.cbboxFacultyForm.TabIndex = 10;
            this.cbboxFacultyForm.SelectedIndexChanged += new System.EventHandler(this.cbboxFacultyForm_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "KHOA :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(151, 133);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(263, 22);
            this.txtName.TabIndex = 8;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "NƠI HỌC :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "ĐẾN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "MÔN HỌC :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "THỜI GIAN :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "TÊN LỚP HP :";
            // 
            // dgridClassSubject
            // 
            this.dgridClassSubject.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgridClassSubject.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridClassSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgridClassSubject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridClassSubject.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridClassSubject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgridClassSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridClassSubject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TenLop,
            this.MonHoc,
            this.GiangVien,
            this.ThoiGian,
            this.DiaDiem,
            this.SiSo,
            this.DaDangKy,
            this.SoTC});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridClassSubject.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgridClassSubject.EnableHeadersVisualStyles = false;
            this.dgridClassSubject.Location = new System.Drawing.Point(99, 320);
            this.dgridClassSubject.Name = "dgridClassSubject";
            this.dgridClassSubject.RowHeadersVisible = false;
            this.dgridClassSubject.RowHeadersWidth = 51;
            this.dgridClassSubject.RowTemplate.Height = 24;
            this.dgridClassSubject.Size = new System.Drawing.Size(1309, 403);
            this.dgridClassSubject.TabIndex = 70;
            this.dgridClassSubject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridClassSubject_CellContentClick);
            this.dgridClassSubject.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgridClassSubject_DataBindingComplete);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 20F;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // TenLop
            // 
            this.TenLop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TenLop.DataPropertyName = "Name";
            this.TenLop.HeaderText = "Tên Lớp";
            this.TenLop.MinimumWidth = 6;
            this.TenLop.Name = "TenLop";
            this.TenLop.Width = 90;
            // 
            // MonHoc
            // 
            this.MonHoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MonHoc.DataPropertyName = "SubjectName";
            this.MonHoc.HeaderText = "Môn Học";
            this.MonHoc.MinimumWidth = 6;
            this.MonHoc.Name = "MonHoc";
            this.MonHoc.Width = 93;
            // 
            // GiangVien
            // 
            this.GiangVien.DataPropertyName = "LectureName";
            this.GiangVien.HeaderText = "Giảng Viên";
            this.GiangVien.MinimumWidth = 6;
            this.GiangVien.Name = "GiangVien";
            // 
            // ThoiGian
            // 
            this.ThoiGian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ThoiGian.DataPropertyName = "Time";
            this.ThoiGian.FillWeight = 200F;
            this.ThoiGian.HeaderText = "Thời Gian";
            this.ThoiGian.MinimumWidth = 6;
            this.ThoiGian.Name = "ThoiGian";
            // 
            // DiaDiem
            // 
            this.DiaDiem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DiaDiem.DataPropertyName = "Location";
            this.DiaDiem.HeaderText = "Địa Điểm";
            this.DiaDiem.MinimumWidth = 6;
            this.DiaDiem.Name = "DiaDiem";
            this.DiaDiem.Width = 94;
            // 
            // SiSo
            // 
            this.SiSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SiSo.DataPropertyName = "MaxStudent";
            this.SiSo.HeaderText = "Sĩ Số";
            this.SiSo.MinimumWidth = 6;
            this.SiSo.Name = "SiSo";
            this.SiSo.Width = 70;
            // 
            // DaDangKy
            // 
            this.DaDangKy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DaDangKy.DataPropertyName = "TotalRegist";
            this.DaDangKy.HeaderText = "Đã ĐK";
            this.DaDangKy.MinimumWidth = 6;
            this.DaDangKy.Name = "DaDangKy";
            this.DaDangKy.Width = 78;
            // 
            // SoTC
            // 
            this.SoTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SoTC.DataPropertyName = "Credits";
            this.SoTC.HeaderText = "Số TC";
            this.SoTC.MinimumWidth = 6;
            this.SoTC.Name = "SoTC";
            this.SoTC.Width = 76;
            // 
            // FrmClassSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(209)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1512, 778);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgridClassSubject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClassSubject";
            this.Text = "Quản lý lớp học phần";
            this.Load += new System.EventHandler(this.FrmClassSubject_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridClassSubject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbboxFacutlyFilter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbboxLecture;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumberStudent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.ComboBox cbboxSubject;
        private System.Windows.Forms.ComboBox cbboxFacultyForm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgridClassSubject;
        private System.Windows.Forms.Label labelRequiredName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiangVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTC;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Label lblRequiredLecture;
        private System.Windows.Forms.Label lblRequiredSubject;
    }
}