namespace EducationPortal.Data.Entities
{
    public class ArticleMaterial : Material
    {
        public ArticleMaterial()
        {

        }

        public ArticleMaterial(string name, string description) : base(name, description)
        {
            Name = name;
            Description = description;
        }
    }
}
