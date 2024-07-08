using Microsoft.AspNetCore.Mvc;

namespace ArandaSoft.PruebaTecnica.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
