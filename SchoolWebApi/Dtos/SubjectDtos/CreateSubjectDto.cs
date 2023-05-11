using SchoolWebApi.Dtos.CarrerDtos;

namespace SchoolWebApi.Dtos.SubjectDtos
{
    public class CreateSubjectDto
    {
        public string Name { get; set; }
        public CareerDto Career { get; set; }
    }
}
