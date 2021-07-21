using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public class VideoMaterial : Material
    {
        public VideoMaterial()
        {

        }

        public VideoMaterial(string name, string description, string duration, string quality, string url) : base(name, description, url)
        {
            Name = name;
            Description = description;
            URL = url;
            Duration = duration;
            Quality = quality;
        }

        public string Duration { get; set; }
        public string Quality { get; set; }
    }
}
