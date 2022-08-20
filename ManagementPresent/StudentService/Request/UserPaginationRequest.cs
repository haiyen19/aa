using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class UserPaginationRequest : PaginationRequest
    {
        public int TypeUser { get; set; }
        public int? ClassId { get; set; }
        public int? FacultyId { get; set; }
        public string NameSearch { get; set; }
    }
}
