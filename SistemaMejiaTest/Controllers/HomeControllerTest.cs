using SistemaNewMejia.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMejiaTest.Controllers
{
    public class HomeControllerTest
    {
        [Test]
        public void HomeGetViewCase01()
        {
            var indexT = new HomeController();
            var view = indexT.Index();

            Assert.IsNotNull(view);
        }
    }
}
