namespace CourseDemo.Domain.Dtos
{
    public class UpdateCourseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BeginYear { get; set; }
        public int? EndYear { get; set; }
        public int BeginSequence { get; set; }
        public int EndSequence { get; set; }
        public bool CreditRecoveryAvailable { get; set; }
        public bool CreditAdvancementAvailable { get; set; }
        public decimal CreditUnits { get; set; }
        
        public int? CourseLevelId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? LowGradeId { get; set; }
        public int? HighGradeId { get; set; }
 
    }
}