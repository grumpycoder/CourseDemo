namespace CourseDemo.Domain.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ValidPeriod ValidPeriod { get; private set; }
        
        public bool? TraditionalForMales { get; set; }
        public bool? TraditionalForFemales { get; set; }

    }
}