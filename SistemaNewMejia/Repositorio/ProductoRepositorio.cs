using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.DB;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.Repositorio
{
    public interface IProductoRepositorio
    {
        List<Producto> listar();
        Producto listarProducto(int id);
        void agregarProducto(Producto producto);
        void editarProducto(int id, Producto producto);
        List<Producto> filtrarProductos(int idTipo);
        List<Producto> buscarProductos(string nombre);
        void guardarCambios();
    }
    public class ProductoRepositorio: IProductoRepositorio
    {
        private readonly DbEntities _dbEntities;

        public ProductoRepositorio(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public void agregarProducto(Producto producto)
        {
            _dbEntities.Productos.Add(producto);
            _dbEntities.SaveChanges();
        }

        public List<Producto> buscarProductos(string nombre)
        {
            return _dbEntities.Productos.Where(o => o.NombreProducto.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void editarProducto(int id, Producto producto)
        {
            var product = _dbEntities.Productos.First(o => o.Id == id);
            product.NombreProducto = producto.NombreProducto;
            product.Precio = producto.Precio;
            product.Cantidad = producto.Cantidad;
            product.Contenido = producto.Contenido;
            product.IdPresentacionProducto = producto.IdPresentacionProducto;
            product.VenderMenudeo = producto.VenderMenudeo;
            product.IdTipo = producto.IdTipo;
            product.UnidadMedida = producto.UnidadMedida;
            _dbEntities.SaveChanges();
        }

        public List<Producto> filtrarProductos(int idTipo)
        {
            return _dbEntities.Productos.Where(o => o.IdTipo == idTipo).ToList();
        }

        public void guardarCambios()
        {
            _dbEntities.SaveChanges();
        }

        public List<Producto> listar()
        {
            return _dbEntities.Productos
                .Include(o => o.PresentacionProducto)
                .ToList();
        }

        public Producto listarProducto(int id)
        {
            return _dbEntities.Productos.Where(o => o.Id == id).Single();
        }
    }
}
