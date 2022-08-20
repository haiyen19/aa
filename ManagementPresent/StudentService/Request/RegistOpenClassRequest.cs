using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Request
{
    public class RegistOpenClassRequest
    {
        public int IdOpenClass { get; set; }
        public int IdStudent { get; set; }
        public int SemesterId { get; set; }
    }
}
