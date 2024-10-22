﻿using BookManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Repositories
{
    public interface IBookRepository
    {
      Task<List<Book>> GetAllAsync(); 

      Task<Book> GetByIdAsync(int id);
    }
}
