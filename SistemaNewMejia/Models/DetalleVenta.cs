namespace SistemaNewMejia.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        public int IdVenta { get; set; }
        public Venta Venta { get; set; }
        public double Cantidad { get; set; }
        public decimal PrecioProducto { get; set; }
        public decimal Descuento { get; set; }
        public int IdTipoDescuento { get; set; }
        public TipoDescuento TipoDescuento { get; set; }
        public decimal PrecioFinal { get; set; }

    }
}
