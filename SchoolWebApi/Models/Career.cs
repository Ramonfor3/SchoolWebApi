using SchoolWebApi.Models.Base;

namespace SchoolWebApi.Models
{
    public class Career:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
