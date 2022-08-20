using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class TopStudentRequest
    {
        public int SemesterId { get; set; }
        public int FacultyId { get; set; }
        public int CourseId { get; set; }
    }
}
