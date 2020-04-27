using BlogDoXim.Data.Mappings;
using BlogDoXim.Domain;
using BlogDoXim.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace BlogDoXim.Data
{
    public class BlogDoXimContext : DbContext
    {
        public DbSet<AcessoArtigo> AcessosArtigo { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public BlogDoXimContext(DbContextOptions<BlogDoXimContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcessoArtigoMapping());
            modelBuilder.ApplyConfiguration(new ArtigoMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            modelBuilder.Ignore<Entity>();
        }
    }
}
