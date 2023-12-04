using AgendaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaMVC.Controllers
{
    public class CompromissoController : Controller
    {
        public IActionResult Index()
        {
            return View(Dados.Db.compromissos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> Contatos = new List<SelectListItem>();
            Contatos = Dados.Db.contatos.Select(c => new SelectListItem()
            { Text = c.Email, Value = c.Id.ToString() }).ToList();
            ViewBag.Contatos = Contatos;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Compromisso compromisso)
        {
            // O if abaixo evita o erro que ocorre quando é o primeiro compromisso da lista, pois null + 1 gera um erro. Nesse caso
            // fazemos uma atribuição
            if(Dados.Db.compromissos.Count > 0) {
                compromisso.Id = Dados.Db.compromissos.Max(c => c.Id) + 1;
            }
            else
            {
                compromisso.Id = 1;
            }
            
            /*Contato ct = Dados.Db.contatos.FirstOrDefault(c => c.Id == compromisso.Id);
            compromisso.Contato = ct;*/
            compromisso.Contato = Dados.Db.contatos.FirstOrDefault(c => c.Id == compromisso.Contato.Id);
            Dados.Db.compromissos.Add(compromisso);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            Models.Compromisso compromisso = Dados.Db.compromissos.FirstOrDefault(ct => ct.Id == id);
            return View(compromisso);
        }

        [HttpPost]
        public IActionResult Editar(Models.Compromisso compromisso)
        {
            Models.Compromisso comp = Dados.Db.compromissos.FirstOrDefault(ct => ct.Id == compromisso.Id);
            comp.Descricao = compromisso.Descricao;
            comp.Data = compromisso.Data;
            comp.Contato = compromisso.Contato;
            return RedirectToAction("Index");
        }
    }
}
