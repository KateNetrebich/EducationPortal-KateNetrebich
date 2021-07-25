using EducationPortal.Models;
using System;

namespace EducationPortal.Data.Entities
{
    public class CourseResult
    {
        public CourseResult()
        {

        }
        public CourseResult(DateTime dateTime, CourseResultCondition condition)
        {
            CourseDateTime = dateTime;
            Condition = condition;
        }

        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime CourseDateTime { get; set; }
        public CourseResultCondition Condition { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
