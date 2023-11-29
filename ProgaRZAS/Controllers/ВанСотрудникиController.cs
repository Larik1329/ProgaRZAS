using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgaRZAS.Domain;
using Microsoft.AspNetCore.Authorization;
using Azure;
using kakoyzheyadebil.Domain;
using teh13th.String;
using teh13th.String.Extensions;

namespace ProgaRZAS.Controllers
{
   

    [Authorize]
    [Route("Personel/[action]")]
    public class ВанСотрудникиController : Controller
    {
       
        private readonly ВанappDbContext _context;

            public ВанСотрудникиController(ВанappDbContext context)
        {
            
            _context = context;
        }

        // GET: ВанСотрудники
        public async Task<IActionResult> Index()
        {
          
            var dbContext = _context.ВанСотрудникиs.Include(р => р.ВанIdДолжностиNavigation);
            return View(await dbContext.ToListAsync());
        }

        // GET: ВанСотрудники
        public async Task<IActionResult> Find(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return View(nameof(Index), await _context.ВанСотрудникиs.Include(р => р.ВанIdДолжностиNavigation).ToListAsync());
            }

            var dbContext = _context.ВанСотрудникиs.Include(р => р.ВанIdДолжностиNavigation).Where(e => e.ВанИмя != null && e.ВанИмя.Contains(name));
            return View(nameof(Index), await dbContext.ToListAsync());
        }

        // GET: ВанСотрудники/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ВанСотрудникиs == null)
            {
                return NotFound();
            }

            var ВанСотрудники = await _context.ВанСотрудникиs
                .Include(р => р.ВанIdДолжностиNavigation)
                .FirstOrDefaultAsync(m => m.ВанIdСотрудника == id);
            if (ВанСотрудники == null)
            {
                return NotFound();
            }

            return View(ВанСотрудники);
        }


        // GET: ВанСотрудники/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ВанIdДолжности"] = new SelectList(_context.ВанДолжностиs, "ВанIdДолжности", "ВанIdДолжности");
            return View();
        }

        // POST: ВанСотрудники/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ВанФамилия,ВанИмя,ВанОтчество,ВанАдрес,ВанТелефон,ВанIdДолжности,ВанАдресШифр")] ВанСотрудники ВанСотрудники)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ВанСотрудники);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ВанIdДолжности"] = new SelectList(_context.ВанДолжностиs, "ВанIdДолжности", "ВанIdДолжности", ВанСотрудники.ВанIdДолжности);
            return View(ВанСотрудники);
        }

        // GET: ВанСотрудники/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ВанСотрудникиs == null)
            {
                return NotFound();
            }

            var ВанСотрудники = await _context.ВанСотрудникиs.FindAsync(id);
            if (ВанСотрудники == null)
            {
                return NotFound();
            }
            ViewData["ВанIdДолжности"] = new SelectList(_context.ВанДолжностиs, "ВанIdДолжности", "ВанIdДолжности", ВанСотрудники.ВанIdДолжности);
            return View(ВанСотрудники);
        }

        // POST: ВанСотрудники/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit([Bind("ВанIdСотрудника,ВанФамилия,ВанИмя,ВанОтчество,ВанАдрес,ВанТелефон,ВанIdДолжности,ВанАдресШифр")] ВанСотрудники ВанСотрудники)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ВанСотрудники);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ВанСотрудникиExists(ВанСотрудники.ВанIdСотрудника))
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
            ViewData["ВанIdДолжности"] = new SelectList(_context.ВанДолжностиs, "ВанIdДолжности", "ВанIdДолжности", ВанСотрудники.ВанIdДолжности);
            return View(ВанСотрудники);
        }

        // GET: ВанСотрудники/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ВанСотрудникиs == null)
            {
                return NotFound();
            }

            var ВанСотрудники = await _context.ВанСотрудникиs
                .Include(р => р.ВанIdДолжностиNavigation)
                .FirstOrDefaultAsync(m => m.ВанIdСотрудника == id);
            if (ВанСотрудники == null)
            {
                return NotFound();
            }
           
            return View(ВанСотрудники);
        }

        // GET: ВанСотрудники/DeleteConfirmed/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.ВанСотрудникиs == null)
            {
                return Problem("Entity set 'DbContext.ВанСотрудникиs'  is null.");
            }
            
            var ВанСотрудники = await _context.ВанСотрудникиs
                .Include(р => р.ВанIdДолжностиNavigation)
                .FirstOrDefaultAsync(m => m.ВанIdСотрудника == id);
            if (ВанСотрудники != null)
            {
                _context.ВанСотрудникиs.Remove(ВанСотрудники);
                
            }

             _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ВанСотрудникиExists(int id)
        {
            return (_context.ВанСотрудникиs?.Any(e => e.ВанIdСотрудника == id)).GetValueOrDefault();
        }
    }
}
