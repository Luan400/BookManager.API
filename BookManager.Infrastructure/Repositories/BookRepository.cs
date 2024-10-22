using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using BookManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookManagerDbContext _dbContext;
        public BookRepository(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Book.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Book.SingleOrDefaultAsync(p => p.Id == id);

        }
    }
}
