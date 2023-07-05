using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class TipoDescuentoMapping : IEntityTypeConfiguration<TipoDescuento>
    {
        public void Configure(EntityTypeBuilder<TipoDescuento> builder)
        {
            builder.ToTable("TipoDescuento", "dbo");
            builder.HasKey(o => o.Id);
        }
    }
}
