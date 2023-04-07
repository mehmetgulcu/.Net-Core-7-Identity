﻿using Microsoft.AspNetCore.Identity;

namespace NetCoreIdentity.Data.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string? ImagePath { get; set; }
        public string Gender { get; set; }
    }
}
