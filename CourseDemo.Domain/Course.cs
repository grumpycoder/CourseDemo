using System;

namespace CourseDemo.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string CourseCode { get; set; }
        public string Description { get; set; }

        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }

        public int? BeginSequence { get; set; }
        public int? EndSequence { get; set; }

        public bool? CreditRecoveryAvailable { get; set; }
        public bool? CreditAdvancementAvailable { get; set; }
        public string CreditTypes { get; set; }
        public string Tags { get; set; }
        public decimal? CreditUnits { get; set; }

        public Grade LowGrade { get; set; }
        public Grade HighGrade { get; set; }

        public CourseType CourseType { get; set; }
        public CourseLevel CourseLevel { get; set; }

        //Navigation Properties
        public int? LowGradeId { get; set; }
        public int? HighGradeId { get; set; }

        public int? CourseLevelId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? SubjectAreaId { get; set; }
    }
}