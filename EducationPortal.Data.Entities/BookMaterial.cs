namespace EducationPortal.Data.Entities
{
    public class BookMaterial : Material
    {
        public BookMaterial()
        {

        }
        public BookMaterial(string name, string description, string author, int pageNumber, int year) : base(name, description)
        {
            Name = name;
            Description = description;
            Author = author;
            PageNumber = pageNumber;
            YearOfPublication = year;
        }

        public string Author { get; set; }
        public int PageNumber { get; set; }
        public int YearOfPublication { get; set; }
    }
}
