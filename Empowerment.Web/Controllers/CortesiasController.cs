using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Empowerment.Web.Data;
using Empowerment.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Empowerment.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CortesiasController : Controller
    {
        private readonly DataContext _context;

        public CortesiasController(DataContext context)
        {
            _context = context;
        }

        // GET: Cortesias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cortesias.ToListAsync());
        }

        // GET: Cortesias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cortesia = await _context.Cortesias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cortesia == null)
            {
                return NotFound();
            }

            return View(cortesia);
        }

        // GET: Cortesias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cortesias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoDocumento,Documento,Nombre,Apellido,Telefono,Email,Direccion,Web,Instagram,Facebook,Otro,Cual,FechaInscripcion,ClaseCortesia")] Cortesia cortesia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cortesia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cortesia);
        }

        // GET: Cortesias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cortesia = await _context.Cortesias.FindAsync(id);
            if (cortesia == null)
            {
                return NotFound();
            }
            return View(cortesia);
        }

        // POST: Cortesias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDocumento,Documento,Nombre,Apellido,Telefono,Email,Direccion,Web,Instagram,Facebook,Otro,Cual,FechaInscripcion,ClaseCortesia")] Cortesia cortesia)
        {
            if (id != cortesia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cortesia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CortesiaExists(cortesia.Id))
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
            return View(cortesia);
        }

        // GET: Cortesias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cortesia = await _context.Cortesias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cortesia == null)
            {
                return NotFound();
            }

            return View(cortesia);
        }

        // POST: Cortesias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cortesia = await _context.Cortesias.FindAsync(id);
            _context.Cortesias.Remove(cortesia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CortesiaExists(int id)
        {
            return _context.Cortesias.Any(e => e.Id == id);
        }
    }
}
