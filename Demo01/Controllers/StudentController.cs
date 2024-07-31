using Demo01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class StudentController : Controller
    {
        private static readonly IEnumerable<StudentListItem> _students = new List<StudentListItem>(){
            new StudentListItem{Student_Id = 1, First_Name="Georges", Last_Name="Lucas"},
            new StudentListItem{Student_Id = 2, First_Name="Clint", Last_Name="Eastwood"},
            new StudentListItem{Student_Id = 3, First_Name="Robert", Last_Name="De Niro"}
        };

        //Action Index : permet d'afficher une liste des valeurs de l'ensemble des éléments
        // GET: StudentController
        public IActionResult Index()
        {
            IEnumerable<StudentListItem> model = _students;
            return View(model);
        }

        //Action Details : permet d'afficher l'ensemble des valeurs d'un élément traité
        // GET: StudentController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        //Action Create : permet d'afficher le formulaire de création d'un nouvel élément
        // GET: StudentController/Create
        public IActionResult Create()
        {
            return View();
        }

        //Action Create : permet de traiter les données du formulaire de création d'un nouvel élément
        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Formulaire invalide");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(form);
            }
        }

        //Action Edit : permet d'afficher le formulaire de mise à jour d'un élément existant
        // GET: StudentController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        //Action Edit : permet de traiter les données du formulaire de mise à jour d'un élément existant
        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Action Delete : permet d'afficher un formulaire de confirmation de suppression d'un élément existant
        // GET: StudentController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        //Action Delete : permet de confirmer le formulaire de suppression d'un élément existant
        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
