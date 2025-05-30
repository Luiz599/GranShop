using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GranShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProdutosController(AppDbContext db)
    {
        _db = db;
    }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _db.Produtos
            .Include(m => m.Categoria)
            .ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _db.Produtos
                .Include(m => m.Categoria)
                .FirstOrDefault(m => m.Id == id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Produto informado com problemas");
            _db.Produtos.Add(produto);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), produto.Id, new { produto });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid || id != produto.Id)
                return BadRequest("Produto informada com problemas");
            _db.Produtos.Update(produto);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _db.Produtos.Find(id);
            if (produto == null)
                return NotFound();
            _db.Produtos.Remove(produto);
            _db.SaveChanges();
            return NoContent();
        }
    }
}