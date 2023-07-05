namespace SistemaNewMejia.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdNombreTipoPago { get; set; }
        public TipoPago TipoPago { get; set; }
        public DateTime Fecha { get; set; }
        public int? IdNombreTipoComprobante { get; set; }
        public TipoComprobante? TipoComprobante { get; set; }
        public string? NroComprobante { get; set; }
        public int? IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public string? NombreCliente { get; set; }
    }
}
