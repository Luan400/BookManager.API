using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Entities
{
    public class Loans : BaseEntity
    {
        public Loans(int userId, int bookId, DateTime dataEmprestimo)
        {
            UserId = userId;
            BookId = bookId;
            DataEmprestimo = dataEmprestimo;
        }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public void Update(int userId, int bookId, DateTime dataEmprestimo)
        {
            UserId = userId;
            BookId = bookId;
            DataEmprestimo = dataEmprestimo;
        }
    }
}
