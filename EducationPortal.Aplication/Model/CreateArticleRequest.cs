using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Application.Model
{
    public class CreateArticleRequest : CreateMaterialRequest
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
    }
}
