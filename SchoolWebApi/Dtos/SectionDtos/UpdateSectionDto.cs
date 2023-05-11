namespace SchoolWebApi.Dtos.SectionDtos
{
    public class UpdateSectionDto:BaseDto
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
