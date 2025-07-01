using CatalogoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Rota base: /api/livros
    public class LivrosController : ControllerBase
    {
        // Banco de dados em memória (static para persistir entre requisições)
        private static List<Livro> _livros = new List<Livro>
        {
          new Livro { Id = 1, Titulo = "A arte da guerra", Autor = "Sun Tzu", AnoDePublicacao = -500 },
          new Livro { Id = 2, Titulo = "O senhor dos Anéis", Autor = "Sun Tzu", AnoDePublicacao = -500 },
          new Livro { Id = 3, Titulo = "A arte da guerra", Autor = "Sun Tzu", AnoDePublicacao = -500 },
        };


        // --- Inícios das operações do CRUD ---

        // 1. READ: Buscar todos Livros 
        // GET /api/livros 

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(_livros);
        }

        // 2. READ: Buscar apenas um livro por ID 
        // GET /api/livros/{id}
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var livro = _livros.FirstOrDefault(l => l.Id == id);
            if (livro == null)
            {
                return NotFound(); // Retorna HTTP 404 Se não encontrar.
            }
            return Ok(livro);
        }
        // 3. CREATE: Adicionar um novo livro 
        // POST /api/livros
        [HttpPost]
        public IActionResult CriarLivro([FromBody] Livro novoLivro)
        {
            if (novoLivro == null)
            {
                return BadRequest(); // Retorna HTTP 400 Se o corpo da requisão for inválido
            }

            // Simula a geração de um novo ID pelo banco de dados 
            novoLivro.Id = _livros.Any() ? _livros.Max(l => l.Id) + 1 : 1;

            _livros.Add(novoLivro);

            // Retorna HTTP 201, a URL para o novo recurso 
            return CreatedAtAction(nameof(GetPorId), new { id = novoLivro.Id }, novoLivro);
        }
         





    }






















































}