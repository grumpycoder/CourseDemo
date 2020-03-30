namespace CourseDemo.Domain.Dtos
{
    public class UpdateCredentialDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BeginYear { get; set; }
        public int EndYear { get; set; }

        public bool IsReimbursable { get; set; }
    }
}