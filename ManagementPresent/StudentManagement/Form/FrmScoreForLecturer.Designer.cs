
namespace StudentManagement
{
    partial class FrmScoreForLecturer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnloadsv = new System.Windows.Forms.Button();
            this.cbboxMyClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drgidScoreStudent = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberStudy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drgidScoreStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnloadsv);
            this.groupBox1.Controls.Add(this.cbboxMyClass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(84, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 82);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CÁC LỚP HỌC ĐANG QUẢN LÝ :";
            // 
            // btnloadsv
            // 
            this.btnloadsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloadsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnloadsv.Location = new System.Drawing.Point(584, 28);
            this.btnloadsv.Name = "btnloadsv";
            this.btnloadsv.Size = new System.Drawing.Size(130, 38);
            this.btnloadsv.TabIndex = 3;
            this.btnloadsv.Text = "Cập nhật";
            this.btnloadsv.UseVisualStyleBackColor = true;
            this.btnloadsv.Click += new System.EventHandler(this.btnloadsv_Click);
            // 
            // cbboxMyClass
            // 
            this.cbboxMyClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxMyClass.FormattingEnabled = true;
            this.cbboxMyClass.Location = new System.Drawing.Point(137, 36);
            this.cbboxMyClass.Name = "cbboxMyClass";
            this.cbboxMyClass.Size = new System.Drawing.Size(441, 24);
            this.cbboxMyClass.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "DS CÁC LỚP HỌC :";
            // 
            // drgidScoreStudent
            // 
            this.drgidScoreStudent.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.drgidScoreStudent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.drgidScoreStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drgidScoreStudent.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.drgidScoreStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.drgidScoreStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drgidScoreStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.StudentId,
            this.FullName,
            this.ClassName,
            this.NumberStudy,
            this.Score1,
            this.Score2,
            this.Score3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.drgidScoreStudent.DefaultCellStyle = dataGridViewCellStyle3;
            this.drgidScoreStudent.EnableHeadersVisualStyles = false;
            this.drgidScoreStudent.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.drgidScoreStudent.Location = new System.Drawing.Point(84, 173);
            this.drgidScoreStudent.Name = "drgidScoreStudent";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.drgidScoreStudent.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.drgidScoreStudent.RowHeadersVisible = false;
            this.drgidScoreStudent.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.drgidScoreStudent.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.drgidScoreStudent.RowTemplate.Height = 24;
            this.drgidScoreStudent.Size = new System.Drawing.Size(1137, 474);
            this.drgidScoreStudent.TabIndex = 7;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 125;
            // 
            // StudentId
            // 
            this.StudentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StudentId.DataPropertyName = "StudentId";
            this.StudentId.HeaderText = "Mã Sinh Viên";
            this.StudentId.MinimumWidth = 6;
            this.StudentId.Name = "StudentId";
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Họ Tên";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            // 
            // ClassName
            // 
            this.ClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "Lớp";
            this.ClassName.MinimumWidth = 6;
            this.ClassName.Name = "ClassName";
            // 
            // NumberStudy
            // 
            this.NumberStudy.DataPropertyName = "NumberStudy";
            this.NumberStudy.HeaderText = "Lần học";
            this.NumberStudy.MinimumWidth = 6;
            this.NumberStudy.Name = "NumberStudy";
            this.NumberStudy.ReadOnly = true;
            this.NumberStudy.Width = 125;
            // 
            // Score1
            // 
            this.Score1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Score1.DataPropertyName = "Score1";
            this.Score1.HeaderText = "Điểm KT1";
            this.Score1.MinimumWidth = 6;
            this.Score1.Name = "Score1";
            // 
            // Score2
            // 
            this.Score2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Score2.DataPropertyName = "Score2";
            this.Score2.HeaderText = "Điểm KT2";
            this.Score2.MinimumWidth = 6;
            this.Score2.Name = "Score2";
            // 
            // Score3
            // 
            this.Score3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Score3.DataPropertyName = "Score3";
            this.Score3.HeaderText = "Điểm Thi";
            this.Score3.MinimumWidth = 6;
            this.Score3.Name = "Score3";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1091, 667);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cập nhật";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmScoreForLecturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(209)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1312, 747);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.drgidScoreStudent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScoreForLecturer";
            this.Text = "Nhập điểm";
            this.Load += new System.EventHandler(this.FrmScoreForLecturer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drgidScoreStudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnloadsv;
        private System.Windows.Forms.ComboBox cbboxMyClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView drgidScoreStudent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberStudy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score3;
    }
}