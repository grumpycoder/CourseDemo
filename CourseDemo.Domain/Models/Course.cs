﻿using System.Collections.Generic;
using System.Linq;

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
        public string Tags { get; private set; }
        public decimal? CreditUnits { get; private set; }
        
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

        public void UnassignProgram(Program program)
        {
            ProgramAssignment assignment = _programAssignments.FirstOrDefault(x => x.Program == program);

            if (assignment == null) return;

            _programAssignments.Remove(assignment);
        }
    }
}