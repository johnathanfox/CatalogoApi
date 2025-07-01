using CatalogoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Esta linha faz a solicitação para criar uma tabela chamada: 'Livros'
        // que irá armazenar objetos do tipo 'Livro'.
        public DbSet<Livro> Livros { get; set; }


    }
}
