using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.GetLoansById
{
    public class GetLoansByIdQueryHandler : IRequestHandler<GetLoansByIdQuery, List<LoansViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLoansByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LoansViewModel>> Handle(GetLoansByIdQuery request, CancellationToken cancellationToken)
        {
            var loans = await _unitOfWork.LoanRepository.GetByIdAsync(request.Id);

            if (loans == null)
            {

                return null;
            }

            var loansViewModel = new LoansViewModel(
                loans.Id,
                loans.BookId,
                loans.DataEmprestimo
               );

            return new List<LoansViewModel>() { loansViewModel };
        }
    }
}
