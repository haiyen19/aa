using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class StudentViewScoreRequest
    {
        public int StudentId { get; set; }
        public int? SemesterId { get; set; }
    }
}
