using SistemaNewMejia.DB;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.Repositorio
{
    public interface ITipoProductoRepositorio
    {
        List<TipoProducto> listar();
        void agregarTipo(TipoProducto tipoProducto);
    }
    public class TipoProductoRepositorio : ITipoProductoRepositorio
    {
        private readonly DbEntities _dbEntities;

        public TipoProductoRepositorio(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public void agregarTipo(TipoProducto tipoProducto)
        {
            _dbEntities.TipoProductos.Add(tipoProducto);
            _dbEntities.SaveChanges();
        }

        public List<TipoProducto> listar()
        {
            return _dbEntities.TipoProductos.ToList();
        }
    }
}
