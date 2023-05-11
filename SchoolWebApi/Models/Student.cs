using SchoolWebApi.Models.Base;

namespace SchoolWebApi.Models
{
    public class Student: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }
        public int Phone { get; set; } 
        public int Age { get; set; }
        public string Address { get; set; }
        public string StudentIdentify { get; set; }
        public Career Career { get; set; }
    }
}
