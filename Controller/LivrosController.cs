using CatalogoApi.Data;
using CatalogoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Rota base: /api/livros
    public class LivrosController : ControllerBase
    {
        // 1. DataContext Injetado
        private readonly DataContext _context;

        public LivrosController(DataContext context)
        {
            _context = context;
        }
        // --- Inícios das operações do CRUD ---

        // 1. READ: Buscar todos Livros 
        // GET /api/livros 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetTodos()
        {
            // Usa o contexto do banco para buscar todos os livros de forma assíncrona
            var livros = await _context.Livros.ToListAsync(); 
            return Ok(livros);
        }

        // 2. READ: Buscar apenas um livro por ID 
        // GET /api/livros/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetPorId(int id)
        {   
            //FindAsync otimizado para buscar pela chave primaria 
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound(); // Retorna HTTP 404 Se não encontrar.
            }
            return Ok(livro);
        }
        // 3. CREATE: Adicionar um novo livro 
        // POST /api/livros
        [HttpPost]
        public async Task<ActionResult<Livro>> CriarLivro([FromBody] Livro novoLivro)
        {
            if (novoLivro == null)
            {
                return BadRequest(); // Retorna HTTP 400 Se o corpo da requisão for inválido
            }

             _context.Livros.Add(novoLivro);
             await _context.SaveChangesAsync(); 

            // Retorna HTTP 201, a URL para o novo recurso 
            return CreatedAtAction(nameof(GetPorId), new { id = novoLivro.Id }, novoLivro);
        }


        // 4. UPDATE: Atualizar um livro existente
        // PUT /api/livros/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivro(int id, [FromBody] Livro livroAtualizado)
        {
            if (id != livroAtualizado.Id)
            {
                return BadRequest();
            }

            _context.Entry(livroAtualizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //  Verifica se o livro que tentamos atualizar realmente existe
                if (!_context.Livros.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                { 
                    throw;
                }

            }
            return NoContent(); // Retorna HTTP 204 indicando sucesso sem conteúdo
        }

        // 5. DELETE: Remover um livro 
        // DELETE /api/livros/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLivro(int id)
        {
            var livroParaDeletar = await _context.Livros.FindAsync(id);
            if (livroParaDeletar == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livroParaDeletar);
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna HTTP 204 indicando sucesso sem conteúdo
        }
    }
}