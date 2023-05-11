using SchoolWebApi.Models.Base;

namespace SchoolWebApi.Models
{
    public class Section:BaseEntity
    {
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
