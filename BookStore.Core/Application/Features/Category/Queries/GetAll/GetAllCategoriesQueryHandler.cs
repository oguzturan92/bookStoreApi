using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetAll
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryReadRepository CategoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = CategoryReadRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryReadRepository.GetAllAsync();
            return _mapper.Map<List<GetAllCategoriesQueryResponse>>(categories);
        }
    }
}