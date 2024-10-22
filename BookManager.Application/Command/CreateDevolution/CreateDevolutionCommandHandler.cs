using BookManager.Domain.Entities;
using BookManager.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Command.CreateDevolution
{
    public class CreateDevolutionCommandHandler : IRequestHandler<CreateDevolutionCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDevolutionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateDevolutionCommand request, CancellationToken cancellationToken)
        {
            var devolution = new Devolution(request.DataDevolucao);

            await _unitOfWork.AddAsync(devolution);

            await _unitOfWork.CompleteAsync();

            return devolution.Id;

        }
    }
}
