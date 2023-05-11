using SchoolWebApi.Models.Base;

namespace SchoolWebApi.Models
{
    public class Subject:BaseEntity
    {
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Career Career { get; set; }   
        public Section Section { get; set; }   
    }
}
