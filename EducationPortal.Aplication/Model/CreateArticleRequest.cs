namespace EducationPortal.Application.Model
{
    public class CreateArticleRequest : CreateMaterialRequest
    {
        public string URL { get; set; }
        public string PublicationDate { get; set; }
    }
}
