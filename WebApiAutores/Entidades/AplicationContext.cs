using Microsoft.EntityFrameworkCore;

namespace WebApiAutores.Entidades
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        public DbSet<ComentarioAutores> ComentarioAut { get; set; }

        public DbSet<Comentario> ComentarioLibros { get; set; }
    }
}
