using Microsoft.AspNetCore.Mvc;
using RepresentanteMVC.Dados;
using RepresentanteMVC.Models;

namespace RepresentanteMVC.Controllers
{
    public class RepresentanteController : Controller
    {
		public IActionResult Index(string sortOrder)
		{          
			ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) || sortOrder == "name_asc" ? "name_desc" : "name_asc";
			ViewData["IdSortParm"] = sortOrder == "id_asc" ? "id_desc" : "id_asc";

			var representantes = new DadosRepresentante().ConsultarTodos();

			switch (sortOrder)
			{
				case "name_desc":
					representantes = representantes.OrderByDescending(r => r.RazaoSocial).ToList();
					break;
				case "name_asc":
					representantes = representantes.OrderBy(r => r.RazaoSocial).ToList();
					break;
				case "id_desc":
					representantes = representantes.OrderByDescending(r => r.Id).ToList();
					break;
                case "id_asc":
					representantes = representantes.OrderBy(r => r.Id).ToList();
					break;
				default:
                    representantes = representantes.OrderBy(r => r.Id).ToList();
					break;
			}

			return View(representantes);
		}

		[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Representante representante)
        {
            new DadosRepresentante().Adicionar(representante);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Representante representante = new DadosRepresentante().ConsultarPorId((int)id);
            return View(representante);
        }

        [HttpPost]
        public IActionResult Edit(Representante representante)
        {
            Representante representes = new DadosRepresentante().ConsultarPorId(representante.Id);
            representes.RazaoSocial = representante.RazaoSocial;

            if (new DadosRepresentante().Editar(representante))
            {
                return RedirectToAction("Index");
            }
            return View(representante);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            Representante representante = new DadosRepresentante().ConsultarPorId((int)id);
            return View(representante);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            new DadosRepresentante().Deletar((int)id);
            return RedirectToAction("Index");
        }
    }
}
