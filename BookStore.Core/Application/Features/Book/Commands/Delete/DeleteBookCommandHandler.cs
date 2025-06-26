using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfaces.IReadRepositories;
using Application.Interfaces.IWriteRepositories;
using MediatR;

namespace Application.Features.Book.Commands.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, DeleteBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookReadRepository _bookReadRepository;

        public DeleteBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
        }

        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookReadRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                return new DeleteBookCommandResponse
                {
                    Success = false,
                    Errors = new List<string> { "Kitap bulunamadı." }
                };
            }

            await _bookWriteRepository.DeleteAsync(book);

            return new DeleteBookCommandResponse { Success = true };
        }
    }
}