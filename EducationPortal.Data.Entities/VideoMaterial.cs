namespace EducationPortal.Data.Entities
{
    public class VideoMaterial : Material
    {
        public VideoMaterial()
        {

        }

        public VideoMaterial(string name, string descriptoin, string duration, string quality) : base(name, descriptoin)
        {
            Name = name;
            Description = descriptoin;
            Duration = duration;
            Quality = quality;
        }
        public string Duration { get; set; }
        public string Quality { get; set; }
    }
}
