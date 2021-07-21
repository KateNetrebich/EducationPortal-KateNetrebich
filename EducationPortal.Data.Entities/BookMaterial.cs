using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Data.Entities
{
    public class BookMaterial : Material
    {
        public BookMaterial()
        {

        }
        public BookMaterial(string name, string description, string author, int pageNumber, DateTime year, string url) : base(name, description, url)
        {
            Name = name;
            Description = description;
            URL = url;
            Author = author;
            PageNumber = pageNumber;
            YearOfPublication = year;
        }

        public string Author { get; set; }
        public int PageNumber { get; set; }
        public DateTime YearOfPublication { get; set; }
    }
}
