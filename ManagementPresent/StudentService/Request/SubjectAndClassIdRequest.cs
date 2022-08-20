using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class SubjectAndClassIdRequest
    {
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
    }
}
