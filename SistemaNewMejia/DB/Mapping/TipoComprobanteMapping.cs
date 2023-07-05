using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class TipoComprobanteMapping : IEntityTypeConfiguration<TipoComprobante>
    {
        public void Configure(EntityTypeBuilder<TipoComprobante> builder)
        {
            builder.ToTable("TipoComprobante", "dbo");
            builder.HasKey(o => o.Id);
        }
    }
}
