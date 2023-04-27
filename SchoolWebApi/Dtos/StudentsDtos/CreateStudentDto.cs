namespace SchoolWebApi.Dtos.StudentsDto
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
