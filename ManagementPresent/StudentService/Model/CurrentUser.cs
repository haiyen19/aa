using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Model
{
    [DataContract]
    public class CurrentUser
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public int UserType { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
