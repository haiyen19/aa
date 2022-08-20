using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Model
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime CourseStart { get; set; }
        [DataMember]
        public DateTime CourseEnd { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool Deleted { get; set; }
        [DataMember]
        public long Total { get; set; }
    }
}
