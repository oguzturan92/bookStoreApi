using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IWriteRepositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCategoryCommandRequest> _validator;

        public CreateCategoryCommandHandler(
            ICategoryWriteRepository CategoryWriteRepository,
            IMapper mapper,
            IValidator<CreateCategoryCommandRequest> validator)
        {
            _categoryWriteRepository = CategoryWriteRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            // Validation
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new CreateCategoryCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            // Mapping
            var category = _mapper.Map<BookStore.Core.Domain.Entities.Category>(request);

            // Repository'e gönderilir
            await _categoryWriteRepository.AddAsync(category);

            return new CreateCategoryCommandResponse
            {
                Success = true,
                CategoryId = category.CategoryId
            };
        }
    }
}