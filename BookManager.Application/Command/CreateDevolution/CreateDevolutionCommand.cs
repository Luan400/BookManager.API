using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Command.CreateDevolution
{
    public class CreateDevolutionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
