namespace EducationPortal.Data.Entities
{
    public class VideoMaterial : Material
    {
        public VideoMaterial()
        {

        }

        public VideoMaterial(string name, string description, string duration, string quality) : base(name, description)
        {
            Name = name;
            Description = description;
            Duration = duration;
            Quality = quality;
        }

        public string Duration { get; set; }
        public string Quality { get; set; }
    }
}
