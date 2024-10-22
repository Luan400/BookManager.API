using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Command.UpdateBook
{
    public class UpdateBookCommand : IRequest<int>
    {
        public UpdateBookCommand(string? title, string? autor, string? iSBN, int anoPublicacao, int id)
        {
            Id = id;
            Title = title;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Autor { get; set; }

        public string? ISBN { get; set; }

        public int AnoPublicacao { get; set; }
    }
}
