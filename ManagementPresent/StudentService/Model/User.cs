using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace StudentService.Model
{
    [DataContract]
    public class User
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
        public string UserLogin { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public DateTime DayOfBirth { get; set; }
        [DataMember]
        public int UserType { get; set; }
        [DataMember]
        public int? ClassId { get; set; }
        [DataMember]
        public int? FacultyId { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public Byte[] Avatar { get; set; }
    }


    [DataContract]
    public class UserViewModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public DateTime DayOfBirth { get; set; }
        [DataMember]
        public long Total { get; set; }
    }
}
