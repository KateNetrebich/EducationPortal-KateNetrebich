using EducationPortal.Application.Model;
using EducationPortal.Application.Repositories;
using EducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationPortal.Application.Service
{
    public class MaterialService : IMaterialService
    {
        private IMaterialRepository _repository;
        public MaterialService(IMaterialRepository repository)
        {
            _repository = repository;
        }
        public async Task<Material> CreateMaterial(CreateMaterialRequest request)
        {
            if(request is CreateArticleRequest)
            {
                CreateArticleRequest articleRequest = (CreateArticleRequest)request;
                var article = new ArticleMaterial
                {
                    Id = articleRequest.Id,
                    Name = articleRequest.Name,
                    Description = articleRequest.Description,
                    URL = articleRequest.URL,
                    PublicationDate =articleRequest.PublicationDate
                };
                await _repository.CreatAsync(article);
                return article;
            }
            if(request is CreateVideoRequest)
            {
                CreateVideoRequest videoRequest = (CreateVideoRequest)request;
                var video = new VideoMaterial
                {
                    Id = videoRequest.Id,
                    Name = videoRequest.Name,
                    Description = videoRequest.Description,
                    Duration = videoRequest.Duration,
                    Quality = videoRequest.Quality
                };
                await _repository.CreatAsync(video);
                return video;
            }
            if(request is CreateBookRequest)
            {
                CreateBookRequest bookRequest = (CreateBookRequest)request;
                var book = new BookMaterial
                {
                    Id=bookRequest.Id,
                    Name = bookRequest.Name,
                    Description = bookRequest.Description,
                    Author = bookRequest.Author,
                    PageNumber = bookRequest.PageNumber,
                    YearOfPublication = bookRequest.YearOfPublication
                };
                await _repository.CreatAsync(book);
                return book;
            }
            throw new NotImplementedException();
        }

        public async Task<Material> Get(Material material)
        {
            return await _repository.FindAsync(material.Id);
        }

        public IEnumerable<Material> GetByCourse(Course course)
        {
            return course.Materials;
        }

    }
}
