using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommandRequest>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş olamaz.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad boş olamaz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş olamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz.");
            RuleFor(x => x.RePassword).NotEmpty().WithMessage("Şifre tekrarı boş olamaz.");
        }
    }
}