using EducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EducationPortal.Web.Controllers
{
    public class Claims
    {

        const string CLAIM_USER_ID = "UserId";

        public List<Claim> CreateClaims(User user) 
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Student"),
                new Claim(CLAIM_USER_ID, user.Id.ToString()),
            };
        }

        public int GetUserId(IEnumerable<Claim> claims) 
        {
            var userId = claims
               .Where(x => x.Type == CLAIM_USER_ID)
               .FirstOrDefault()
               .Value;
            return Int32.Parse(userId);
        }
    }
}
