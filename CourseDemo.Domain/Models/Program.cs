namespace CourseDemo.Domain.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string ProgramCode { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual ValidPeriod ValidPeriod { get; private set; }

        public bool? TraditionalForMales { get; set; }
        public bool? TraditionalForFemales { get; set; }

        protected Program()
        {
        }

        public Program(string name, string description, string programCode, ValidPeriod validPeriod, bool isTraditionalMale, bool isTraditionalFemale)
        {
            ProgramCode = programCode;
            UpdateDetails(name, description, isTraditionalMale, isTraditionalFemale);
            ChangeValidPeriod(validPeriod);
        }

        public void UpdateDetails(string name, string description, bool isTraditionalMale, bool isTraditionalFemale)
        {
            Name = name;
            Description = description;
            TraditionalForMales = isTraditionalMale;
            TraditionalForFemales = isTraditionalFemale;
        }

        public void ChangeValidPeriod(ValidPeriod validPeriod)
        {
            ValidPeriod = validPeriod;
        }
    }
}