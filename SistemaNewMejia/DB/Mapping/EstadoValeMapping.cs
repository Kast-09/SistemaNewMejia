using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class EstadoValeMapping : IEntityTypeConfiguration<EstadoVale>
    {
        public void Configure(EntityTypeBuilder<EstadoVale> builder)
        {
            builder.ToTable("EstadoVale", "dbo");
            builder.HasKey(o => o.Id);
        }
    }
}
