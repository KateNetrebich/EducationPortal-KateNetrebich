﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Application.Model
{
    public class CreateVideoRequest : CreateMaterialRequest
    {
        public string Duration { get; set; }
        public string Quality { get; set; }
    }
}
