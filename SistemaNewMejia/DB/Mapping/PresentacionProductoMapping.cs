using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class PresentacionProductoMapping : IEntityTypeConfiguration<PresentacionProducto>
    {
        public void Configure(EntityTypeBuilder<PresentacionProducto> builder)
        {
            builder.ToTable("PresentacionProducto", "dbo");
            builder.HasKey(o => o.Id);
        }
    }
}
