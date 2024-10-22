using BookManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }

        IDevolutionRepository DevolutionRepository { get; }

        ILoanRepository LoanRepository { get; }

        IUserRepository UserRepository { get; }

        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

        Task<int> CompleteAsync();

        Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;

    }
}
