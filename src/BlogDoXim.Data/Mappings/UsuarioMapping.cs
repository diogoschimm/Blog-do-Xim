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

            builder.Property(c => c.UsuarioId)
                .HasColumnName("UsuarioId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Login)
                .HasColumnName("Login")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("DateTime")
                .HasDefaultValue("GETDATE()")
                .IsRequired();

            builder.Property(c => c.Foto)
                .HasColumnName("Imagem")
                .HasColumnType("varbinary(max)");

            builder.Property(c => c.Github)
                .HasColumnName("Github")
                .HasColumnType("varchar(1000)")
                .IsRequired();
        }
    }
}
