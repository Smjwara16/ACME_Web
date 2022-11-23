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
    public class SystemUsersController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SystemUsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: SystemUsers
        public async Task<IActionResult> Index()
        {
              return View(await _context.SystemUsers.ToListAsync());
        }

        // GET: SystemUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SystemUsers == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUsers
                .FirstOrDefaultAsync(m => m.SystemUserId == id);
            if (systemUser == null)
            {
                return NotFound();
            }

            return View(systemUser);
        }

        // GET: SystemUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,UserPassword,EmailAddress,CellPhoneNumber,DateCreated,RoleId")] SystemUser systemUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemUser);
        }

        // GET: SystemUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SystemUsers == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUsers.FindAsync(id);
            if (systemUser == null)
            {
                return NotFound();
            }
            return View(systemUser);
        }

        // POST: SystemUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SystemUserId,UserName,UserPassword,EmailAddress,CellPhoneNumber,DateCreated,RoleId")] SystemUser systemUser)
        {
            if (id != systemUser.SystemUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemUserExists(systemUser.SystemUserId))
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
            return View(systemUser);
        }

        // GET: SystemUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SystemUsers == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUsers
                .FirstOrDefaultAsync(m => m.SystemUserId == id);
            if (systemUser == null)
            {
                return NotFound();
            }

            return View(systemUser);
        }

        // POST: SystemUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SystemUsers == null)
            {
                return Problem("Entity set 'ApplicationDBContext.SystemUsers'  is null.");
            }
            var systemUser = await _context.SystemUsers.FindAsync(id);
            if (systemUser != null)
            {
                _context.SystemUsers.Remove(systemUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemUserExists(int id)
        {
          return _context.SystemUsers.Any(e => e.SystemUserId == id);
        }
    }
}
