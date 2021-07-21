using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public abstract class Material
    {
        public Material()
        {

        }
        public Material(string name, string description, string url)
        {
            Name = name;
            Description = description;
            URL = url;
        }
        public int Id { get; set; }

        
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
