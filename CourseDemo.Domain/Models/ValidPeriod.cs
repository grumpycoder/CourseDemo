using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace CourseDemo.Domain.Models
{
    public class ValidPeriod : ValueObject
    {
        public int BeginYear { get; }
        public int? EndYear { get; }

        protected ValidPeriod(){}

        private ValidPeriod(int beginYear, int? endYear)
        {
            
            BeginYear = beginYear;
            EndYear = endYear;
        }

        public static Result<ValidPeriod> Create(int beginYear, int? endYear = 2020)
        {
            //TODO: validation logic guard clauses here
            if(beginYear == null) throw new ArgumentException("End Year cannot be null");
            if(endYear < beginYear)
            {
                return Result.Failure<ValidPeriod>("Begin Year must be before End Year");
            }
            
            return Result.Success(new ValidPeriod(beginYear, endYear));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BeginYear;
            yield return EndYear; 
        }
    }
}