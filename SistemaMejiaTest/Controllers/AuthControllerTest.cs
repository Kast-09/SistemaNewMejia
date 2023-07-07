using SistemaNewMejia.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMejiaTest.Controllers
{
    public class AuthControllerTest
    {
        [Test]
        public void LoginGetViewCase01()
        {
            var indexT = new AuthController();
            var view = indexT.Login();

            Assert.IsNotNull(view);
        }
    }
}
