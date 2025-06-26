using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.Domain.Entities;

namespace Domain.Entities
{
    public class BookCategory
    {
        public Book Book { get; set; } = null!;
        public int BookId { get; set; }
        public Category Category { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}