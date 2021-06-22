using EducationPortal.Models;
using System;

namespace EducationPortal.Data.Entities
{
    public class CourseResult
    {
        public CourseResult()
        {

        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime CourseDateTime { get; set; }
        public CourseResultCondition Condition { get; set; }

        public Course Course { get; set; }
        public User User { get; set; }
    }
}
