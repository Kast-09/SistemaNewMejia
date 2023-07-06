using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.DB.Mapping;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.DB
{
    public class DbEntities: DbContext
    {
        public DbSet<DetalleVale> DetalleVales { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<EstadoVale> EstadoVales { get; set; }
        public DbSet<HistorialNroVales> HistorialNroVales { get; set; }
        public DbSet<PresentacionProducto> PresentacionProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoComprobante> TipoComprobantes { get; set; }
        public DbSet<TipoDescuento> TipoDescuentos { get; set; }
        public DbSet<TipoPago> TipoPagos { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<UnidadesMedida> UnidadesMedidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vale> Vales { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbEntities () { }
        public DbEntities (DbContextOptions<DbEntities> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DetalleValeMapping());
            modelBuilder.ApplyConfiguration(new DetalleVentaMapping());
            modelBuilder.ApplyConfiguration(new EstadoValeMapping());
            modelBuilder.ApplyConfiguration(new HistorialNroValesMapping());
            modelBuilder.ApplyConfiguration(new PresentacionProductoMapping());
            modelBuilder.ApplyConfiguration(new ProductoMapping());
            modelBuilder.ApplyConfiguration(new TipoComprobanteMapping());
            modelBuilder.ApplyConfiguration(new TipoDescuentoMapping());
            modelBuilder.ApplyConfiguration(new TipoPagoMapping());
            modelBuilder.ApplyConfiguration(new TipoProductoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new UnidadesMedidaMapping());
            modelBuilder.ApplyConfiguration(new ValeMapping());
            modelBuilder.ApplyConfiguration(new VentaMapping());
        }
    }
}
