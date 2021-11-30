using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/formaPagamento")]
    public class FormaPagamentoController : ControllerBase
    {
       public readonly DataContext _context;

        public FormaPagamentoController(DataContext context){
            _context = context;
        } 

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] FormaPagamento formaPgto)
        {
            _context.FormasPagamento.Add(formaPgto);
            _context.SaveChanges();
            return Created("", formaPgto);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.FormasPagamento
            .ToList());

        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string nome)
        {
            FormaPagamento formaPgto = _context.FormasPagamento.FirstOrDefault(formaPgto => formaPgto.Nome == nome);

            if (formaPgto == null)
            {
                return NotFound();
            }
            _context.FormasPagamento.Remove(formaPgto);
            _context.SaveChanges();
            return Ok(_context.FormasPagamento.ToList());
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] FormaPagamento formaPgto)
        {
            _context.FormasPagamento.Update(formaPgto);
            _context.SaveChanges();
            return Ok(formaPgto);
        }
        
    }
}