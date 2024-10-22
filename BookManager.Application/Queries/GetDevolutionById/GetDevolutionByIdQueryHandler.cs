using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.GetDevolutionById
{
    public class GetDevolutionByIdQueryHandler : IRequestHandler<GetDevolutionByIdQuery, List<DevolutionViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDevolutionByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DevolutionViewModel>> Handle(GetDevolutionByIdQuery request, CancellationToken cancellationToken)
        {
            var devolution = await _unitOfWork.DevolutionRepository.GetByIdAsync(request.Id);

            if (devolution == null)
            {

                return null;
            }

            var devolutionViewModel = new DevolutionViewModel(
                devolution.DataDevolucao
               );

            return new List<DevolutionViewModel>() { devolutionViewModel };
        }
    }

}
