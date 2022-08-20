using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class CourseRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
