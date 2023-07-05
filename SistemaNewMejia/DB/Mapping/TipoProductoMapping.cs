using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class TipoProductoMapping : IEntityTypeConfiguration<TipoProducto>
    {
        public void Configure(EntityTypeBuilder<TipoProducto> builder)
        {
            builder.ToTable("TipoProducto", "dbo");
            builder.HasKey(o => o.Id);
        }
    }
}
