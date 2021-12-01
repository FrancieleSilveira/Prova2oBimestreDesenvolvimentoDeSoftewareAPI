using System;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Venda venda)
        {
            //produto.Categoria = _context.Categorias.Find(produto.CategoriaId);
            venda.Cliente = _context.Usuarios.Find(venda.ClienteId);
            venda.FormaPagto = _context.FormasPagamento.Find(venda.FormaPgtoId);
            venda.Itens  = _context.ItensVenda.Where(ItemVenda => ItemVenda.CarrinhoId == ItemVenda.CarrinhoId).ToList();
            
           
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }


        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        
        {
            return Ok(_context.Vendas
            .Include(fPgto => fPgto.FormaPagto)
            .Include(cliente => cliente.ClienteId)
            .Include(itens => itens.Itens)
            .ToList());
        }

        [HttpGet]
        [Route("list/{id}")]
        public IActionResult ListByCart([FromRoute] int id){
             
            var venda = _context.Vendas.Where(v => v.VendaId == id).ToList();

            return Ok(venda);


        }


    }
}