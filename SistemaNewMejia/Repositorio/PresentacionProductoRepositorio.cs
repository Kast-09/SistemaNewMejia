using SistemaNewMejia.DB;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.Repositorio
{
    public interface IPresentacionProductoRepositorio
    {
        List<PresentacionProducto> listarPresentaciones();
        void agregarPresentacion(PresentacionProducto presentacion);
    }
    public class PresentacionProductoRepositorio: IPresentacionProductoRepositorio
    {
        private readonly DbEntities _dbEntities;

        public PresentacionProductoRepositorio(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public List<PresentacionProducto> listarPresentaciones()
        {
            return _dbEntities.PresentacionProductos.ToList();
        }

        public void agregarPresentacion(PresentacionProducto presentacion)
        {
            _dbEntities.PresentacionProductos.Add(presentacion);
            _dbEntities.SaveChanges();
        }
    }
}
