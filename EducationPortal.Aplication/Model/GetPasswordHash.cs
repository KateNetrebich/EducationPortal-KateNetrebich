using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Application.Model
{
    public class GetPasswordHash
    {
        public string PasswordHash(string password)
        {
            string hash = null;
            try
            {
                hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, HashType.SHA384, workFactor: 11);
                return hash;
            }
            catch
            {
                return hash;
            }
        }
    }
}
