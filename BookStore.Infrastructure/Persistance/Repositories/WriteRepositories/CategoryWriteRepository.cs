using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.IWriteRepositories;
using BookStore.Core.Domain.Entities;
using BookStore.Infrastructure.Persistance.Concrete;

namespace Persistance.Repositories.WriteRepositories
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        private readonly AppDbContext _appContext;

        public CategoryWriteRepository(AppDbContext context) : base(context)
        {
            _appContext = context;
        }
    }
}