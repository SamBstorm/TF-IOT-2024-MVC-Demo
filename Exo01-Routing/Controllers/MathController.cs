using Microsoft.AspNetCore.Mvc;

namespace Exo01_Routing.Controllers
{
    public class MathController : Controller
    {
        public string Index(string? user)
        {
            if (user is null || user != "NCage")
                return "Bienvenue sur le module Math";
            else
                return
@"Cage, acteur fougueux, visage marqué par les films,
De « Leaving Las Vegas » à « Face Off », tu nous éblouis.
Nicolas, roi du kitsch, dans « National Treasure »,
Tu nous fais rire et frissonner avec tes facéties.
Sous mille masques, Cage, ton talent se dévoile,
De « Adaptation » à « Pig », ton art nous émeut.";
        }
        [Route("Math/Table/{id}")]
        public string Table(int id)
        {
            string resultat = "";
            for (int i = 1; i <= 10; i++)
            {
                resultat += $"{id} X {i} = {id * i}\n";
            }
            return resultat;
        }
        [Route("Math/Addition/{nb1}/{nb2}")]
        [Route("Math/{nb1}/plus/{nb2}")]
        public string Addition(int nb1, int nb2)
        {
            return $"{nb1} + {nb2} = {nb1 + nb2}";
        }

        [Route("Math/DemoAddition/{nb1}/{nb2}")]
        public object DemoAddition(int nb1, int nb2)
        {
            return new { nb1, nb2, result = nb1+nb2 };
        }

        public int[] Compteur(int id = 100)
        {
            int[] resultat = new int[id+1];
            for (int i = 0; i < resultat.Length; i++)
            {
                resultat[i] = i;
            }
            return resultat;
        }
    }
}
