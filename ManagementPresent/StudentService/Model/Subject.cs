using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Model
{
    [DataContract]
    public class Subject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Credits { get; set; }
        [DataMember]
        public int Semester { get; set; }
        [DataMember]
        public bool UsedCalculate { get; set; }
        [DataMember]
        public int? FacultyId { get; set; }
        [DataMember]
        public long Total { get; set; }
        [DataMember]
        public string FacultyName { get; set; }
    }
}
