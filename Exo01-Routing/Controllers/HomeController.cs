using Exo01_Routing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Exo01_Routing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Bienvenue sur Index!");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //Action d'affichage du formulaire : méthode GET
        [HttpGet("/Home/Register")]
        [HttpGet("/Register")]
        [HttpGet("/Sinscrire")]
        public IActionResult Register()
        {
            return View();
        }

        //Action de traitement du formulaire : méthode POST
        [HttpPost("/Home/Register")]
        [HttpPost("/Register")]
        [HttpPost("/Sinscrire")]
        public IActionResult Register(HomeRegisterForm form)
        {
            ValidateHomeRegisterForm(form, ModelState);
            if(!ModelState.IsValid)
            {
                return View(form);
            }
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private static void ValidateHomeRegisterForm(HomeRegisterForm form, ModelStateDictionary modelState)
        {

            if (form.BirthDate > DateOnly.FromDateTime(DateTime.Now.AddYears(-18)))
            {
                modelState.AddModelError(nameof(form.BirthDate), "Vous n'êtes pas majeur.");
            }
            if(!string.IsNullOrWhiteSpace(form.Password) && !Regex.IsMatch(form.Password, "[a-z]+"))
            {
                modelState.AddModelError(nameof(form.Password),"Le mot de passe doit contenir une minuscule.");
            }
            if (!string.IsNullOrWhiteSpace(form.Password) && !Regex.IsMatch(form.Password, "[A-Z]+"))
            {
                modelState.AddModelError(nameof(form.Password), "Le mot de passe doit contenir une majuscule.");
            }
            if (!string.IsNullOrWhiteSpace(form.Password) && !Regex.IsMatch(form.Password, "[0-9]+"))
            {
                modelState.AddModelError(nameof(form.Password), "Le mot de passe doit contenir un chiffre.");
            }
        }
    }
}
