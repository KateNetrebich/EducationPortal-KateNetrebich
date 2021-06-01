using EducationPortal.Models;

namespace EducationPortal.Repositories.FileRepository
{
    public class UserJsonRepository : JsonRepository<User, string>, IUserRepository
    {
        public UserJsonRepository(string filename) : base(filename)
        {
        }
    }
}
