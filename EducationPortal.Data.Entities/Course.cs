using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public class Course
    {
        public Course()
        {

        }

        public Course(int id, string name, string description, string skills, int grade)
        {
            Id = id;
            Name = name;
            Description = description;
            Skills = skills;
            Garde = grade;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public int Garde { get; set; }
        public virtual List<Material> Materials { get; set; }
    }
}
