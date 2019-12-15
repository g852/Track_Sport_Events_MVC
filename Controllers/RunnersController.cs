using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Track_Sport_Events_MVC.Models;

namespace Track_Sport_Events_MVC.Controllers
{
    [Authorize]
    public class RunnersController : Controller
    {
        private readonly Track_Sport_EventsDataContext _context;

        public RunnersController(Track_Sport_EventsDataContext context)
        {
            _context = context;
        }

        // GET: Runners
        public async Task<IActionResult> Index()
        {
            return View(await (from runners in _context.Runner select runners).ToListAsync());
        }

        // GET: Runners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runner = await _context.Runner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (runner == null)
            {
                return NotFound();
            }

            return View(runner);
        }

        // GET: Runners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Runners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GoldMedals")] Runner runner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(runner);
        }

        // GET: Runners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runner = await _context.Runner.FindAsync(id);
            if (runner == null)
            {
                return NotFound();
            }
            return View(runner);
        }

        // POST: Runners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GoldMedals")] Runner runner)
        {
            if (id != runner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunnerExists(runner.Id))
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
            return View(runner);
        }

        // GET: Runners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runner = await _context.Runner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (runner == null)
            {
                return NotFound();
            }

            return View(runner);
        }

        // POST: Runners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var runner = await _context.Runner.FindAsync(id);
            _context.Runner.Remove(runner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunnerExists(int id)
        {
            return _context.Runner.Any(e => e.Id == id);
        }
    }
}
