using Microsoft.AspNetCore.Mvc;
using SistemaNewMejia.DB;
using SistemaNewMejia.Models;
using SistemaNewMejia.Repositorio;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace SistemaNewMejia.Controllers
{
    public class VentaController : Controller
    {
        private readonly DbEntities _dbEntities;
        private readonly ITipoProductoRepositorio tipoProductoRepositorio;
        private readonly IProductoRepositorio productoRepositorio;
        private readonly IPresentacionProductoRepositorio presentacionProductoRepositorio;

        public static List<int> idsProductos = new List<int>();
        public static List<double> cantProductos = new List<double>();

        public static int numVenta = 0;
        public static int numDetalleVenta = 0;

        public static List<Venta> ventas = new List<Venta>();
        public static List<DetalleVenta> detalleVentas = new List<DetalleVenta>();

        public VentaController(DbEntities dbEntities, ITipoProductoRepositorio tipoProductoRepositorio, IProductoRepositorio productoRepositorio, IPresentacionProductoRepositorio presentacionProductoRepositorio)
        {
            _dbEntities = dbEntities;
            this.tipoProductoRepositorio = tipoProductoRepositorio;
            this.productoRepositorio = productoRepositorio;
            this.presentacionProductoRepositorio = presentacionProductoRepositorio;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productos = productoRepositorio.listar();
            ViewBag.alerta = "info";
            ViewBag.res = "Productos en venta";
            return View(productos);
        }

        [HttpPost]
        public IActionResult Index(int Id, double cantidad)
        {
            idsProductos.Add(Id);
            cantProductos.Add(cantidad);
            ViewBag.alerta = "info";
            ViewBag.res = "Producto agregado a la cesta";
            var productos = productoRepositorio.listar();
            return View(productos);
        }

        [HttpGet]
        public IActionResult VerCesta() 
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Productos en la cesta";
            List<Producto> productos = new List<Producto>();
            foreach(int i in idsProductos)
            {
                productos.Add(productoRepositorio.listarProducto(i));
            }
            int cont = 0;
            foreach (Producto producto in productos)
            {
                producto.Cantidad = cantProductos[cont];
            }
            return View(productos);
        }

        [HttpGet]
        public IActionResult Vender()
        {
            Venta venta = new Venta();
            venta.Id = numVenta;
            DateTime thisDay = DateTime.Now;
            venta.IdNombreTipoPago = 1;
            venta.Fecha = thisDay;
            ventas.Add(venta);
            Producto productoAux = new Producto();
            int cont = 0;
            foreach (int i in idsProductos)
            {
                productoAux = productoRepositorio.listarProducto(i);
                productoAux.Cantidad = (float)cantProductos[cont];
                DetalleVenta detalleVenta = new DetalleVenta();
                detalleVenta.Id = numDetalleVenta;
                detalleVenta.IdProducto = productoAux.Id;
                detalleVenta.IdVenta = numVenta;
                detalleVenta.Cantidad = (double)productoAux.Cantidad;
                detalleVenta.PrecioProducto = productoAux.Precio;
                detalleVenta.Descuento = 0;
                detalleVenta.IdTipoDescuento = 1;
                detalleVenta.PrecioFinal = productoAux.Precio * (decimal)productoAux.Cantidad;
                detalleVentas.Add(detalleVenta);
                numDetalleVenta++;
            }
            numVenta++;
            idsProductos.Clear();
            cantProductos.Clear();
            return RedirectToAction("verVentas", "Venta");
        }

        public IActionResult verVentas()
        {
            return View(ventas);
        }

        [HttpGet]
        public IActionResult VentaNormal()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Venta Normal";
            return View();
        }

        [HttpGet]
        public IActionResult VentaVale()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReporteVentas()
        {
            return View();
        }
    }
}
