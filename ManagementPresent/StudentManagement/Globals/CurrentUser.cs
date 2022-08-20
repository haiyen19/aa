using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Globals
{
    public static class CurrentUser
    {
        public static int? UserId { get; set; }
        public static string FullName { get; set; }
        public static int? Roles { get; set; }
    }
}
