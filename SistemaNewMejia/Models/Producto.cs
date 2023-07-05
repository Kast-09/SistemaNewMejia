namespace SistemaNewMejia.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Contenido { get; set; }
        public int IdPresentacionProducto { get; set; }
        public PresentacionProducto PresentacionProducto { get; set; }
        public bool VenderMenudeo { get; set; }
        public int IdTipo { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public string UnidadMedida { get; set; }
    }
}
