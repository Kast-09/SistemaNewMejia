using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class VentaMapping : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Venta", "dbo");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.TipoPago)
                .WithMany()
                .HasForeignKey(o => o.IdNombreTipoPago);

            builder.HasOne(o => o.TipoComprobante)
                .WithMany()
                .HasForeignKey(o => o.IdNombreTipoComprobante);

            builder.HasOne(o => o.Usuario)
                .WithMany()
                .HasForeignKey(o => o.IdUsuario);
        }
    }
}
