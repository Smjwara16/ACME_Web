using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACME_Web.Data;
using ACME_Web.Models;

namespace ACME_Web.Controllers
{
    public class BusinessProjectsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public BusinessProjectsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: BusinessProjects
        public async Task<IActionResult> Index()
        {
              return View(await _context.BusinessProjects.ToListAsync());
        }

        // GET: BusinessProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessProjects == null)
            {
                return NotFound();
            }

            var businessProjects = await _context.BusinessProjects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (businessProjects == null)
            {
                return NotFound();
            }

            return View(businessProjects);
        }

        // GET: BusinessProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Name,Description,IsValid,DateCreated")] BusinessProjects businessProjects)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessProjects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessProjects);
        }

        // GET: BusinessProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessProjects == null)
            {
                return NotFound();
            }

            var businessProjects = await _context.BusinessProjects.FindAsync(id);
            if (businessProjects == null)
            {
                return NotFound();
            }
            return View(businessProjects);
        }

        // POST: BusinessProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Name,Description,IsValid,DateCreated")] BusinessProjects businessProjects)
        {
            if (id != businessProjects.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessProjects);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessProjectsExists(businessProjects.ProjectId))
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
            return View(businessProjects);
        }

        // GET: BusinessProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessProjects == null)
            {
                return NotFound();
            }

            var businessProjects = await _context.BusinessProjects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (businessProjects == null)
            {
                return NotFound();
            }

            return View(businessProjects);
        }

        // POST: BusinessProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessProjects == null)
            {
                return Problem("Entity set 'ApplicationDBContext.BusinessProjects'  is null.");
            }
            var businessProjects = await _context.BusinessProjects.FindAsync(id);
            if (businessProjects != null)
            {
                _context.BusinessProjects.Remove(businessProjects);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessProjectsExists(int id)
        {
          return _context.BusinessProjects.Any(e => e.ProjectId == id);
        }
    }
}
