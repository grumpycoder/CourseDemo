namespace CourseDemo.Domain.Models
{
    public class ProgramAssignment
    {
        public int Id { get; set; }

        public virtual ValidPeriod ValidPeriod { get; private set; }
        
        public virtual Program Program { get; set; }
        public virtual Course Course { get; set; }

        protected ProgramAssignment(){}
        public ProgramAssignment(Program careerTechProgram, Course course, ValidPeriod validPeriod)
        {
            Program = careerTechProgram;
            Course = course;
            ValidPeriod = validPeriod;
        }
    }
}