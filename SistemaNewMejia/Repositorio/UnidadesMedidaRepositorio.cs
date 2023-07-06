using SistemaNewMejia.DB;
using SistemaNewMejia.Models;

namespace SistemaNewMejia.Repositorio
{
    public interface IUnidadesMedidaRepositorio
    {
        List<UnidadesMedida> listar();
        void agregarUnidadMedida(UnidadesMedida medida);
    }

    public class UnidadesMedidaRepositorio : IUnidadesMedidaRepositorio
    {
        private readonly DbEntities _dbEntities;
        public UnidadesMedidaRepositorio(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public void agregarUnidadMedida(UnidadesMedida medida)
        {
            _dbEntities.UnidadesMedidas.Add(medida);
            _dbEntities.SaveChanges();
        }

        public List<UnidadesMedida> listar()
        {
            return _dbEntities.UnidadesMedidas.ToList();
        }
    }
}
