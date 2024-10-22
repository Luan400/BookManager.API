using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.ViewModels
{
    public class DevolutionViewModel
    {
        public DevolutionViewModel(DateTime dataDevolucao)
        {
            DataDevolucao = dataDevolucao;
        }

        public DateTime DataDevolucao { get; set; }
    }
}
