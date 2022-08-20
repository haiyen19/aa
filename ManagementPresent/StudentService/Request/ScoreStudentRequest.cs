using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class ScoreStudentRequest
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int NumberStudy { get; set; }
        public int Semester { get; set; }
        public double? Score1 { get; set; }
        public double? Score2 { get; set; }
        public double? Score3 { get; set; }
        public double? SummaryScore { get; set;}
        public double? SummaryScore4 { get; set; }
        public string Scoreword { get; set; }
        public bool? Evaluate { get; set; }
    }
}
