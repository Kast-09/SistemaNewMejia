using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class ValeMapping : IEntityTypeConfiguration<Vale>
    {
        public void Configure(EntityTypeBuilder<Vale> builder)
        {
            builder.ToTable("Vale", "dbo");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.EstadoVale)
                .WithMany()
                .HasForeignKey(o => o.IdEstadoVale);
        }
    }
}
