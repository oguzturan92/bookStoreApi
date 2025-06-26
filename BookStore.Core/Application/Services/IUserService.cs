using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.AppUserDtos;

namespace Application.Services
{
    public interface IUserService
    {
        Task<(bool Success, List<string>? Errors)> RegisterAsync(RegisterUserDto dto);
        Task<(bool Success, string? Token, List<string>? Errors)> LoginAsync(LoginUserDto dto);
    }
}