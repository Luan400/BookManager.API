using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Domain.Entities
{
    public class Devolution : BaseEntity
    {
        public Devolution(DateTime dataDevolucao)
        {
            DataDevolucao = dataDevolucao;
        }

        public DateTime DataDevolucao { get; set; }
    }
}
