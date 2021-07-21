using EducationPortal.Data.Entities;
using System;

namespace EducationPortal.Application.Model
{
    public class CreateCourseResultRequest
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime CourseDateTime { get; set; }
        public CourseResultCondition Condition { get; set; }
    }
}
