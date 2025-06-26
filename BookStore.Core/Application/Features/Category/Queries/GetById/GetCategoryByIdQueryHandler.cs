using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryReadRepository CategoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = CategoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
                throw new Exception("Kategori bulunamadı.");

            return _mapper.Map<GetCategoryByIdQueryResponse>(category);
        }
    }
}