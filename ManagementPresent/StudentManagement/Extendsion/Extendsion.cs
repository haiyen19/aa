using StudentService.Request;
using StudentService.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;

namespace StudentManagement.Extendsion
{
    public static class Extendsion
    {
        //get md5
        public static String GetMD5(string password)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(password);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
        //pagination
        public static PropertiesPagination Pagination<T>(List<T> data,PaginationRequest request) where T : class, new()
        {
            if(data == null || data.Count ==0)
            {
                return new PropertiesPagination
                {
                    PageIndex = 0,
                    TotalPage = 0
                };
            }
            else
            {
                long Total=0;
                //get value from input data
                foreach (var paramData in data)
                {
                    foreach (PropertyInfo prop in paramData.GetType().GetProperties())
                    {
                        if (prop.Name == "Total")
                        {
                            var total = prop.GetValue(paramData, null);
                            Total = (long)total;
                            break;
                        }
                    }
                }
                //paging
                var paging = Convert.ToDouble(Total / request.pageSize);
                paging = (Total % request.pageSize == 0 ? paging : paging + 1);

                paging = Math.Round(paging, MidpointRounding.AwayFromZero);
                return new PropertiesPagination
                {
                    PageIndex = request.pageIndex,
                    TotalPage = paging
                };
            }
        }
        //convert to data table ( use add default value for combo box)
        public static DataTable CollectionToDataTableDefaultSelect<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }


