using System;

namespace EducationPortal.Data.Entities
{
    public class ArticleMaterial : Material
    {
        public ArticleMaterial()
        {

        }

        public ArticleMaterial(string name, string description, string url, string publicationDate) : base(name, description)
        {
            Name = name;
            Description = description;
            URL = url;
            PublicationDate = publicationDate;
        }

        public string URL { get; set; }
        public string PublicationDate { get; set; }
    }
}
