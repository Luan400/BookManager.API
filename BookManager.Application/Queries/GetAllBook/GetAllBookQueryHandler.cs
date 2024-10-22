using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Queries.GetAllBook
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, List<BookViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBookQueryHandler(IUnitOfWork unitOfWork) {

            _unitOfWork = unitOfWork;
        }
        public async Task<List<BookViewModel>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetAllAsync();

            var bookViewModel = book.Select(
                p => new BookViewModel(
                p.Title,
                p.Autor,
                p.ISBN,
                p.AnoPublicacao)).ToList();

            return bookViewModel;
        }
    }
}
