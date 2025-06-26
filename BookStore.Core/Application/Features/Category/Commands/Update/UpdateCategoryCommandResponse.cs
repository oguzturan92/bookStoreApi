using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}