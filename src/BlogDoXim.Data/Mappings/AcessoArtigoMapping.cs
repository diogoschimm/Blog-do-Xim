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
        }
    }
}
