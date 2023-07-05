namespace SistemaNewMejia.Models
{
    public class DetalleVale
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public Venta Venta { get; set; }
        public int IdHistorialNroVales { get; set; }
        public HistorialNroVales HistorialNroVales { get; set; }
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        public double Cantidad { get; set; }
        public double CantidadDisponible { get; set; }
        public double CantidadRecogida { get; set; }
        public decimal PrecioProducto { get; set; }
        public decimal? Descuento { get; set; }
        public int? IdTipoDescuento { get; set; }
        public TipoDescuento? TipoDescuento { get; set; }
        public decimal PrecioFinal { get; set; }
    }
}
