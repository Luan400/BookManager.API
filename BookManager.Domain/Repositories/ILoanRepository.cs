using BookManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loans>> AddAsync(Loans loans);
        Task<List<Loans>> GetAllAsync();

        Task<Loans> GetByIdAsync(int id);

       
    }
}
