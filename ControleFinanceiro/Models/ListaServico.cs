using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class ListaServico
    {

        public int ServicoId { get; set; }
        public string ServicoNome { get; set; }
        public string ServicoDescricao { get; set; }

        public ListaServico()
        {
        }

        public ListaServico(int servicoId, string servicoNome, string descricao)
        {
            ServicoId = servicoId;
            ServicoNome = servicoNome;
            ServicoDescricao = descricao;
        }
    }
}
