using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Book.Commands.Update
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommandRequest>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().WithMessage("Id boş olamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Yazar boş olamaz.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat pozitif olmalıdır.");
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("Stok pozitif olmalıdır.");
        }
    }
}