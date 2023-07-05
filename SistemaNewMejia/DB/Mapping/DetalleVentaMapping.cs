using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class DetalleVentaMapping : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta", "dbo");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Producto)
                .WithMany()
                .HasForeignKey(o => o.IdProducto);

            builder.HasOne(o => o.Venta)
                .WithMany()
                .HasForeignKey(o => o.IdVenta);

            builder.HasOne(o => o.TipoDescuento)
                .WithMany()
                .HasForeignKey(o => o.IdTipoDescuento);
        }
    }
}
