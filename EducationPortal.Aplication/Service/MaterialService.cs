using EducationPortal.Application.Model;
using EducationPortal.Data;
using EducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Application.Service
{
    public class MaterialService : IMaterialService
    {
        private IMaterialRepository _repository;
        public MaterialService(IMaterialRepository repository)
        {
            _repository = repository;
        }
        public Material CreateMaterial(CreateMaterialRequest request)
        {
            if(request is CreateArticleRequest)
            {
                CreateArticleRequest articleRequest = (CreateArticleRequest)request;
                var article = new ArticleMaterial
                {
                    Id = DateTime.Now.ToFileTime(),
                    Name = articleRequest.Name,
                    Description = articleRequest.Description,
                    URL = articleRequest.URL,
                    PublicationDate = articleRequest.PublicationDate
                };
                _repository.Create(article, article.Id);
                return article;
            }
            if(request is CreateVideoRequest)
            {
                CreateVideoRequest videoRequest = (CreateVideoRequest)request;
                var video = new VideoMaterial
                {
                    Id = DateTime.Now.ToFileTime(),
                    Name = videoRequest.Name,
                    Description = videoRequest.Description,
                    Duration = videoRequest.Duration,
                    Quality = videoRequest.Quality
                };
                _repository.Create(video, video.Id);
                return video;
            }
            if(request is CreateBookRequest)
            {
                CreateBookRequest bookRequest = (CreateBookRequest)request;
                var book = new BookMaterial
                {
                    Id=DateTime.Now.ToFileTime(),
                    Name = bookRequest.Name,
                    Description = bookRequest.Description,
                    Author = bookRequest.Author,
                    PageNumber = bookRequest.PageNumber,
                    YearOfPublication = bookRequest.YearOfPublication
                };
                _repository.Create(book, book.Id);
                return book;
            }
            throw new NotImplementedException();
        }

        public List<Material> GetAll()
        {
            return _repository.List();
        }

        public List<Material> GetByCourse(Course course)
        {
            return course.MaterialsIds.Select(id => _repository.Get(id)).ToList();
        }

    }
}
