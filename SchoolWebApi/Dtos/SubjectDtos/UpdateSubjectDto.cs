using SchoolWebApi.Models;

namespace SchoolWebApi.Dtos.SubjectDtos
{
    public class UpdateSubjectDto:BaseDto
    {
        public string Name { get; set; }
        public Career Career { get; set; }
    }
}
