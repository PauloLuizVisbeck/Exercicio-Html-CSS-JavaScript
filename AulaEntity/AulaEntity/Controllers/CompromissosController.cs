using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AulaEntity.Data;
using AulaEntity.Models;

namespace AulaEntity.Controllers
{
    public class CompromissosController : Controller
    {
        private readonly AulaEntityContext _context;

        public CompromissosController(AulaEntityContext context)
        {
            _context = context;
        }

        // GET: Compromissos
        //Código Index alterado conforme explicação do professor para listar dados de contato e local ao compromisso
        public async Task<IActionResult> Index()
        {
            var compromissos = await _context.Compromisso.ToListAsync();
            foreach (Compromisso compromisso in compromissos)
            {
                compromisso.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == compromisso.LocalId);
                compromisso.Contato = await _context.Contato.FirstOrDefaultAsync(c => c.Id == compromisso.ContatoId);
            }
            return View(compromissos);
        }

        // GET: Compromissos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // GET: Compromissos/Create
        // Código alterado pelo "amigo"
        public IActionResult Create()
        {
            ViewBag.Contatos = _context.Contato.ToList(); // Preenchendo ViewBag com os Contatos
            ViewBag.Locais = _context.Local.ToList(); // Preenchendo ViewBag com os Locais

            //ViewBag.Contatos = new SelectList(_context.Contato, "Id", "Nome"); //Feito pelo professor

            return View();
        }

        // POST: Compromissos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Data,LocalId,ContatoId")] Compromisso compromisso)
        {
            compromisso.Contato = await _context.Contato.FindAsync(compromisso.ContatoId);
            compromisso.Local = await _context.Local.FindAsync(compromisso.LocalId);
            //if (ModelState.IsValid)
            //{
            _context.Add(compromisso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            // }
            return View(compromisso);
        }

        // GET: Compromissos/Edit/5
        /*
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso == null)
            {
                return NotFound();
            }

            ViewBag.Contatos = new SelectList(_context.Contato.ToList(), "Id", "Nome");
            ViewBag.Locais = new SelectList(_context.Local.ToList(), "Id", "Nome");

            //ViewBag.Contatos = _context.Contato.ToList(); //Populando a ViewBag com Contatos
            //ViewBag.Locais = _context.Local.ToList(); //Populando a ViewBag com Contatos

            return View(compromisso);
        }
        */
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso == null)
            {
                return NotFound();
            }

            
            compromisso.Contato = await _context.Contato.FindAsync(compromisso.ContatoId);
            compromisso.Local = await _context.Local.FindAsync(compromisso.LocalId);


            ViewBag.Contatos = new SelectList(_context.Contato, "Id", "Nome");
            ViewBag.Locais = new SelectList(_context.Local, "Id", "Nome");

            return View(compromisso);
        }

        // POST: Compromissos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Data,LocalId,ContatoId")] Compromisso compromisso)
        {
            if (id != compromisso.Id)
            {
                return NotFound();
            }

            try
            {                
                _context.Update(compromisso);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompromissoExists(compromisso.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Compromissos/Delete/5        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }


        // POST: Compromissos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compromisso == null)
            {
                return Problem("Entity set 'AulaEntityContext.Compromisso'  is null.");
            }
            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso != null)
            {
                _context.Compromisso.Remove(compromisso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompromissoExists(int id)
        {
            return (_context.Compromisso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
