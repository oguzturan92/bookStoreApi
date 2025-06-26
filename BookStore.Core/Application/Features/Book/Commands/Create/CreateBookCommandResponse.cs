using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Create
{
    public class CreateBookCommandResponse
    {
        public bool Success { get; set; }
        public int BookId { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}