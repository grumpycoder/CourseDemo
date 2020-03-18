namespace CourseDemo.Domain.Models
{
    public class ProgramAssignment
    {
        public int Id { get; set; }

        public int BeginYear { get; set; }
        public int? EndYear { get; set; }
        
        public virtual Program Program { get; set; }
        public virtual Course Course { get; set; }

        protected ProgramAssignment(){}
        public ProgramAssignment(Program careerTechProgram, Course course, int beginYear, int? endYear)
        {
            Program = careerTechProgram;
            Course = course;
            BeginYear = beginYear;
            EndYear = endYear; 
        }
    }
}