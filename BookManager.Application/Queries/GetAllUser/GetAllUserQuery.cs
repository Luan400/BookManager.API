using BookManager.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUserQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
