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
    public class VentaControllerTest
    {
        [Test]
        public void IndexGetViewCase01()
        {
            var mockProducto = new Mock<IProductoRepositorio>();
            mockProducto.Setup(o => o.listar()).Returns(new List<Producto>());

            var indexT = new VentaController(null, null, mockProducto.Object, null, null);
            var view = indexT.Index();

            Assert.IsNotNull(view);
        }

        [Test]
        public void verCestaGetViewCase01()
        {
            var mockProducto = new Mock<IProductoRepositorio>();
            mockProducto.Setup(o => o.listar()).Returns(new List<Producto>());

            var indexT = new VentaController(null, null, mockProducto.Object, null, null);
            var view = indexT.VerCesta();

            Assert.IsNotNull(view);
        }

        [Test]
        public void VenderGetViewCase01()
        {
            var mockVenta = new Mock<IVentaRepositorio>();
            mockVenta.Setup(o => o.agregarVenta(new Venta()));
            mockVenta.Setup(o => o.agregarDetalleVenta(new DetalleVenta()));
            mockVenta.Setup(o => o.ultimaVenta()).Returns(new Venta());

            var indexT = new VentaController(null, null, null, null, mockVenta.Object);
            var view = indexT.Vender();

            Assert.IsNotNull(view);
        }
    }
}
