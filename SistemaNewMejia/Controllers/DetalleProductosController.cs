using Microsoft.AspNetCore.Mvc;
using SistemaNewMejia.DB;
using SistemaNewMejia.Models;
using SistemaNewMejia.Repositorio;

namespace SistemaNewMejia.Controllers
{
    public class DetalleProductosController : Controller
    {
        private readonly DbEntities _dbEntities;
        private readonly ITipoProductoRepositorio tipoProductoRepositorio;
        private readonly IProductoRepositorio productoRepositorio;
        private readonly IPresentacionProductoRepositorio presentacionProductoRepositorio;
        private readonly IUnidadesMedidaRepositorio unidadesMedidaRepositorio;

        public DetalleProductosController(DbEntities dbEntities, ITipoProductoRepositorio tipoProductoRepositorio, IProductoRepositorio productoRepositorio, IPresentacionProductoRepositorio presentacionProductoRepositorio, IUnidadesMedidaRepositorio unidadesMedidaRepositorio)
        {
            _dbEntities = dbEntities;
            this.tipoProductoRepositorio = tipoProductoRepositorio;
            this.productoRepositorio = productoRepositorio;
            this.presentacionProductoRepositorio = presentacionProductoRepositorio;
            this.unidadesMedidaRepositorio = unidadesMedidaRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Presentaciones()
        {
            ViewBag.alerta = "info";
            ViewBag.respuesta = "Presentaciones";
            var presentacionProductos = presentacionProductoRepositorio.listarPresentaciones();
            return View(presentacionProductos);
        }

        [HttpPost]
        public IActionResult Presentaciones(string presentacionNueva)
        {
            PresentacionProducto presentacionProducto = new PresentacionProducto();
            presentacionProducto.NombrePresentacion = presentacionNueva;
            presentacionProductoRepositorio.agregarPresentacion(presentacionProducto);
            ViewBag.alerta = "success";
            ViewBag.respuesta = "Se agrego nueva presentación";
            var presentacionProductos = presentacionProductoRepositorio.listarPresentaciones();
            return View(presentacionProductos);
        }

        [HttpGet]
        public IActionResult TiposProducto()
        {
            ViewBag.alerta = "info";
            ViewBag.respuesta = "Tipos";
            var tiposProductos = tipoProductoRepositorio.listar();
            return View(tiposProductos);
        }

        [HttpPost]
        public IActionResult TiposProducto(string tipoNuevo)
        {
            TipoProducto tipoProducto = new TipoProducto();
            tipoProducto.NombreTipo = tipoNuevo;
            tipoProductoRepositorio.agregarTipo(tipoProducto);
            ViewBag.alerta = "success";
            ViewBag.respuesta = "Se agrego nuevo tipo";
            var tiposProductos = tipoProductoRepositorio.listar();
            return View(tiposProductos);
        }

        [HttpGet]
        public IActionResult UnidadesMedida()
        {
            ViewBag.alerta = "info";
            ViewBag.respuesta = "Unidades de medida";
            var unidadesMedida = unidadesMedidaRepositorio.listar();
            return View(unidadesMedida);
        }

        [HttpPost]
        public IActionResult UnidadesMedida(string unidadNueva)
        {
            UnidadesMedida unidadesMedida = new UnidadesMedida();
            unidadesMedida.NombreUnidad = unidadNueva;
            unidadesMedidaRepositorio.agregarUnidadMedida(unidadesMedida);
            ViewBag.alerta = "success";
            ViewBag.respuesta = "Unidad de medida agregada";
            var listaUnidadesMedidas = unidadesMedidaRepositorio.listar();
            return View(listaUnidadesMedidas);
        }
    }
}
