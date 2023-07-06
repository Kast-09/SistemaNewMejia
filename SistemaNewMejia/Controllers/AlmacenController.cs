using Microsoft.AspNetCore.Mvc;
using SistemaNewMejia.DB;
using SistemaNewMejia.Models;
using SistemaNewMejia.Repositorio;

namespace SistemaNewMejia.Controllers
{
    public class AlmacenController : Controller
    {
        private readonly DbEntities _dbEntities;
        private readonly ITipoProductoRepositorio tipoProductoRepositorio;
        private readonly IProductoRepositorio productoRepositorio;
        private readonly IPresentacionProductoRepositorio presentacionProductoRepositorio;
        private readonly IUnidadesMedidaRepositorio unidadesMedidaRepositorio;

        public AlmacenController(DbEntities dbEntities, ITipoProductoRepositorio tipoProductoRepositorio, IProductoRepositorio productoRepositorio, IPresentacionProductoRepositorio presentacionProductoRepositorio, IUnidadesMedidaRepositorio unidadesMedidaRepositorio)
        {
            _dbEntities = dbEntities;
            this.tipoProductoRepositorio = tipoProductoRepositorio;
            this.productoRepositorio = productoRepositorio;
            this.presentacionProductoRepositorio = presentacionProductoRepositorio;
            this.unidadesMedidaRepositorio = unidadesMedidaRepositorio;
        }

        public IActionResult Index()
        {
            ViewBag.alerta = "info";
            ViewBag.respuesta = "Productos Almacén";
            return View(productoRepositorio.listar());
        }

        [HttpPost]
        public IActionResult Index(string nombreProducto, decimal precioProducto, float cantidadProducto, float contenidoNeto,
            int presentacionesProducto, bool venderMenudeo, int clasificacionProducto, int unidadMedida)
        {
            Producto producto = new Producto();
            producto.NombreProducto = nombreProducto;
            producto.Precio = precioProducto;
            producto.Cantidad = cantidadProducto;
            producto.Contenido = contenidoNeto;
            producto.IdPresentacionProducto = presentacionesProducto;
            producto.VenderMenudeo = venderMenudeo;
            producto.IdTipo = clasificacionProducto;
            producto.idUnidadMedida = unidadMedida;
            productoRepositorio.agregarProducto(producto);
            ViewBag.alerta = "success";
            ViewBag.respuesta = "Producto Registrado";
            return View(productoRepositorio.listar());
        }

        [HttpPost]
        public String listarTiposProducto()
        {
            string respuesta = "<option value=\"\">Seleccione</option>";
            var tipoProducto1 = new List<TipoProducto>();
            tipoProducto1 = tipoProductoRepositorio.listar();
            foreach (var i in tipoProducto1)
            {
                respuesta += "<option value=\"" + i.Id + "\">" + i.NombreTipo + "</option>";
            }
            return respuesta;
        }

        [HttpPost]
        public String listarPresentacionesProductos()
        {
            string respuesta = "<option value=\"\">Seleccione</option>";
            var tipoProducto1 = new List<PresentacionProducto>();
            tipoProducto1 = presentacionProductoRepositorio.listarPresentaciones();
            foreach (var i in tipoProducto1)
            {
                respuesta += "<option value=\"" + i.Id + "\">" + i.NombrePresentacion + "</option>";
            }
            return respuesta;
        }

        [HttpPost]
        public String listarUnidadeMediadaProductos()
        {
            string respuesta = "<option value=\"\">Seleccione</option>";
            var tipoProducto1 = unidadesMedidaRepositorio.listar();
            foreach (var i in tipoProducto1)
            {
                respuesta += "<option value=\"" + i.Id + "\">" + i.NombreUnidad + "</option>";
            }
            return respuesta;
        }

        [HttpPost]
        public string AgregarTipoProducto(string tipoNuevo)
        {
            string respuesta = "";
            TipoProducto tipoProducto = new TipoProducto();
            tipoProducto.NombreTipo = tipoNuevo;
            tipoProductoRepositorio.agregarTipo(tipoProducto);
            respuesta = "Tipo Registrado";
            return respuesta;
        }

        [HttpPost]
        public string AgregarNuevaPresentacion(string presentacionNueva)
        {
            string respuesta = "";
            PresentacionProducto presentacionProducto = new PresentacionProducto();
            presentacionProducto.NombrePresentacion = presentacionNueva;
            presentacionProductoRepositorio.agregarPresentacion(presentacionProducto);
            respuesta = "Presentación Registrada";
            return respuesta;
        }

        [HttpGet]
        public IActionResult VerProductosClase(int id, string nombreProducto)
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Presentaciones - " + nombreProducto;
            return View();
        }

