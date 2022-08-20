using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Model
{
    [DataContract]
    public class OpenClassModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public string LectureName { get; set; }
        [DataMember]
        public DateTime StartDate { get; set;}
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public int Credits { get; set; }
        [DataMember]
        public int TotalRegist { get; set; }
        [DataMember]
        public int MaxStudent { get; set; }
    }
}
