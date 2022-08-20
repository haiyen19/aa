using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Model
{
    [DataContract]
    public class Class
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int? CourseId { get; set; }
        [DataMember]
        public int? FacultyId { get; set; }
    }

    [DataContract]
    public class ClassViewModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public string FacultyName { get; set; }
        [DataMember]
        public long Total { get; set; }
    }
}
