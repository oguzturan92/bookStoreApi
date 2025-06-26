using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Queries.GetAll
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQueryRequest, List<GetAllBooksQueryResponse>>
    {
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IBookReadRepository bookReadRepository, IMapper mapper)
        {
            _bookReadRepository = bookReadRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllBooksQueryResponse>> Handle(GetAllBooksQueryRequest request, CancellationToken cancellationToken)
        {
            var books = await _bookReadRepository.GetAllAsync();
            return _mapper.Map<List<GetAllBooksQueryResponse>>(books);
        }
    }
}