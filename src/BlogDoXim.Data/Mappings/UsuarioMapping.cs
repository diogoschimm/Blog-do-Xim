using BlogDoXim.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDoXim.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.UsuarioId).HasName("pk_usuario");
            builder.Property(u => u.UsuarioId).ValueGeneratedOnAdd();
        }
    }
}
