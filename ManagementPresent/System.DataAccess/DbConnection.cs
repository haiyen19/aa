using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DataAccess
{
    public sealed class DbConnection
    {
        public static string Get()
        {
            return @"Data Source=DESKTOP-AD0QG58\THANHVAN;Initial Catalog=StudentManagent_WCF;User ID=sa;Password=vanto1999;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
