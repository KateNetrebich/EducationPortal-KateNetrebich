using EducationPortal.Application.Model;
using EducationPortal.Models;
using System.Threading.Tasks;

namespace EducationPortal.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> FindByUserNameAsync(string username);
    }
}
