namespace EducationPortal.Data.Entities
{
    public abstract class Material
    {
        public Material()
        {

        }
        public Material(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
