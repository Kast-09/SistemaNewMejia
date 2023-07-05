using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class DetalleValeMapping : IEntityTypeConfiguration<DetalleVale>
    {
        public void Configure(EntityTypeBuilder<DetalleVale> builder)
        {
            builder.ToTable("DetalleVale", "dbo");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Venta)
                .WithMany()
                .HasForeignKey(o => o.IdVenta);

            builder.HasOne(o => o.HistorialNroVales)
                .WithMany()
                .HasForeignKey(o => o.IdHistorialNroVales);

            builder.HasOne(o => o.Producto)
                .WithMany()
                .HasForeignKey(o => o.IdProducto);

            builder.HasOne(o => o.TipoDescuento)
                .WithMany()
                .HasForeignKey(o => o.IdTipoDescuento);
        }
    }
}
