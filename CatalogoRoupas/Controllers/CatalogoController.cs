using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogoRoupas.Models;

namespace CatalogoRoupas.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly Contexto _context;

        public CatalogoController(Contexto context)
        {
            _context = context;
        }

        // GET: Catalogo
        public async Task<IActionResult> Index()
        {
              return _context.Catalogo != null ? 
                          View(await _context.Catalogo.ToListAsync()) :
                          Problem("Entity set 'Contexto.Catalogo'  is null.");
        }

        // GET: Catalogo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catalogo == null)
            {
                return NotFound();
            }

            var catalogoModel = await _context.Catalogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoModel == null)
            {
                return NotFound();
            }

            return View(catalogoModel);
        }

        // GET: Catalogo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Marculino,Peca")] CatalogoModel catalogoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogoModel);
        }

        // GET: Catalogo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catalogo == null)
            {
                return NotFound();
            }

            var catalogoModel = await _context.Catalogo.FindAsync(id);
            if (catalogoModel == null)
            {
                return NotFound();
            }
            return View(catalogoModel);
        }

        // POST: Catalogo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Marculino,Peca")] CatalogoModel catalogoModel)
        {
            if (id != catalogoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoModelExists(catalogoModel.Id))
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
            return View(catalogoModel);
        }

        // GET: Catalogo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catalogo == null)
            {
                return NotFound();
            }

            var catalogoModel = await _context.Catalogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoModel == null)
            {
                return NotFound();
            }

            return View(catalogoModel);
        }

        // POST: Catalogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catalogo == null)
            {
                return Problem("Entity set 'Contexto.Catalogo'  is null.");
            }
            var catalogoModel = await _context.Catalogo.FindAsync(id);
            if (catalogoModel != null)
            {
                _context.Catalogo.Remove(catalogoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoModelExists(int id)
        {
          return (_context.Catalogo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
