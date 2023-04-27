using SchoolWebApi.Models.Base;

namespace SchoolWebApi.Models
{
    public class Subject:BaseEntity
    {
        public string Name { get; set; }
        public Career Career { get; set; }   
    }
}
