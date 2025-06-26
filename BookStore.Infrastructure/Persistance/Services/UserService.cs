using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.AppUserDtos;
using Application.Services;
using Microsoft.AspNetCore.Identity;
using Persistance.Identity;

namespace Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<(bool Success, List<string>? Errors)> RegisterAsync(RegisterUserDto dto)
        {
            var user = new AppUser
            {
                Name = dto.Name,
                SurName = dto.SurName,
                Email = dto.Email,
                UserName = dto.UserName
            };

            var result = await _userManager.CreateAsync(user, dto.Password!);

            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToList());

            return (true, null);
        }

        public async Task<(bool Success, string? Token, List<string>? Errors)> LoginAsync(LoginUserDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email!);
            if (user == null)
                return (false, null, new List<string> { "Kullanıcı bulunamadı." });

            var result = await _userManager.CheckPasswordAsync(user, dto.Password!);

            if (!result)
                return (false, null, new List<string> { "Şifre hatalı." });

            var token = _tokenService.CreateToken(new JwtUserDto
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!
            });

            return (true, token, null);
        }
    }
}