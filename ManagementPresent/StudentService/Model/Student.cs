using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Model
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int EntityId { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public long Index { get; set; }
        [DataMember]
        public string FacutlyName { get; set; }
        [DataMember]
        public int IdFacutly { get; set; }
        [DataMember]
        public Byte[] Avatar { get; set; }

    }
}
