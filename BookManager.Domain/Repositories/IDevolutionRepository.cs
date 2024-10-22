using BookManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Repositories
{
    public interface  IDevolutionRepository
    {
        Task<List<Devolution>> GetAllAsync();

        Task<Devolution> GetByIdAsync(int id);

        
    }
}
