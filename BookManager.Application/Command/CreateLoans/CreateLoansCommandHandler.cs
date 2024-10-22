using BookManager.Domain.Entities;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Command.CreateLoans
{
    public class CreateLoansCommandHandler : IRequestHandler<CreateLoansCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateLoansCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateLoansCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loans(request.UserId, request.BookdId, request.DataEmprestimo);

            await _unitOfWork.AddAsync(loan);

            await _unitOfWork.CompleteAsync();


            return loan.Id;
        }
    }
}
