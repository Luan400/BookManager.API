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
    public class UserRepository : IUserRepository
    {
        private readonly BookManagerDbContext _dbContext;
        public UserRepository(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task<List<User>> AddAsync(User user)
        {
            await _dbContext.User.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return await _dbContext.User.ToListAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.User.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
