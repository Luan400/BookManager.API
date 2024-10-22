using BookManager.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.GetAllDevolution
{
    public class GetAllDevolutionQuery : IRequest<List<DevolutionViewModel>>
    {
        public GetAllDevolutionQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
