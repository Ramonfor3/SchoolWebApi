namespace SchoolWebApi.Dtos.TeachersDto
{
    public class UpdateTeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LasName { get; set; }
        public int? SubjectId { get; set; }
    }
}
