using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, List<LoansViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLoansQueryHandler(IUnitOfWork unitOfWork)
        {


            _unitOfWork = unitOfWork;
        }

        public async Task<List<LoansViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _unitOfWork.LoanRepository.GetAllAsync();

            var loansViewModel = loans.Select(
                p => new LoansViewModel(
                    p.UserId,
                    p.BookId,
                    p.DataEmprestimo)).ToList();

            return loansViewModel;
        }
    }
}
