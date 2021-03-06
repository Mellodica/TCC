﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class StatusCompra
    {
        [Key]
        public int StatusId { get; set; }
        [Display(Name = "Situação da Compra")]
        public string StatusNome { get; set; }

        public ICollection<ListaDesejo> ListaDesejos { get; set; } = new List<ListaDesejo>();
        public ICollection<ListaMercado> ListaMercados { get; set; } = new List<ListaMercado>();
        public ICollection<DespesaDireta> DespesaDiretas { get; set; } = new List<DespesaDireta>();
        public ICollection<DespesaFixa> DespesaFixas { get; set; } = new List<DespesaFixa>();

        public StatusCompra()
        {

        }

        public StatusCompra(int statusId, string statusNome)
        {
            StatusId = statusId;
            StatusNome = statusNome;
        }
    }
}
