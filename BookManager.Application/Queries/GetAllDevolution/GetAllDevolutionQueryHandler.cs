using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.GetAllDevolution
{
    public class GetAllDevolutionQueryHandler : IRequestHandler<GetAllDevolutionQuery, List<DevolutionViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDevolutionQueryHandler(IUnitOfWork unitOfWork) {


            _unitOfWork = unitOfWork;
        }

        public async Task<List<DevolutionViewModel>> Handle(GetAllDevolutionQuery request, CancellationToken cancellationToken)
        {
            var devolution = await _unitOfWork.DevolutionRepository.GetAllAsync();

            var devolutionViewModel = devolution.Select(
                p => new DevolutionViewModel(p.DataDevolucao)).ToList();

            return devolutionViewModel;
        }
    }
}
