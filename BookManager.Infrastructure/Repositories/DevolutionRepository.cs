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
    public class DevolutionRepository : IDevolutionRepository
    {
        private readonly BookManagerDbContext _dbContext;
        public DevolutionRepository(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Devolution>> AddAsync(Devolution devolution)
        {
            await _dbContext.Devolution.AddAsync(devolution);

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Devolution.ToListAsync();
        }

        public async Task<List<Devolution>> GetAllAsync()
        {
            return await _dbContext.Devolution.ToListAsync();
        }

        public async Task<Devolution> GetByIdAsync(int id)
        {
            return await _dbContext.Devolution.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
