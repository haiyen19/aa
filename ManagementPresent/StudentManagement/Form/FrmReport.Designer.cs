
namespace StudentManagement
{
    partial class FrmReport
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
            this.label8 = new System.Windows.Forms.Label();
            this.cbboxFacutly = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbboxCourse = new System.Windows.Forms.ComboBox();
            this.cbboxYearStudy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListStudent = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnSelectLocation = new System.Windows.Forms.Button();
            this.dgridScore = new System.Windows.Forms.DataGridView();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MediumScore10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MediumScore4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllCredits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReachCredits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridScore)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 17);
            this.label8.TabIndex = 65;
            this.label8.Text = "Khoa đào tạo :";
            // 
            // cbboxFacutly
            // 
            this.cbboxFacutly.FormattingEnabled = true;
            this.cbboxFacutly.Location = new System.Drawing.Point(157, 37);
            this.cbboxFacutly.Name = "cbboxFacutly";
            this.cbboxFacutly.Size = new System.Drawing.Size(330, 24);
            this.cbboxFacutly.TabIndex = 66;
            this.cbboxFacutly.SelectedValueChanged += new System.EventHandler(this.cbboxFacutly_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(72, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 68;
            this.label9.Text = "Khóa học :";
            // 
            // cbboxCourse
            // 
            this.cbboxCourse.FormattingEnabled = true;
            this.cbboxCourse.Location = new System.Drawing.Point(157, 85);
            this.cbboxCourse.Name = "cbboxCourse";
            this.cbboxCourse.Size = new System.Drawing.Size(330, 24);
            this.cbboxCourse.TabIndex = 67;
            this.cbboxCourse.SelectedValueChanged += new System.EventHandler(this.cbboxCourse_SelectedValueChanged);
            // 
            // cbboxYearStudy
            // 
            this.cbboxYearStudy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxYearStudy.FormattingEnabled = true;
            this.cbboxYearStudy.Location = new System.Drawing.Point(157, 133);
            this.cbboxYearStudy.Name = "cbboxYearStudy";
            this.cbboxYearStudy.Size = new System.Drawing.Size(330, 24);
            this.cbboxYearStudy.TabIndex = 141;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(77, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 140;
            this.label1.Text = "Năm học :";
            // 
            // btnListStudent
            // 
            this.btnListStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListStudent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnListStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListStudent.Location = new System.Drawing.Point(41, 200);
            this.btnListStudent.Name = "btnListStudent";
            this.btnListStudent.Size = new System.Drawing.Size(446, 34);
            this.btnListStudent.TabIndex = 142;
            this.btnListStudent.Text = "Thống kê điểm sinh viên";
            this.btnListStudent.UseVisualStyleBackColor = true;
            this.btnListStudent.Click += new System.EventHandler(this.btnListStudent_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnListStudent);
            this.groupBox1.Controls.Add(this.cbboxYearStudy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbboxCourse);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbboxFacutly);
            this.groupBox1.Location = new System.Drawing.Point(64, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 266);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExportExcel);
            this.groupBox3.Controls.Add(this.lblLocation);
            this.groupBox3.Controls.Add(this.btnSelectLocation);
            this.groupBox3.Location = new System.Drawing.Point(64, 370);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 143);
            this.groupBox3.TabIndex = 146;
            this.groupBox3.TabStop = false;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(132, 105);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(259, 32);
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
            this.btnSelectLocation.Location = new System.Drawing.Point(171, 21);
            this.btnSelectLocation.Name = "btnSelectLocation";
            this.btnSelectLocation.Size = new System.Drawing.Size(171, 32);
            this.btnSelectLocation.TabIndex = 144;
            this.btnSelectLocation.Text = "Chọn đường dẫn";
            this.btnSelectLocation.UseVisualStyleBackColor = true;
            this.btnSelectLocation.Click += new System.EventHandler(this.btnSelectLocation_Click);
            // 
            // dgridScore
            // 
            this.dgridScore.AllowUserToAddRows = false;
            this.dgridScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgridScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridScore.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentId,
            this.FullName,
            this.ClassName,
            this.MediumScore10,
            this.MediumScore4,
            this.AllCredits,
            this.ReachCredits});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridScore.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgridScore.EnableHeadersVisualStyles = false;
            this.dgridScore.Location = new System.Drawing.Point(615, 83);
            this.dgridScore.Name = "dgridScore";
            this.dgridScore.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridScore.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgridScore.RowHeadersVisible = false;
            this.dgridScore.RowHeadersWidth = 51;
            this.dgridScore.RowTemplate.Height = 24;
            this.dgridScore.Size = new System.Drawing.Size(840, 512);
            this.dgridScore.TabIndex = 147;
            // 
            // StudentId
            // 
            this.StudentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StudentId.DataPropertyName = "StudentId";
            this.StudentId.HeaderText = "Mã sinh viên";
            this.StudentId.MinimumWidth = 6;
            this.StudentId.Name = "StudentId";
            this.StudentId.ReadOnly = true;
            this.StudentId.Width = 116;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Họ và tên";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 98;
            // 
            // ClassName
            // 
            this.ClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "Lớp";
            this.ClassName.MinimumWidth = 6;
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            // 
            // MediumScore10
            // 
            this.MediumScore10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MediumScore10.DataPropertyName = "MediumScore10";
            this.MediumScore10.HeaderText = "Điểm hệ 10";
            this.MediumScore10.MinimumWidth = 6;
            this.MediumScore10.Name = "MediumScore10";
            this.MediumScore10.ReadOnly = true;
            // 
            // MediumScore4
            // 
            this.MediumScore4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MediumScore4.DataPropertyName = "MediumScore4";
            this.MediumScore4.HeaderText = "Điểm hệ 4";
            this.MediumScore4.MinimumWidth = 6;
            this.MediumScore4.Name = "MediumScore4";
            this.MediumScore4.ReadOnly = true;
            // 
            // AllCredits
            // 
            this.AllCredits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AllCredits.DataPropertyName = "AllCredits";
            this.AllCredits.HeaderText = "Số TC trong kỳ";
            this.AllCredits.MinimumWidth = 6;
            this.AllCredits.Name = "AllCredits";
            this.AllCredits.ReadOnly = true;
            // 
            // ReachCredits
            // 
            this.ReachCredits.DataPropertyName = "ReachCredits";
            this.ReachCredits.HeaderText = "Số TC Đạt";
            this.ReachCredits.MinimumWidth = 6;
            this.ReachCredits.Name = "ReachCredits";
            this.ReachCredits.ReadOnly = true;
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(209)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1524, 795);
            this.Controls.Add(this.dgridScore);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReport";
            this.Text = "FrmReport";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbboxFacutly;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbboxCourse;
        private System.Windows.Forms.ComboBox cbboxYearStudy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListStudent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnSelectLocation;
        private System.Windows.Forms.DataGridView dgridScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediumScore10;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediumScore4;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllCredits;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReachCredits;
    }
}