using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Features.Book.Commands.Create
{
    public class CreateBookCommandRequest : IRequest<CreateBookCommandResponse>
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        
        public List<int> CategoryIds { get; set; } = [];
    }
}