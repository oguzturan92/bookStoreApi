using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.AppUserDtos
{
    public class LoginUserDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}