        //Get Image
        public static void ImageLocation(ref string ImageLocation,ref PictureBox picture)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            dlg.Title = "Select Student Picture";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = dlg.FileName.ToString();
                picture.ImageLocation = ImageLocation;
            }
        }

        //get byte image insert or update
        public static Byte[] ByteForImage(string imageLocation)
        {
            if (string.IsNullOrEmpty(imageLocation))
            {
                return null;
            }
            else
            {
                FileStream fs = new System.IO.FileStream(imageLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                return br.ReadBytes((int)fs.Length);
            }
        }


        //get image from database
        public static void SetImage(byte[] image,ref PictureBox picture)
        {
            byte[] img = image;
            if (img == null || img.Length==1)
                picture.Image = null;
            else
            {
                MemoryStream ms = new MemoryStream(img);
                picture.Image = Image.FromStream(ms);
            }
        }

        //export to excel
        public static void ExporttoExcel(DataGridView data, string DirrectoryPath)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int k = 1; k < data.Columns.Count + 1; k++)
            {
                obj.Cells[1, k] = data.Columns[k - 1].HeaderText;
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    if (data.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = data.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(DirrectoryPath);
            obj.ActiveWorkbook.Saved = true;
        }

        public static string GetLocationForExcel()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Select Location";
                dlg.Filter = "Excel Worksheets|*.xlsx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                   return dlg.FileName.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable ListYearStudy(DateTime StartDate,DateTime EndDate)
        {
            int Year = StartDate.Year;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Year", typeof(string));
            dt.Columns.Add("Semester", typeof(Int32));
            dt.Rows.Add("== Chọn năm học - học kỳ ==", null);
            int hocky = 1;
            for (int i = Year; i < EndDate.Year; i++)
            {
                int hk = 1;
                String _ravi = i + " - " + (i + 1) + "_" + hk;
                dt.Rows.Add(_ravi, hocky);
                hocky++;
                hk++;
                String _ravi2 = i + " - " + (i + 1) + "_" + hk;
                dt.Rows.Add(_ravi2, hocky);
                hocky++;
            }
            return dt;
        }


        public static int GetSemesterByCourse(DateTime StartDate, DateTime EndDate)
        {
            var CurrentYear = DateTime.Now.Year;
            var CurrentMonth = DateTime.Now.Month;

            int SemesterReturn = 0;
            int Semester = 1;
            for (int i = StartDate.Year; i <= EndDate.Year; i++)
            {
                if (i == CurrentYear)
                {
                    if(CurrentMonth <6)
                    {
                        SemesterReturn = Semester;
                    }
                    else
                    {
                        SemesterReturn = Semester + 1;
                    }
                    break;
                }
                Semester = Semester == 1 ? Semester + 1 : Semester + 2;
            }
            return SemesterReturn;
        }



        public static List<ScoreStudentRequest> CreateRequestScore(DataGridView dgrid,int subjectId,int Semester)
        {
            try
            {
                var result = new List<ScoreStudentRequest>();
                for (int i = 0; i < dgrid.Rows.Count; i++)
                {
                    int IdStudent = (int)dgrid.Rows[i].Cells[0].Value;
                    //String StudentName = dgrid.Rows[i].Cells[1].Value.ToString();

                    double? Score1 = null;
                    double? Score2 = null;
                    double? Score3 = null;
                    double? SummaryScore = null;
                    double? SummaryScore4 = null;
                    string Scoreword = null;
                    bool? Evaluate = null;
                    int NumberStudy;

                    //int lanhoc;
                    if (dgrid.Rows[i].Cells[2].Value.ToString() == "0")
                    {
                        NumberStudy = 1;
                    }
                    else
                    {
                        NumberStudy = int.Parse(dgrid.Rows[i].Cells[2].Value.ToString());
                    }


                    if (dgrid.Rows[i].Cells[3].Value != null)
                    {
                        Score1 = double.Parse(dgrid.Rows[i].Cells[3].Value.ToString());
                    }
                    if (dgrid.Rows[i].Cells[4].Value != null)
                    {
                        Score2 = double.Parse(dgrid.Rows[i].Cells[4].Value.ToString());
                    }
                    if (dgrid.Rows[i].Cells[5].Value != null)
                    {
                        Score3 = double.Parse(dgrid.Rows[i].Cells[5].Value.ToString());
                    }

                    if (Score1 != null && Score2 != null && Score3 != null)
                    {
                        if (Score1 > 10 || Score2 > 10 || Score3 > 10)
                        {
                            MessageBox.Show("Cảnh Báo. Điểm Nhập Ko Hợp Lệ: MSV:" + IdStudent);
                            break;
                        }
                        SummaryScore = (((Score1 + Score2) / 2) * 0.4) + (Score3 * 0.6);
                        String str = String.Format("{0:00.0}", SummaryScore);
                        SummaryScore = double.Parse(str);

                        if (SummaryScore <= 10.0 && SummaryScore >= 8.5)
                        {
                            Scoreword = "A";
                            SummaryScore4 = 4.0;
                        }
                        else if (SummaryScore >= 8.0 && SummaryScore <= 8.4)
                        {
                            Scoreword = "B+";
                            SummaryScore4 = 3.5;
                        }
                        else if (SummaryScore >= 7.0 && SummaryScore <= 7.9)
                        {
                            Scoreword = "B";
                            SummaryScore4 = 3.0;
                        }
                        else if (SummaryScore >= 6.0 && SummaryScore <= 6.4)
                        {
                            Scoreword = "C";
                            SummaryScore4 = 2.0;
                        }
                        else if (SummaryScore >= 6.5 && SummaryScore <= 6.9)
                        {
                            Scoreword = "C+";
                            SummaryScore4 = 2.5;
                        }
                        else if (SummaryScore >= 5.0 && SummaryScore <= 5.9)
                        {
                            Scoreword = "D+";
                            SummaryScore4 = 1.5;
                        }
                        else if (SummaryScore >= 4.0 && SummaryScore <= 4.9)
                        {
                            Scoreword = "D";
                            SummaryScore4 = 1.0;
                        }
                        else if (SummaryScore < 4.0)
                        {
                            Scoreword = "F";
                            SummaryScore4 = 0;
                        }
                        else
                        {
                            MessageBox.Show("Cảnh Báo. Điểm Nhập Ko Hợp Lệ: MSV:" + IdStudent);
                            break;
                        }

                        if (SummaryScore >= 4.0)
                        {
                            Evaluate = true;
                        }
                        else
                        {
                            Evaluate = false;
                        }
                    }
                    var item = new ScoreStudentRequest()
                    {
                        StudentId = IdStudent,
                        SubjectId = subjectId,
                        NumberStudy = NumberStudy,
                        Semester = Semester,
                        Score1 = Score1,
                        Score2 = Score2,
                        Score3 = Score3,
                        SummaryScore = SummaryScore,
                        SummaryScore4 = SummaryScore4,
                        Scoreword = Scoreword,
                        Evaluate = Evaluate
                    };
                    result.Add(item);
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static List<SaveScoreByLectureRequest> CreateRequestScoreByLecture(DataGridView dgrid)
        {
            try
            {
                var result = new List<SaveScoreByLectureRequest>();
                for (int i = 0; i < dgrid.Rows.Count; i++)
                {
                    int Id = (int)dgrid.Rows[i].Cells[0].Value;
                    double? Score1 = null;
                    double? Score2 = null;
                    double? Score3 = null;
                    double? SummaryScore = null;
                    double? SummaryScore4 = null;
                    string Scoreword = null;
                    bool? Evaluate = null;



                    if (dgrid.Rows[i].Cells[5].Value != null)
                    {
                        Score1 = double.Parse(dgrid.Rows[i].Cells[5].Value.ToString());
                    }
                    if (dgrid.Rows[i].Cells[6].Value != null)
                    {
                        Score2 = double.Parse(dgrid.Rows[i].Cells[6].Value.ToString());
                    }
                    if (dgrid.Rows[i].Cells[7].Value != null)
                    {
                        Score3 = double.Parse(dgrid.Rows[i].Cells[7].Value.ToString());
                    }

                    if (Score1 != null && Score2 != null && Score3 != null)
                    {
                        if (Score1 > 10 || Score2 > 10 || Score3 > 10)
                        {
                            MessageBox.Show("Cảnh Báo. Điểm Nhập Ko Hợp Lệ: Id:" + Id);
                            break;
                        }

                        SummaryScore = (((Score1 + Score2) / 2) * 0.4) + (Score3 * 0.6);
                        string str = string.Format("{0:00.0}", SummaryScore);
                        SummaryScore = double.Parse(str);

                        if (SummaryScore <= 10.0 && SummaryScore >= 8.5)
                        {
                            Scoreword = "A";
                            SummaryScore4 = 4.0;
                        }
                        else if (SummaryScore >= 8.0 && SummaryScore <= 8.4)
                        {
                            Scoreword = "B+";
                            SummaryScore4 = 3.5;
                        }
                        else if (SummaryScore >= 7.0 && SummaryScore <= 7.9)
                        {
                            Scoreword = "B";
                            SummaryScore4 = 3.0;
                        }
                        else if (SummaryScore >= 6.0 && SummaryScore <= 6.4)
                        {
                            Scoreword = "C";
                            SummaryScore4 = 2.0;
                        }
                        else if (SummaryScore >= 6.5 && SummaryScore <= 6.9)
                        {
                            Scoreword = "C+";
                            SummaryScore4 = 2.5;
                        }
                        else if (SummaryScore >= 5.0 && SummaryScore <= 5.9)
                        {
                            Scoreword = "D+";
                            SummaryScore4 = 1.5;
                        }
                        else if (SummaryScore >= 4.0 && SummaryScore <= 4.9)
                        {
                            Scoreword = "D";
                            SummaryScore4 = 1.0;
                        }
                        else if (SummaryScore < 4.0)
                        {
                            Scoreword = "F";
                            SummaryScore4 = 0;
                        }
                        else
                        {
                            MessageBox.Show("Cảnh Báo. Điểm Nhập Ko Hợp Lệ: Id:" + Id);
                            break;
                        }

                        if (SummaryScore >= 4.0)
                        {
                            Evaluate = true;
                        }
                        else
                        {
                            Evaluate = false;
                        }
                    }
                    var item = new SaveScoreByLectureRequest()
                    {
                        Id = Id,
                        Score1 = Score1,
                        Score2 = Score2,
                        Score3 = Score3,
                        SummaryScore = SummaryScore,
                        SummaryScore4 = SummaryScore4,
                        Scoreword = Scoreword,
                        Evaluate = Evaluate
                    };
                    result.Add(item);
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
