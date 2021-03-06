﻿using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleFinanceiro.Servico
{
    public class ListaMercadoServicos
    {
        private readonly ControlePessoalContext _context;
        public ListaMercadoServicos(ControlePessoalContext context)
        {
            _context = context;
        }
        public ListaMercado PegarMercadoPorId(int? id)
        {
            var mercado = _context.Mercados.FirstOrDefault(m => m.MercadoId == id);
            _context.Categorias.Where(i => mercado.CategoriaId == i.CategoriaId).Load();
            _context.Formas.Where(i => mercado.FormaId == i.FormaId).Load();
            _context.StatusCompras.Where(i => mercado.StatusId == i.StatusId).Load();
            return mercado;
        }
        public ListaMercado DeletarMercadoPorId(int? id)
        {
            ListaMercado mercado = PegarMercadoPorId(id.Value);
            _context.Mercados.Remove(mercado);
            _context.SaveChanges();
            return mercado;
        }
    }
}
