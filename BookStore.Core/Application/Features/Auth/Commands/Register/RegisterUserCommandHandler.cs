using Application.Dtos.AppUserDtos;
using Application.Services;
using FluentValidation;
using MediatR;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IValidator<RegisterUserCommandRequest> _validator;

        public RegisterUserCommandHandler(IUserService userService, IValidator<RegisterUserCommandRequest> validator)
        {
            _userService = userService;
            _validator = validator;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new RegisterUserCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var registerDto = new RegisterUserDto
            {
                Name = request.Name,
                SurName = request.SurName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                RePassword = request.RePassword
            };

            var result = await _userService.RegisterAsync(registerDto);

            return new RegisterUserCommandResponse
            {
                Success = result.Success,
                Errors = result.Errors ?? []
            };
        }
    }
}