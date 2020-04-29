using BlogDoXim.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDoXim.Data.Mappings
{
    public class AcessoArtigoMapping : IEntityTypeConfiguration<AcessoArtigo>
    {
        public void Configure(EntityTypeBuilder<AcessoArtigo> builder)
        {
            builder.ToTable("AcessoArtigo");
            builder.HasKey(a => a.AcessoArtigoId).HasName("pk_acessoArtigo");
            builder.Property(a => a.AcessoArtigoId).ValueGeneratedOnAdd();

            builder.Property(a => a.AcessoArtigoId)
                .HasColumnName("AcessoArtigoId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.IP)
                .HasColumnName("IP")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(a => a.DataAcesso)
                .HasColumnName("DataAcesso")
                .HasColumnType("DateTime")
                .HasDefaultValue("GETDATE()")
                .IsRequired();

            builder.HasOne(a => a.Artigo)
                .WithMany(a => a.AcessosArtigo)
                .HasForeignKey(a => a.ArtigoId)
                .HasConstraintName("fk_acessoArtigo_artigo")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
