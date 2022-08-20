using System;
using System.Collections.Generic;
using System.DataAccess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Implement
{
    public class BaseService
    {
        protected Repository _repository = new Repository();
    }
}
