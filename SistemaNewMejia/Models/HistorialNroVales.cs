using Microsoft.EntityFrameworkCore;

namespace SistemaNewMejia.Models
{
    public class HistorialNroVales
    {
        public int Id { get; set; }
        public int IdVale { get; set; }
        public Vale Vale { get; set; }
        public string NroVale { get; set; }
        public string? NombreChofer { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? TipoVehiculo { get; set; }
        public DateTime? FechaRecojo { get; set; }
        public double? PrecioConsumido { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstado { get; set; }
        public EstadoVale EstadoVale { get; set; }
    }
}
