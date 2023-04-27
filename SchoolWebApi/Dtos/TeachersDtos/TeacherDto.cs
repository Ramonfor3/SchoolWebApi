namespace SchoolWebApi.Dtos.TeachersDto
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LasName { get; set; }
        public int? SubjectId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
    }
}
