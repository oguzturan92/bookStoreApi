using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.Domain.Entities;

namespace Application.Interfaces.IWriteRepositories
{
    public interface ICategoryWriteRepository : IWriteRepository<Category>
    {
        
    }
}