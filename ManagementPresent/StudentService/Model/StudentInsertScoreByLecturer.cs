using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Model
{
    [DataContract]
    public class StudentInsertScoreByLecturer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public int NumberStudy { get; set; }
        [DataMember]
        public double? Score1 { get; set; }
        [DataMember]
        public double? Score2 { get; set; }
        [DataMember]
        public double? Score3 { get; set; }
    }
}
