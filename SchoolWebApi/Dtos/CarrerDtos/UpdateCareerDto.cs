using SchoolWebApi.Dtos.SubjectDtos;

namespace SchoolWebApi.Dtos.CarrerDtos
{
    public class UpdateCareerDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<SubjectDto> Subjects { get; set; }
    }
}
