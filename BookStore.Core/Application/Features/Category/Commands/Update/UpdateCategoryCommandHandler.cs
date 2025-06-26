using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using Application.Interfaces.IWriteRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository CategoryWriteRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = CategoryWriteRepository;
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return new UpdateCategoryCommandResponse
                {
                    Success = false,
                    Errors = new List<string> { "Kategori bulunamadı." }
                };
            }

            _mapper.Map(request, category);

            await _categoryWriteRepository.UpdateAsync(category);

            return new UpdateCategoryCommandResponse { Success = true };
        }
    }
}