using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.FileRepositories
{
    public interface IRepository<TEntity, TKey>
    {
        void Create(TEntity entity, TKey key);
    }
}
