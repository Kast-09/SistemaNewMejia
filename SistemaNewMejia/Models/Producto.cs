namespace SistemaNewMejia.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public double Cantidad { get; set; }
        public double Contenido { get; set; }
        public int IdPresentacionProducto { get; set; }
        public PresentacionProducto PresentacionProducto { get; set; }
        public bool VenderMenudeo { get; set; }
        public int IdTipo { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public int idUnidadMedida { get; set; }
        public UnidadesMedida UnidadesMedida { get; set; }
    }
}
