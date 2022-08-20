using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Model
{
    public class ScoreViewModelByStudent
    {
        public int IdSubject { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }
        public int NumberStudy { get; set; }
        public double? Score1 { get; set; }
        public double? Score2 { get; set; }
        public double? Score3 { get; set; }
        public double? SummaryScore { get; set; }
        public double? SummaryScore4 { get; set; }
        public string Scoreword { get; set; }
        public string Evaluate { get; set; }
    }
}
