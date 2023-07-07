using Moq;
using SistemaNewMejia.Controllers;
using SistemaNewMejia.Models;
using SistemaNewMejia.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMejiaTest.Controllers
{
    public class AlmacenControllerTest
    {
        [Test]
        public void IndexGetViewCase01()
        {
            var mockProducto = new Mock<IProductoRepositorio>();
            mockProducto.Setup(o => o.listar()).Returns(new List<Producto>());

            var indexT = new AlmacenController(null, null, mockProducto.Object, null, null);
            var view = indexT.Index();

            Assert.IsNotNull(view);
        }

        [Test]
        public void listarTiposGetViewCase01()
        {
            var mockTipoProducto = new Mock<ITipoProductoRepositorio>();
            mockTipoProducto.Setup(o => o.listar()).Returns(new List<TipoProducto>());

            var indexT = new AlmacenController(null, mockTipoProducto.Object, null, null, null);
            var view = indexT.listarTiposProducto();

            Assert.IsNotNull(view);
        }

        [Test]
        public void listarPresentacionesGetViewCase01()
        {
            var mockPresentacionProducto = new Mock<IPresentacionProductoRepositorio>();
            mockPresentacionProducto.Setup(o => o.listarPresentaciones()).Returns(new List<PresentacionProducto>());

            var indexT = new AlmacenController(null, null, null, mockPresentacionProducto.Object, null);
            var view = indexT.listarPresentacionesProductos();

            Assert.IsNotNull(view);
        }

        [Test]
        public void listarUnidadesGetViewCase01()
        {
            var mockUnidadesProducto = new Mock<IUnidadesMedidaRepositorio>();
            mockUnidadesProducto.Setup(o => o.listar()).Returns(new List<UnidadesMedida>());

            var indexT = new AlmacenController(null, null, null, null, mockUnidadesProducto.Object);
            var view = indexT.listarUnidadeMediadaProductos();

            Assert.IsNotNull(view);
        }

        [Test]
        public void agregarTipoGetViewCase01()
        {
            var mockagregar = new Mock<ITipoProductoRepositorio>();
            mockagregar.Setup(o => o.agregarTipo(new TipoProducto()));

            var indexT = new AlmacenController(null, mockagregar.Object, null, null, null);
            var view = indexT.AgregarTipoProducto("");

            Assert.IsNotNull(view);
        }

        [Test]
        public void agregarPresentacionGetViewCase01()
        {
            var mockagregar = new Mock<IPresentacionProductoRepositorio>();
            mockagregar.Setup(o => o.agregarPresentacion(new PresentacionProducto()));

            var indexT = new AlmacenController(null, null, null, mockagregar.Object, null);
            var view = indexT.AgregarNuevaPresentacion("");

            Assert.IsNotNull(view);
        }

        [Test]
        public void busquedaProductoGetViewCase01()
        {
            var mockBusqueda = new Mock<IProductoRepositorio>();
            mockBusqueda.Setup(o => o.buscarProductos("aceite")).Returns(new List<Producto>());

            var indexT = new AlmacenController(null, null, mockBusqueda.Object, null, null);
            var view = indexT.busquedaProducto("aceite");

            Assert.IsNotNull(view);
        }

        [Test]
        public void filtroProductoGetViewCase01()
        {
            var mockFiltro = new Mock<IProductoRepositorio>();
            mockFiltro.Setup(o => o.filtrarProductos(0)).Returns(new List<Producto>());

            var indexT = new AlmacenController(null, null, mockFiltro.Object, null, null);
            var view = indexT.filtrarProducto(0);

            Assert.IsNotNull(view);
        }

        [Test]
        public void filtroProductoVentaGetViewCase01()
        {
            var mockFiltro = new Mock<IProductoRepositorio>();
            mockFiltro.Setup(o => o.filtrarProductos(0)).Returns(new List<Producto>());

            var indexT = new AlmacenController(null, null, mockFiltro.Object, null, null);
            var view = indexT.filtrarProductoVenta(0);

            Assert.IsNotNull(view);
        }

        [Test]
        public void EditarProductoGetViewCase01()
        {
            var mockEditar = new Mock<IProductoRepositorio>();
            mockEditar.Setup(o => o.listarProducto(0)).Returns(new Producto());

            var indexT = new AlmacenController(null, null, mockEditar.Object, null, null);
            var view = indexT.EditarProducto(0);

            Assert.IsNotNull(view);
        }
    }
}
