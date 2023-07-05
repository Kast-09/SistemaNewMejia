using Microsoft.AspNetCore.Mvc;

namespace SistemaNewMejia.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
