using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.BookDtos;
using BookStore.Core.Domain.Entities;

namespace Application.Interfaces.IReadRepositories
{
    public interface IBookReadRepository : IReadRepository<Book>
    {
        Task<GetBookDto?> GetByIdBookAsync(int bookId);
    }
}