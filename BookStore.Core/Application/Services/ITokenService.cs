using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.AppUserDtos;

namespace Application.Services
{
    public interface ITokenService
    {
        string CreateToken(JwtUserDto user);
    }
}