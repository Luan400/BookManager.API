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
    public class LoansRepository : ILoanRepository
    {
        private readonly BookManagerDbContext _dbContext;
        public LoansRepository(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Loans>> AddAsync(Loans loans)
        {
            await _dbContext.Loans.AddAsync(loans);

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Loans.ToListAsync();
        }

        public async Task<List<Loans>> GetAllAsync()
        {
            return await _dbContext.Loans.ToListAsync();
        }

        public async Task<Loans> GetByIdAsync(int id)
        {
            return await _dbContext.Loans.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
