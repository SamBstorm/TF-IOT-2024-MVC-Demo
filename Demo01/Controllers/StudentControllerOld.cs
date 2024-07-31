using Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class StudentControllerOld : Controller
    {

        private readonly ILogger<StudentControllerOld> _logger;

        public StudentControllerOld(ILogger<StudentControllerOld> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Bienvenue sur Student/Index");
            return View();
        }

        public IActionResult Damier(int id = 10) {
            ViewData["size"] = id;
            return View();
        }

        [Route("/Student/Save/{name}")]
        public IActionResult SaveName(string name)
        {
            TempData["Name"] = name;
            TempData.Keep();
            return View();
        }

        public IActionResult ShowName() {
            if (TempData.ContainsKey("Name"))
                TempData.Keep();
            return View();
        }

        public IActionResult Details(int? id) {
            if (id is null) return RedirectToAction(nameof(Index));
            StudentDetailsViewModel model = new StudentDetailsViewModel() { 
                Student_Id = (int)id,
                First_Name = "Georges",
                Last_Name = "Lucas",
                Login = "glucas",
                Birth_Date = new DateOnly(1954,1,1),
                Year_Result = 10
            };
            return View(model);
        }
    }
}
