using BookManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookManagerDbContext _dbContext;
        public UnitOfWork(
            BookManagerDbContext dbContext,
            IBookRepository bookRepository, 
            IDevolutionRepository devolutionRepository, 
            ILoanRepository loanRepository, 
            IUserRepository userRepository
            )
        {
            _dbContext = dbContext;
            BookRepository = bookRepository;
            DevolutionRepository = devolutionRepository;
            LoanRepository = loanRepository;
            UserRepository = userRepository;
        }

        public IBookRepository BookRepository { get; }

        public IDevolutionRepository DevolutionRepository { get; }

        public ILoanRepository LoanRepository { get; }

        public IUserRepository UserRepository { get; }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class 
        {
         await _dbContext.Set<TEntity>().AddAsync(entity);

        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
           _dbContext.Set<TEntity>().Remove(entity);

            await CompleteAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Update(entity);

            await CompleteAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
