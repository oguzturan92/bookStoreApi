using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Book.Commands.Delete
{
    public class DeleteBookCommandRequest : IRequest<DeleteBookCommandResponse>
    {
        public int BookId { get; set; }
    }
}