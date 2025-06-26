using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetAll
{
    public class GetAllCategoriesQueryResponse
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public int SortOrder { get; set; }
    }
}