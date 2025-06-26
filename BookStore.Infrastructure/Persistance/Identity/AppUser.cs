using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Persistance.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
    }
}