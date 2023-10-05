using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kakoyzheyadebil.Domain;
using Microsoft.AspNetCore.Authorization;

namespace kakoyzheyadebil.Controllers
{
    [Authorize]
    [Route("Personel/[action]")]
    public class РябСотрудникиController : Controller
    {
        private readonly appDbContext _context;

        public РябСотрудникиController(appDbContext context)
        {
            _context = context;
        }

        // GET: РябСотрудники
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.РябСотрудникиs.Include(р => р.РябIdДолжностиNavigation);
            return View(await dbContext.ToListAsync());
        }

        // GET: РябСотрудники
        public async Task<IActionResult> Find(string name)
        {
            var dbContext = _context.РябСотрудникиs.Include(р => р.РябIdДолжностиNavigation).Where(e => e.РябИмя != null && e.РябИмя.Contains(name));
            return View(nameof(Index), await dbContext.ToListAsync());
        }

        // GET: РябСотрудники/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.РябСотрудникиs == null)
            {
                return NotFound();
            }

            var рябСотрудники = await _context.РябСотрудникиs
                .Include(р => р.РябIdДолжностиNavigation)
                .FirstOrDefaultAsync(m => m.РябIdСотрудника == id);
            if (рябСотрудники == null)
            {
                return NotFound();
            }

            return View(рябСотрудники);
        }


        // GET: РябСотрудники/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["РябIdДолжности"] = new SelectList(_context.РябДолжностиs, "РябIdДолжности", "РябIdДолжности");
            return View();
        }

        // POST: РябСотрудники/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("РябФамилия,РябИмя,РябОтчество,РябАдрес,РябТелефон,РябIdДолжности,РябАдресШифр")] РябСотрудники рябСотрудники)
        {
            if (ModelState.IsValid)
            {
                _context.Add(рябСотрудники);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["РябIdДолжности"] = new SelectList(_context.РябДолжностиs, "РябIdДолжности", "РябIdДолжности", рябСотрудники.РябIdДолжности);
            return View(рябСотрудники);
        }

        // GET: РябСотрудники/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.РябСотрудникиs == null)
            {
                return NotFound();
            }

            var рябСотрудники = await _context.РябСотрудникиs.FindAsync(id);
            if (рябСотрудники == null)
            {
                return NotFound();
            }
            ViewData["РябIdДолжности"] = new SelectList(_context.РябДолжностиs, "РябIdДолжности", "РябIdДолжности", рябСотрудники.РябIdДолжности);
            return View(рябСотрудники);
        }

        // POST: РябСотрудники/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("РябIdСотрудника,РябФамилия,РябИмя,РябОтчество,РябАдрес,РябТелефон,РябIdДолжности,РябАдресШифр")] РябСотрудники рябСотрудники)
        {
            if (id != рябСотрудники.РябIdСотрудника)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(рябСотрудники);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!РябСотрудникиExists(рябСотрудники.РябIdСотрудника))
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
            ViewData["РябIdДолжности"] = new SelectList(_context.РябДолжностиs, "РябIdДолжности", "РябIdДолжности", рябСотрудники.РябIdДолжности);
            return View(рябСотрудники);
        }

        // GET: РябСотрудники/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.РябСотрудникиs == null)
            {
                return NotFound();
            }

            var рябСотрудники = await _context.РябСотрудникиs
                .Include(р => р.РябIdДолжностиNavigation)
                .FirstOrDefaultAsync(m => m.РябIdСотрудника == id);
            if (рябСотрудники == null)
            {
                return NotFound();
            }

            return View(рябСотрудники);
        }

        // POST: РябСотрудники/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.РябСотрудникиs == null)
            {
                return Problem("Entity set 'DbContext.РябСотрудникиs'  is null.");
            }
            var рябСотрудники = await _context.РябСотрудникиs.FindAsync(id);
            if (рябСотрудники != null)
            {
                _context.РябСотрудникиs.Remove(рябСотрудники);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool РябСотрудникиExists(int id)
        {
            return (_context.РябСотрудникиs?.Any(e => e.РябIdСотрудника == id)).GetValueOrDefault();
        }
    }
}
