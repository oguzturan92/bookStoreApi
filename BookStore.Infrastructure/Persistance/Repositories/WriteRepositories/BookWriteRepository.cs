using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.IWriteRepositories;
using BookStore.Core.Domain.Entities;
using BookStore.Infrastructure.Persistance.Concrete;

namespace Persistance.Repositories.WriteRepositories
{
    public class BookWriteRepository : WriteRepository<Book>, IBookWriteRepository
    {
        private readonly AppDbContext _appContext;

        public BookWriteRepository(AppDbContext context) : base(context)
        {
            _appContext = context;
        }
    }
}