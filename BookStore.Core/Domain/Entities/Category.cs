using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace BookStore.Core.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public int SortOrder { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; } = [];
    }
}