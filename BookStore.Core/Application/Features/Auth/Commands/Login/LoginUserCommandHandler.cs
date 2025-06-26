using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.AppUserDtos;
using Application.Services;
using FluentValidation;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IValidator<LoginUserCommandRequest> _validator;

        public LoginUserCommandHandler(IUserService userService, IValidator<LoginUserCommandRequest> validator)
        {
            _userService = userService;
            _validator = validator;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new LoginUserCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var loginDto = new LoginUserDto
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _userService.LoginAsync(loginDto);

            return new LoginUserCommandResponse
            {
                Success = result.Success,
                Token = result.Token,
                Errors = result.Errors
            };
        }
    }
}