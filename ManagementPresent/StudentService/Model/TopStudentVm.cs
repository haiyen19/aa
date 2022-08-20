using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace StudentService.Model
{
    [DataContract]
    public class TopStudentVm
    {
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public double MediumScore10 { get; set; }
        [DataMember]
        public double MediumScore4 { get; set; }
        [DataMember]
        public int AllCredits { get; set; }
        [DataMember]
        public int ReachCredits { get; set; }
    }
}
