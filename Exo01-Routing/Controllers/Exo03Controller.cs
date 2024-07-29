using Microsoft.AspNetCore.Mvc;

namespace Exo01_Routing.Controllers
{
    public class Exo03Controller : Controller
    {
        public IActionResult Index(uint? quantity)
        {
            if (quantity is null) return RedirectToAction("Index","Home");
            //ViewBag.Quantity = quantity;
            ViewData["Quantity"] = quantity;
            return View();
        }
    }
}
