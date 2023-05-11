using SchoolWebApi.Models.Base;

namespace SchoolWebApi.Models
{
    public class Teacher:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Subject> Subjects { get; set; } 
    }
}
