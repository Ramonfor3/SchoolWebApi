namespace SchoolWebApi.Dtos.SectionDtos
{
    public class CreateSectionDto
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
