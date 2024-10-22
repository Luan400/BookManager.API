using BookManager.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Command.UpdateLoans
{
    public class UpdateLoansCommandHandler : IRequestHandler<UpdateLoansCommand, int>
    {

        private readonly IUnitOfWork _unitOfWork;
        public UpdateLoansCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(UpdateLoansCommand request, CancellationToken cancellationToken)
        {
            var loan = await _unitOfWork.LoanRepository.GetByIdAsync(request.BookId);

            if (loan != null) {

                loan.Update(request.UserId, request.BookId, request.DataEmprestimo);

                await _unitOfWork.CompleteAsync(); ;

            }
            return loan.Id;
        }
    }
}
