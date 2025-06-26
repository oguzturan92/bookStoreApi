using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Delete
{
    public class DeleteBookCommandResponse
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}