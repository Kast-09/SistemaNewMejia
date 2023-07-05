namespace SistemaNewMejia.Models
{
    public class Vale
    {
        public int Id { get; set; }
        public string NombreEmpresaCliente { get; set; }
        public string? Placa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaPago { get; set; }
        public int IdEstadoVale { get; set; }
        public EstadoVale EstadoVale { get; set; }
        public decimal TotalVale { get; set; }
        public string DNI_RUC { get; set; }
        public string? NroValeOficial { get; set; }
    }
}
