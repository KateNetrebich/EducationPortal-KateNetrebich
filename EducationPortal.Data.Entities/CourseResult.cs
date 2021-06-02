using System;

namespace EducationPortal.Data.Entities
{
    public class CourseResult
    {
        public CourseResult()
        {

        }
        public int Id { get; set; }
        public string StudentName { get; set; }
        public long CourseId { get; set; }
        public DateTime CourseDateTime { get; set; }
        public CourseResultCondition Condition { get; set; }
    }
}
