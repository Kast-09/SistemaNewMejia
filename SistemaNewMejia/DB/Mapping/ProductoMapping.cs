using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class ProductoMapping : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto", "dbo");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.PresentacionProducto)
                .WithMany()
                .HasForeignKey(o => o.IdPresentacionProducto);

            builder.HasOne(o => o.TipoProducto)
                .WithMany()
                .HasForeignKey(o => o.IdTipo);
        }
    }
}
