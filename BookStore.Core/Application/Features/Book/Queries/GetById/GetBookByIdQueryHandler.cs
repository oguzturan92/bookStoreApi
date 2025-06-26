using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Queries.GetById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQueryRequest, GetBookByIdQueryResponse>
    {
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookReadRepository bookReadRepository, IMapper mapper)
        {
            _bookReadRepository = bookReadRepository;
            _mapper = mapper;
        }

        public async Task<GetBookByIdQueryResponse> Handle(GetBookByIdQueryRequest request, CancellationToken cancellationToken)
        {
            // 1- Generic
            // var book = await _bookReadRepository.GetByIdAsync(request.BookId);

            // 2- Entity'e özel (CategoryIds dahil)
            var book = await _bookReadRepository.GetByIdBookAsync(request.BookId);

            if (book == null)
                throw new Exception("Kitap bulunamadı.");

            return _mapper.Map<GetBookByIdQueryResponse>(book);
        }
    }
}