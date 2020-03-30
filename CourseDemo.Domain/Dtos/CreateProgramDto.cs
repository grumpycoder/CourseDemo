namespace CourseDemo.Domain.Dtos
{
    public class CreateProgramDto
    {
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BeginYear { get; set; }
        public int EndYear { get; set; }
        public bool TraditionalForMales { get; set; }
        public bool TraditionalForFemales { get; set; }
    }
}