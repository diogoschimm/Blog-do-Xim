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

            builder.Property(c => c.CategoriaId)
                .HasColumnName("CategoriaId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(c => c.Imagem)
                .HasColumnName("Imagem")
                .HasColumnType("varbinary(max)");

            builder.Property(c => c.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("DateTime")
                .IsRequired();
        }
    }
}
