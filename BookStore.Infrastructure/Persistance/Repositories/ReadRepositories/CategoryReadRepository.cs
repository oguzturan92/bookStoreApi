using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.IReadRepositories;
using BookStore.Core.Domain.Entities;
using BookStore.Infrastructure.Persistance.Concrete;

namespace Persistance.Repositories.ReadRepositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}