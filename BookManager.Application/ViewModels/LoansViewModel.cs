using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.ViewModels
{
    public class LoansViewModel
    {
        public LoansViewModel(int userId, int bookId, DateTime dataEmprestimo)
        {
            UserId = userId;
            BookId = bookId;
            DataEmprestimo = dataEmprestimo;
        }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime DataEmprestimo { get; set; }
    }
}
