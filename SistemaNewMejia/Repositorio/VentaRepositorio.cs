using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.DB;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.Repositorio
{
    public interface IVentaRepositorio
    {
        void agregarVenta(Venta venta);
        List<Venta> listar();
        Venta ultimaVenta();
        void agregarDetalleVenta(DetalleVenta detalleVenta);
        List<DetalleVenta> listarDetallesVenta(int id);
    }
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly DbEntities _dbEntities;

        public VentaRepositorio(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public void agregarDetalleVenta(DetalleVenta detalleVenta)
        {
            _dbEntities.DetalleVentas.Add(detalleVenta);
            _dbEntities.SaveChanges();
        }

        public void agregarVenta(Venta venta)
        {
            _dbEntities.Ventas.Add(venta);
            _dbEntities.SaveChanges();
        }

        public List<Venta> listar()
        {
            return _dbEntities.Ventas.ToList();
        }

        public List<DetalleVenta> listarDetallesVenta(int id)
        {
            return _dbEntities.DetalleVentas
                .Include(o => o.Producto)
                .Include(o => o.Venta)
                .Where(o => o.Id == id)
                .ToList();
        }

        public Venta ultimaVenta()
        {
            return _dbEntities.Ventas.OrderBy(o => o.Id).Last();
        }
    }
}
