using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetById
{
    public class GetBookByIdQueryResponse
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public List<int> CategoryIds { get; set; } = [];
    }
}