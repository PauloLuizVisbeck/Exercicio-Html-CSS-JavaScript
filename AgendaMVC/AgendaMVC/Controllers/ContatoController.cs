using AgendaMVC.Interfaces;
using AgendaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMVC.Controllers
{
    public class ContatoController : Controller
    {
        // private static List<Models.Contato> contatos = new();
        private static int ultimoId = 1;

        public IActionResult Index()
        {
            // Instância de Contato
            //Criação da variável (ojeto) contatos que é do tipo Lista de Contato
            List<Contato> contatos = new List<Contato>();

            // Instância do DaoContato
            // Criação da variável (objeto) daoContato que é do tipo DaoContato e logo tem implementado o método consultar
            Dao.DaoContato daoContato = new Dao.DaoContato();

            // Chamando o método consultar do DaoContato para obter a lista de contatos
            contatos = daoContato.consultar();


            //As três linhas acima poderiam ser substituidas pela linha de comando abaixo (comentada):
            //List<Contato> contatos = new Dao.DaoContato().consultar();

            return View(contatos);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Contato contato)
        {
            /*Gravar em um a lista*/
            //contato.Id = ultimoId++;           
            //Dados.Db.contatos.Add(contato);

            /*Salva contato no Banco de Dados*/
            new Dao.DaoContato().salvar(contato);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            Models.Contato contato = Dados.Db.contatos.FirstOrDefault(ct => ct.Id == id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Models.Contato contato)
        {
            Models.Contato cont = Dados.Db.contatos.FirstOrDefault(ct => ct.Id == contato.Id);
            cont.Nome = contato.Nome;
            cont.Email = contato.Email;
            cont.Fone = contato.Fone;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Deletar(int? id)
        {
            ViewData["Id"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmarDelecao(int id)
        {
            new Dao.DaoContato().excluir(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            Models.Contato contato = Dados.Db.contatos.FirstOrDefault(ct => ct.Id == id);
            return View(contato);
        }
    }
}
