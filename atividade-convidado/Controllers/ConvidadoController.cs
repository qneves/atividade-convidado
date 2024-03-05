using atividade_convidado.Models;
using Microsoft.AspNetCore.Mvc;

namespace atividade_convidado.Controllers
{
    public class ConvidadoController : Controller
    {
        public static IList<Convidado> Convidados = new List<Convidado>()
        {
            new Convidado()
            {
                ConvidadoId = 1,
                Nome = "Neves",
                EMail = "neves@gmail.com",
                Telefone = "3532323232",
                comparecimento = true
            },
            new Convidado()
            {
                ConvidadoId = 2,
                Nome = "Neves 2",
                EMail = "neves2@gmail.com",
                Telefone = "123123",
                comparecimento = false
            },
        };

        // L I S T
        // L I S T
        public IActionResult Index()
        {
            return View(Convidados.OrderBy(conv => conv.comparecimento));
        }

        // C R E A T E
        // C R E A T E
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Convidado convidado)
        {
            Convidados.Add(convidado);
            convidado.ConvidadoId = Convidados.Select(conv => conv.ConvidadoId).Max() + 1;
            return RedirectToAction("Index");
        }

        // E D I T
        // E D I T
        public IActionResult Edit(int id)
        {
            return View(Convidados.Where(conv => conv.ConvidadoId == id).First());
        }
        [HttpPost]
        public IActionResult Edit(Convidado convidado)
        {
            Convidados.Remove(Convidados.Where(conv => conv.ConvidadoId == convidado.ConvidadoId).First());
            Convidados.Add(convidado);
            return RedirectToAction("Index");
        }

        // D E T A I L S
        // D E T A I L S
        public IActionResult Details(int id)
        {
            return View(Convidados.Where(conv => conv.ConvidadoId == id).First());
        }

        // D E L E T E 
        // D E L E T E 
        public IActionResult Delete(int id)
        {
            return View(Convidados.Where(conv => conv.ConvidadoId == id).First());
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var delConvidado = Convidados.FirstOrDefault(conv => conv.ConvidadoId == id);
            Convidados.Remove(delConvidado);
            return RedirectToAction("Index");
        }

        // LIST CONFIRMED
        // LIST CONFIRMED

        public IActionResult Confirmados()
        {
            return View(Convidados.Where(conv => conv.comparecimento == true));
        }
    }
}
