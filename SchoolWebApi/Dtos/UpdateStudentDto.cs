﻿namespace SchoolWebApi.Dtos
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
