using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using Application.Interfaces.IWriteRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IMapper _mapper;
        private readonly IBookReadRepository _bookReadRepository;

        public UpdateBookCommandHandler(IBookWriteRepository bookWriteRepository, IMapper mapper, IBookReadRepository bookReadRepository)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
            _bookReadRepository = bookReadRepository;
        }

        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookReadRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                return new UpdateBookCommandResponse
                {
                    Success = false,
                    Errors = new List<string> { "Kitap bulunamadı." }
                };
            }

            _mapper.Map(request, book);

            await _bookWriteRepository.UpdateAsync(book);

            return new UpdateBookCommandResponse { Success = true };
        }
    }
}