        [HttpPost]
        public string busquedaProducto(string nombreProducto)
        {
            string res = "";
            var productos = productoRepositorio.buscarProductos(nombreProducto);
            int cont = 1;
            foreach (var a in productos)
            {
                int id = cont;
                string nombreP = a.NombreProducto;
                decimal precio = a.Precio;
                double cantidad = a.Cantidad;
                double contenido = a.Contenido;
                int idPresentacion = a.IdPresentacionProducto;
                string unidadMedida = a.UnidadesMedida.NombreUnidad;
                string botonSeleccionado = "<a class=\"btn btn-outline-dark\" id=\"btnVerDetalle\" name=\"btnVerDetalle\" " +
                    "href=\"/Almacen/EditarProducto?idProducto=@i.Id\">" +
                    "<i class=\"bi bi-pencil-square\"> Editar Producto</i></a>";
                res = res +
                    "<tr><td>" + id + "</td>"
                    + "<td>" + nombreP + "</td>"
                    + "<td>" + idPresentacion + "</td>"
                    + "<td>" + contenido + " " + unidadMedida + "</td>"
                    + "<td>" + cantidad + "</td>"
                    + "<td>" + precio + "</td>"
                    + "<td style=\"text-align:center\">" + botonSeleccionado + "</td></tr>";

                cont++;
            }
            return res;
        }

        [HttpPost]
        public string filtrarProducto(int idTipo)
        {
            string res = "";
            var productos = productoRepositorio.filtrarProductos(idTipo);
            int cont = 1;
            foreach (var a in productos)
            {
                int id = a.Id;
                string nombreP = a.NombreProducto;
                decimal precio = a.Precio;
                double cantidad = a.Cantidad;
                double contenido = a.Contenido;
                int idPresentacion = a.IdPresentacionProducto;
                string unidadMedida = a.UnidadesMedida.NombreUnidad;
                string botonSeleccionado = "<a class=\"btn btn-outline-dark\" id=\"btnVerDetalle\" name=\"btnVerDetalle\" " +
                    "href=\"/Almacen/EditarProducto?idProducto="+a.Id+"\">" +
                    "<i class=\"bi bi-pencil-square\"> Editar Producto</i></a>";
                res = res +
                    "<tr><td>" + cont + "</td>"
                    + "<td>" + nombreP + "</td>"
                    + "<td>" + idPresentacion + "</td>"
                    + "<td>" + contenido + " " + unidadMedida + "</td>"
                    + "<td>" + cantidad + "</td>"
                    + "<td>" + precio + "</td>"
                    + "<td style=\"text-align:center\">" + botonSeleccionado + "</td></tr>";
                cont++;
            }
            return res;
        }

        [HttpPost]
        public string filtrarProductoVenta(int idTipo)
        {
            string res = "";
            var productos = productoRepositorio.filtrarProductos(idTipo);
            int cont = 1;
            foreach (var a in productos)
            {
                res = res +
                    "<tr>" +
                    "<form action=\"/Venta/Index?Id=" + a.Id + "\" method=\"post\">" +
                    "<td>" + cont + "</td>" +
                    "<td>" + a.NombreProducto + "</td>" +
                    "<td>" + a.PresentacionProducto.NombrePresentacion + "</td>" +
                    "<td>" + a.Contenido + " " + a.UnidadesMedida.NombreUnidad + "</td>" +
                    "<td>"+a.Cantidad+"</td>" +
                    "<td>"+a.Precio+"</td>" +
                    "<td>" +
                    "<input type=\"number\" id=\"cantidad\" name=\"cantidad\" min=\"1.00\" max=\"100.00\" required>" +
                    "</td>" +
                    "<td style=\"text-align:center\">" +
                    "<button class=\"btn btn-success\" type=\"submit\">Agregar a la cesta</button>" +
                    "</td>" +
                    "</form>" +
                    "</tr>";
                cont++;
            }
            return res;
        }

        [HttpGet]
        public IActionResult EditarProducto(int idProducto)
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Editar Producto";
            return View(productoRepositorio.listarProducto(idProducto));
        }

        [HttpPost]
        public IActionResult EditarProducto(int id, string nombreProducto, decimal precioProducto, double cantidadNueva, double contenidoNeto,
            int presentacionesProducto, bool venderMenudeo, int clasificacionProducto, int unidadMedida)
        {
            Producto productoTemp = productoRepositorio.listarProducto(id);
            double cantidadTemp = productoTemp.Cantidad + cantidadNueva;
            Producto producto = new Producto();
            producto.NombreProducto = nombreProducto;
            producto.Precio = precioProducto;
            producto.Cantidad = cantidadTemp;
            producto.Contenido = contenidoNeto;
            producto.IdPresentacionProducto = presentacionesProducto;
            producto.VenderMenudeo = venderMenudeo;
            producto.IdTipo = clasificacionProducto;
            producto.idUnidadMedida = unidadMedida;
            productoRepositorio.editarProducto(id, producto);
            ViewBag.alerta = "success";
            ViewBag.res = "Producto Editado";
            productoRepositorio.editarProducto(id, productoTemp);
            return View(productoRepositorio.listarProducto(id));
        }
    }
}
