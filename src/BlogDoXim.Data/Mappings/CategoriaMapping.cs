using BlogDoXim.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDoXim.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(c => c.CategoriaId).HasName("pk_categoria");
            builder.Property(c => c.CategoriaId).ValueGeneratedOnAdd();
        }
    }
}
