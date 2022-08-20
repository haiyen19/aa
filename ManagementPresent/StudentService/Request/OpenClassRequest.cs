using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class OpenClassRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int LecturerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public int MaxStudent { get; set; }
        public int FacultyId { get; set; }
    }
}
