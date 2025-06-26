using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.BookDtos;
using Application.Interfaces.IReadRepositories;
using BookStore.Core.Domain.Entities;
using BookStore.Infrastructure.Persistance.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.ReadRepositories
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
        private readonly AppDbContext _appContext;

        public BookReadRepository(AppDbContext context) : base(context)
        {
            _appContext = context;
        }

        public async Task<GetBookDto?> GetByIdBookAsync(int bookId)
        {
            return await _appContext.Books
                                .AsNoTracking()
                                .Where(b => b.BookId == bookId)
                                .Include(b => b.BookCategories)
                                .Select(b => new GetBookDto
                                {
                                    BookId = b.BookId,
                                    Title = b.Title,
                                    Author = b.Author,
                                    Price = b.Price,
                                    Stock = b.Stock,
                                    CategoryIds = b.BookCategories.Select(bc => bc.CategoryId).ToList()
                                })
                                .FirstOrDefaultAsync();
        }
    }
}