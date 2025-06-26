using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandResponse
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public List<string>? Errors { get; set; }
    }
}