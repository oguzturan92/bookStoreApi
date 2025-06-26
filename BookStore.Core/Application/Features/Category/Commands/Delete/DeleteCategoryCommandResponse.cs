using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommandResponse
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}