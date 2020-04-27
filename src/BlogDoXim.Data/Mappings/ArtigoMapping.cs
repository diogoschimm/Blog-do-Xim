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
        }
    }
}
