using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(string? title, string? autor, string? iSBN, int anoPublicacao)
        {
            Title = title;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public string? Title { get; set; }

        public string? Autor { get; set; }

        public string? ISBN { get; set; }

        public int AnoPublicacao { get; set; }
    }
}
