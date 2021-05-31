using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace EducationPortal.Repositories.FileRepository
{
    public abstract class JsonRepository<TEntity, TKey> : FileRepositoryBase<TEntity, TKey>
    {
        protected JsonRepository(string filename) : base(filename)
        {
        }

        public override void Export()
        {
            var json = JsonConvert.SerializeObject(_entities, Formatting.Indented);
            File.WriteAllText(FileName, json);
        }

        public override void Import()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                _entities = JsonConvert.DeserializeObject<Dictionary<TKey, TEntity>>(json);
            }
        }
    }
}
