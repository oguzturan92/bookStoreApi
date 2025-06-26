using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandResponse
    {
        public bool Success { get; set; }
        public int CategoryId { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}