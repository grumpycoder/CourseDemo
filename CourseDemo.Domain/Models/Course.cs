using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CourseDemo.Domain.Models
{
    public class Course
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public string CourseCode { get; private set; }
        public string Description { get; private set; }

        public virtual ValidPeriod ValidPeriod { get; private set; }

        public int? BeginSequence { get; private set; }
        public int? EndSequence { get; private set; }

        public bool? CreditRecoveryAvailable { get; private set; }
        public bool? CreditAdvancementAvailable { get; private set; }
        public string CreditTypes { get; private set; }
        public decimal? CreditUnits { get; private set; }
        
        public string Tags { get; private set; }
        
        public virtual Grade LowGrade { get; private set; }
        public virtual Grade HighGrade { get; private set; }

        public virtual CourseType CourseType { get; private set; }
        public virtual CourseLevel CourseLevel { get; private set; }

        private readonly List<ProgramAssignment> _programAssignments = new List<ProgramAssignment>();
        public virtual List<ProgramAssignment> ProgramAssignments => _programAssignments;

        protected Course()
        {
        }

        public void AssignProgram(Program careerTechProgram, ValidPeriod validPeriod)
        {
            ProgramAssignment assignment = _programAssignments.FirstOrDefault(x => x.Program == careerTechProgram);

            if (assignment != null) return;

            var newAssignment = new ProgramAssignment(careerTechProgram, this, validPeriod);
            _programAssignments.Add(newAssignment);
        }

        public void RemoveProgram(Program program)
        {
            ProgramAssignment assignment = _programAssignments.FirstOrDefault(x => x.Program == program);

            if (assignment == null) return;

            _programAssignments.Remove(assignment);
        }

        public void UpdateDetails(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void ChangeValidPeriod(ValidPeriod validPeriod)
        {
            ValidPeriod = validPeriod; 
        }

        public void ChangeCreditDetails(bool isCreditRecovery, bool isCreditAdvancement, decimal creditUnits)
        {
            //TODO: Is CreditRecovery and CreditAdvancement inverse.. both can't be true?
            CreditRecoveryAvailable = isCreditRecovery;
            CreditAdvancementAvailable = isCreditAdvancement;
            CreditUnits = creditUnits; 
        }

        public Result ChangeGradeRange(Grade lowGrade, Grade highGrade)
        {
            if(lowGrade.Id > highGrade.Id) return Result.Failure("Low Grade is higher than High Grade");
            
            LowGrade = lowGrade;
            HighGrade = highGrade; 
            return Result.Success();
        }

        public void ChangeCourseType(CourseType courseType, CourseLevel courseLevel)
        {
            //TODO: Any rules applied to a type of course and a level of a course. ie CourseType=Elementary and CourseLevel=College?
            CourseType = courseType;
            CourseLevel = courseLevel; 
        }
        
    }
}