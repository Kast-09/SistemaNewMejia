using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB.Mapping
{
    public class HistorialNroValesMapping : IEntityTypeConfiguration<HistorialNroVales>
    {
        public void Configure(EntityTypeBuilder<HistorialNroVales> builder)
        {
            builder.ToTable("HistorialNroVales", "dbo");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Vale)
                .WithMany()
                .HasForeignKey(o => o.IdVale);

            builder.HasOne(o => o.EstadoVale)
                .WithMany()
                .HasForeignKey(o => o.IdEstado);
        }
    }
}
