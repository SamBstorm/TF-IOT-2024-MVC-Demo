using Demo01.Handlers;
using Demo01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Demo01.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }
        [Route("SeConnecter")]
        public IActionResult Login()
        {
            //return View("LoginHtmlHelpers");
            return View("LoginTagHelpers");
        }
        [Route("SeConnecter")]
        [HttpPost]
        public IActionResult Login(AuthLoginForm form)
        {
            ValidationLogin(form, ModelState);
            if (ModelState.IsValid) {
                //Exemple : Sauvegarde en base de données
                TempData["notification"] = "Connection réussie";
                return RedirectToAction(nameof(Index), "Student");
            }
            ViewData["notification"] = "Connection échouée";
            //return View("LoginHtmlHelpers", form);
            return View("LoginTagHelpers", form);
        }

        [NonAction]
        private static void ValidationLogin(AuthLoginForm form, ModelStateDictionary modelState)
        {
            //modelState.IsRequired(form.Login, nameof(form.Login));
            //modelState.HasMinLenght(form.Login, nameof(form.Login), 2);
            //modelState.HasMaxLenght(form.Login, nameof(form.Login), 6);
            //modelState.IsRequired(form.Password, nameof(form.Password));
            //modelState.HasMinLenght(form.Password, nameof(form.Password), 8);
            //modelState.HasMaxLenght(form.Password, nameof(form.Password), 64);
            modelState.IsMatched(form.Password, nameof(form.Password), @"[0-9]+", "Le champ \"{0}\" doit contenir un numéro.");
            modelState.IsMatched(form.Password, nameof(form.Password), @"[a-z]+", "Le champ \"{0}\" doit contenir une minuscule.");
            modelState.IsMatched(form.Password, nameof(form.Password), @"[A-Z]+", "Le champ \"{0}\" doit contenir une majuscule.");
            modelState.IsMatched(form.Password, nameof(form.Password), @"[@#\-\\+=$&]+", "Le champ \"{0}\" doit contenir un symbole.");

        }

        
    }
}
