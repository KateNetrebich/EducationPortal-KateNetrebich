using EducationPortal.Data.Entities;
using EducationPortal.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Data
{
    public interface IMaterialRepository : IRepository<Material, long>
    {
    }
}
