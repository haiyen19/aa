using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class PaginationRequest
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }

    public class FacutylePaginationRequest : PaginationRequest
    {
        public int? FacultyId { get; set; }
    }
}
