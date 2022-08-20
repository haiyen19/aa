using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace StudentService.Model
{
    [DataContract]
    public class Profiles
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string IdCard { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public DateTime DayOfBirth { get; set; }
        [DataMember]
        public string FacultyName { get; set; }
        [DataMember]
        public Byte[] Avatar { get; set; }
    }

    [DataContract]
    public class ProfilesStudent : Profiles
    {
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string CourseName { get; set; }
    }
}
