using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public class ArticleMaterial : Material
    {
        public ArticleMaterial()
        {

        }

        public ArticleMaterial(string name, string description, string url, DateTime publicationDate) : base(name, description,url)
        {
            Name = name;
            Description = description;
            URL = url;
            PublicationDate = publicationDate;
        }

        public DateTime PublicationDate { get; set; }
    }
}
