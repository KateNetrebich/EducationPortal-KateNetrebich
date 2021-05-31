using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Repositories.FileRepository
{
    public abstract class FileRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        protected Dictionary<TKey, TEntity> _entities;
        public abstract void Import();
        public abstract void Export();
        public FileRepositoryBase(string filename)
        {
            FileName = filename;
            _entities = new Dictionary<TKey, TEntity>();
        }
        public string FileName { get; set; }
        public void Create(TEntity entity, TKey key)
        {
            _entities.Add(key, entity);
            Export();
        }

        public void Delete(TKey key)
        {
            _entities.Remove(key);
            Export();
        }

        public TEntity Get(TKey key)
        {
            return _entities[key];
        }

        public List<TEntity> List()
        {
            return _entities.Values.ToList();
        }

        public void Update(TKey key, TEntity entity)
        {
            _entities[key] = entity;
            Export();
        }
    }
}
