using BlogDoXim.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDoXim.Data.Mappings
{
    public class ArtigoMapping : IEntityTypeConfiguration<Artigo>
    {
        public void Configure(EntityTypeBuilder<Artigo> builder)
        {
            builder.ToTable("Artigo");
            builder.HasKey(a => a.ArtigoId).HasName("pk_artigo");
            builder.Property(a => a.ArtigoId).ValueGeneratedOnAdd();

            builder.Property(a => a.ArtigoId)
                .HasColumnName("ArtigoId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(a => a.SubTitulo)
                .HasColumnName("SubTitulo")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(a => a.Resumo)
                .HasColumnName("Resumo")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(a => a.Conteudo)
                .HasColumnName("Conteudo")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(a => a.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(a => a.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(a => a.DataPublicacao)
                .HasColumnName("DataPublicacao")
                .HasColumnType("DateTime");

            builder.Property(a => a.Imagem)
                .HasColumnName("Imagem")
                .HasColumnType("varbinary(max)");

            builder.Property(a => a.GithubUrl)
                .HasColumnName("GithubUrl")
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(a => a.CategoriaId)
                .HasColumnName("CategoriaId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.UsuarioId)
                .HasColumnName("UsuarioId")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(a => a.Categoria)
                .WithMany(c => c.Artigos)
                .HasForeignKey(a => a.CategoriaId)
                .HasConstraintName("fk_artigo_categoria")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Usuario )
                .WithMany(u => u.Artigos)
                .HasForeignKey(a => a.UsuarioId )
                .HasConstraintName("fk_artigo_usuario")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
