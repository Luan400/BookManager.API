using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Entities
{
    public class Book : BaseEntity
    {
        public Book(string? title, string? autor, string? iSBN, int anoPublicacao, bool active)
        {
            Title = title;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
            Active = true;
        }

        public string? Title { get; set; }

        public string? Autor { get; set; }

        public string? ISBN { get; set; }

        public int AnoPublicacao { get; set; }

        public bool Active { get; set; }

        public void Delete(bool active)
        {
            Active = active;
        }

        public void Update(string? title, string? autor, string? iSBN, int anoPublicacao)
        {
            Title = title;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }
    }
}
