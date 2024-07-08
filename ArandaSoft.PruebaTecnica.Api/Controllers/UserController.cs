using Microsoft.AspNetCore.Mvc;

namespace ArandaSoft.PruebaTecnica.Api.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
