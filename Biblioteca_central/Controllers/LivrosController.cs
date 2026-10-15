using Biblioteca_central.Data;
using Biblioteca_central.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlibiotecaCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LivrosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivro()
        {
            return await _context.livro.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> PostAgendamento(Livro livros)
        {
            _context.livro.Add(livros);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLivro), new { id = livros }, livros);
        }
        [HttpPut]
        public async Task<IActionResult> PutLivro(int id, Livro livros)
        {
            var LivroExistente = await _context.livro.FindAsync(livros);

            if (LivroExistente == null)
            {
                return NotFound("Livro Existente .");
            }

            LivroExistente.Id = livros.Id;
            LivroExistente.Titulo = livros.Titulo;
            LivroExistente.Autor = livros.Autor;
            LivroExistente.Ano = livros.Ano;



            await _context.SaveChangesAsync();

            return Ok(LivroExistente);
        }
        [HttpDelete("{i}")]
        public async Task<IActionResult> Deletelivro(int id)
        {
            var livro = await _context.livro.FindAsync(id);

            if (livro == null)
            {
                return NotFound("livro não encontrado.");
            }

            _context.livro.Remove(livro);
            await _context.SaveChangesAsync();

            return Ok("Livro excluído com sucesso.");
        }
    }
}