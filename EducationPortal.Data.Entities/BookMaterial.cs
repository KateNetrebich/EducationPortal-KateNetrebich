namespace EducationPortal.Data.Entities
{
    public class BookMaterial : Material
    {
        public BookMaterial()
        {

        }
        public BookMaterial(string name, string description) : base(name, description)
        {
            Name = name;
            Description = description;
        }
    }
}
