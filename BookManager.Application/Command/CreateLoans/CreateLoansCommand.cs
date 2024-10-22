using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Command.CreateLoans
{
    public class CreateLoansCommand : IRequest<int>
    {
        public CreateLoansCommand(int userId, int bookdId, DateTime dataEmprestimo)
        {
            UserId = userId;
            BookdId = bookdId;
            DataEmprestimo = dataEmprestimo;
        }

        public int UserId { get; set; }

        public int BookdId { get; set; }

        public DateTime DataEmprestimo { get; set; }
    }
}
