using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IWriteRepositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Book.Commands.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookCommandRequest> _validator;

        public CreateBookCommandHandler(
            IBookWriteRepository bookWriteRepository,
            IMapper mapper,
            IValidator<CreateBookCommandRequest> validator)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
        {
            // Validation
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new CreateBookCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            // Mapping
            // var book = _mapper.Map<BookStore.Core.Domain.Entities.Book>(request);

            // Book ile birlikte BookCategory de eklenecekse manuel map uygularız.
            var book = new BookStore.Core.Domain.Entities.Book
            {
                Title = request.Title,
                Author = request.Author,
                Price = request.Price,
                Stock = request.Stock,
                BookCategories = request.CategoryIds.Select(categoryId => new BookCategory
                {
                    CategoryId = categoryId
                }).ToList()
            };

            // Repository'e gönderilir
            await _bookWriteRepository.AddAsync(book);

            return new CreateBookCommandResponse
            {
                Success = true,
                BookId = book.BookId
            };
        }
    }
}