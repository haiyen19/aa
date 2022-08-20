
namespace StudentManagement
{
    partial class FrmScoreByStudent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbboxYearStudy = new System.Windows.Forms.ComboBox();
            this.radioFollowYearSemester = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnViewScore = new System.Windows.Forms.Button();
            this.dgridScore = new System.Windows.Forms.DataGridView();
            this.MSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LanHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Malop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamNhapHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SummaryScore4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridScore)).BeginInit();
            this.SuspendLayout();
            // 
            // cbboxYearStudy
            // 
            this.cbboxYearStudy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxYearStudy.FormattingEnabled = true;
            this.cbboxYearStudy.Location = new System.Drawing.Point(305, 74);
            this.cbboxYearStudy.Name = "cbboxYearStudy";
            this.cbboxYearStudy.Size = new System.Drawing.Size(258, 24);
            this.cbboxYearStudy.TabIndex = 13;
            // 
            // radioFollowYearSemester
            // 
            this.radioFollowYearSemester.AutoSize = true;
            this.radioFollowYearSemester.Location = new System.Drawing.Point(106, 74);
            this.radioFollowYearSemester.Name = "radioFollowYearSemester";
            this.radioFollowYearSemester.Size = new System.Drawing.Size(193, 21);
            this.radioFollowYearSemester.TabIndex = 11;
            this.radioFollowYearSemester.TabStop = true;
            this.radioFollowYearSemester.Text = "THEO NĂM HỌC-HỌC KỲ";
            this.radioFollowYearSemester.UseVisualStyleBackColor = true;
            this.radioFollowYearSemester.CheckedChanged += new System.EventHandler(this.radioFollowYearSemester_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(106, 31);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(154, 21);
            this.radioButtonAll.TabIndex = 10;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "TẤT CẢ HỌC PHẦN";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnViewScore);
            this.groupBox1.Controls.Add(this.cbboxYearStudy);
            this.groupBox1.Controls.Add(this.radioFollowYearSemester);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Location = new System.Drawing.Point(292, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 122);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // btnViewScore
            // 
            this.btnViewScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewScore.Location = new System.Drawing.Point(634, 46);
            this.btnViewScore.Name = "btnViewScore";
            this.btnViewScore.Size = new System.Drawing.Size(258, 39);
            this.btnViewScore.TabIndex = 22;
            this.btnViewScore.Text = "Xem điểm";
            this.btnViewScore.UseVisualStyleBackColor = true;
            this.btnViewScore.Click += new System.EventHandler(this.btnViewScore_Click);
            // 
            // dgridScore
            // 
            this.dgridScore.AllowUserToAddRows = false;
            this.dgridScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgridScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridScore.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgridScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MSV,
            this.HoTen,
            this.SoTC,
            this.LanHoc,
            this.Malop,
            this.NamNhapHoc,
            this.DiemThi,
            this.DiemTK,
            this.SummaryScore4,
            this.DiemChu,
            this.DanhGia});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridScore.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgridScore.EnableHeadersVisualStyles = false;
            this.dgridScore.Location = new System.Drawing.Point(74, 249);
            this.dgridScore.Name = "dgridScore";
            this.dgridScore.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridScore.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgridScore.RowHeadersVisible = false;
            this.dgridScore.RowHeadersWidth = 51;
            this.dgridScore.RowTemplate.Height = 24;
            this.dgridScore.Size = new System.Drawing.Size(1422, 512);
            this.dgridScore.TabIndex = 17;
            this.dgridScore.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgridScore_DataBindingComplete);
            // 
            // MSV
            // 
            this.MSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MSV.DataPropertyName = "IdSubject";
            this.MSV.HeaderText = "Mã Môn Học";
            this.MSV.MinimumWidth = 6;
            this.MSV.Name = "MSV";
            this.MSV.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HoTen.DataPropertyName = "SubjectName";
            this.HoTen.HeaderText = "Tên Học Phần";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 128;
            // 
            // SoTC
            // 
            this.SoTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoTC.DataPropertyName = "Credits";
            this.SoTC.HeaderText = "Số TC";
            this.SoTC.MinimumWidth = 6;
            this.SoTC.Name = "SoTC";
            this.SoTC.ReadOnly = true;
            // 
            // LanHoc
            // 
            this.LanHoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LanHoc.DataPropertyName = "NumberStudy";
            this.LanHoc.HeaderText = "Lần Học";
            this.LanHoc.MinimumWidth = 6;
            this.LanHoc.Name = "LanHoc";
            this.LanHoc.ReadOnly = true;
            // 
            // Malop
            // 
            this.Malop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Malop.DataPropertyName = "Score1";
            this.Malop.HeaderText = "Điểm KT1";
            this.Malop.MinimumWidth = 6;
            this.Malop.Name = "Malop";
            this.Malop.ReadOnly = true;
            // 
            // NamNhapHoc
            // 
            this.NamNhapHoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NamNhapHoc.DataPropertyName = "Score2";
            this.NamNhapHoc.HeaderText = "Điểm KT2";
            this.NamNhapHoc.MinimumWidth = 6;
            this.NamNhapHoc.Name = "NamNhapHoc";
            this.NamNhapHoc.ReadOnly = true;
            // 
            // DiemThi
            // 
            this.DiemThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiemThi.DataPropertyName = "Score3";
            this.DiemThi.HeaderText = "Điểm Thi";
            this.DiemThi.MinimumWidth = 6;
            this.DiemThi.Name = "DiemThi";
            this.DiemThi.ReadOnly = true;
            // 
            // DiemTK
            // 
            this.DiemTK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiemTK.DataPropertyName = "SummaryScore";
            this.DiemTK.HeaderText = "Điểm TK";
            this.DiemTK.MinimumWidth = 6;
            this.DiemTK.Name = "DiemTK";
            this.DiemTK.ReadOnly = true;
            // 
            // SummaryScore4
            // 
            this.SummaryScore4.DataPropertyName = "SummaryScore4";
            this.SummaryScore4.HeaderText = "Điểm hệ 4";
            this.SummaryScore4.MinimumWidth = 6;
            this.SummaryScore4.Name = "SummaryScore4";
            this.SummaryScore4.ReadOnly = true;
            // 
            // DiemChu
            // 
            this.DiemChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiemChu.DataPropertyName = "Scoreword";
            this.DiemChu.HeaderText = "Điểm Chữ";
            this.DiemChu.MinimumWidth = 6;
            this.DiemChu.Name = "DiemChu";
            this.DiemChu.ReadOnly = true;
            // 
            // DanhGia
            // 
            this.DanhGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DanhGia.DataPropertyName = "Evaluate";
            this.DanhGia.HeaderText = "Đánh Giá";
            this.DanhGia.MinimumWidth = 6;
            this.DanhGia.Name = "DanhGia";
            this.DanhGia.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(625, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 44);
            this.label1.TabIndex = 18;
            this.label1.Text = "KẾT QUẢ HỌC TẬP";
            // 
            // FrmScoreByStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(209)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1576, 805);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgridScore);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScoreByStudent";
            this.Text = "Xem điểm cá nhân";
            this.Load += new System.EventHandler(this.FrmScoreByStudent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbboxYearStudy;
        private System.Windows.Forms.RadioButton radioFollowYearSemester;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgridScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LanHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Malop;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamNhapHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SummaryScore4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhGia;
    }
}