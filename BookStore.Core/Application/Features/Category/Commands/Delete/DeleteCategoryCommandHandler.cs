using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using Application.Interfaces.IWriteRepositories;
using MediatR;

namespace Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository CategoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = CategoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return new DeleteCategoryCommandResponse
                {
                    Success = false,
                    Errors = new List<string> { "Kategori bulunamadı." }
                };
            }

            await _categoryWriteRepository.DeleteAsync(category);

            return new DeleteCategoryCommandResponse { Success = true };
        }
    }
}