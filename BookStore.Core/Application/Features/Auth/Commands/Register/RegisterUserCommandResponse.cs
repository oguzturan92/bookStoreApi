using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterUserCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}