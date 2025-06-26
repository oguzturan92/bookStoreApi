using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Book.Queries.GetById
{
    public class GetBookByIdQueryRequest : IRequest<GetBookByIdQueryResponse>
    {
        public int BookId { get; set; }
    }
}