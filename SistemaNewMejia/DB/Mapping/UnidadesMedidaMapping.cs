using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class UnidadesMedidaMapping : IEntityTypeConfiguration<UnidadesMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadesMedida> builder)
        {
            builder.ToTable("UnidadesMedida", "dbo");
            builder.HasKey(o => o.Id);
        }
    }
}
