﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Application.Model
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
