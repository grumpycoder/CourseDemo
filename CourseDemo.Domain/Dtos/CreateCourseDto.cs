using System.Reflection;

namespace CourseDemo.Domain.Dtos
{
    public class CreateCourseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int BeginYear { get; set; }
        public int? EndYear { get; set; }

        public int LowGradeId { get; set; }
        public int HighGradeId { get; set; }
        
    }
}