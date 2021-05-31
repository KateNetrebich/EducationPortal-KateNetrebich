namespace EducationPortal.Data.Entities
{
    public class VideoMaterial : Material
    {
        public VideoMaterial()
        {

        }

        public VideoMaterial(string name, string descriptoin) : base(name, descriptoin)
        {
            Name = name;
            Description = descriptoin;
        }
    }
}
