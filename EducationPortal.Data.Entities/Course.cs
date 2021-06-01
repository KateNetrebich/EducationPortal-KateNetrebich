using System.Collections.Generic;

namespace EducationPortal.Data.Entities
{
    public class Course
    {
        public Course()
        {

        }

        public Course(long id, string name, string description,List<long> materialsIds)
        {
            Id = id;
            Name = name;
            Description = description;
            MaterialsIds = materialsIds;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<long> MaterialsIds { get; set; }

    }
}
