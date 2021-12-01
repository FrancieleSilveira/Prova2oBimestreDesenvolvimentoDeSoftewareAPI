using System;
using System.Collections.Generic;
using API.Models;

namespace API.Models
{
    public class Venda
    {
        public Venda() => CriadoEm = DateTime.Now;
        public int VendaId { get; set; }
        public Usuario Cliente { get; set; }
        public int ClienteId { get; set; }
        public int FormaPgtoId { get; set; }
        public FormaPagamento FormaPagto { get; set; }
        public List<ItemVenda> Itens { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}