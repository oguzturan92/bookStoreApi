using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Book.Queries.GetAll
{
    public class GetAllBooksQueryRequest : IRequest<List<GetAllBooksQueryResponse>>
    {
        
    }
}