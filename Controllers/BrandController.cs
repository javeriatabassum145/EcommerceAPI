using Microsoft.AspNetCore.Mvc;

namespace EcommerceCRUDAPI.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
