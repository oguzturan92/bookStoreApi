using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public int SortOrder { get; set; }
    }
}