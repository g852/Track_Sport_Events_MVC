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
    public class TrackSportEventsController : Controller
    {
        private readonly Track_Sport_EventsDataContext _context;

        public TrackSportEventsController(Track_Sport_EventsDataContext context)
        {
            _context = context;
        }

        // GET: TrackSportEvents
        public async Task<IActionResult> Index()
        {
            return View(await (from evets in _context.TrackSportEvent select evets).ToListAsync());
        }

        // GET: TrackSportEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackSportEvent = await _context.TrackSportEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trackSportEvent == null)
            {
                return NotFound();
            }

            return View(trackSportEvent);
        }

        // GET: TrackSportEvents/Create
        public IActionResult Create()
        {

            ViewData["eventType"] = new SelectList(Enum.GetValues(typeof(EventType)));
            return View();
        }

        // POST: TrackSportEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventName,Type")] TrackSportEvent trackSportEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trackSportEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trackSportEvent);
        }

        // GET: TrackSportEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
            var trackSportEvent = await _context.TrackSportEvent.FindAsync(id);

            ViewData["eventType"] = new SelectList(Enum.GetValues(typeof(EventType)), trackSportEvent.Type);
            if (trackSportEvent == null)
            {
                return NotFound();
            }
            return View(trackSportEvent);
        }

        // POST: TrackSportEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventName,Type")] TrackSportEvent trackSportEvent)
        {
            if (id != trackSportEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trackSportEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackSportEventExists(trackSportEvent.Id))
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
            return View(trackSportEvent);
        }

        // GET: TrackSportEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackSportEvent = await _context.TrackSportEvent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trackSportEvent == null)
            {
                return NotFound();
            }

            return View(trackSportEvent);
        }

        // POST: TrackSportEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trackSportEvent = await _context.TrackSportEvent.FindAsync(id);
            _context.TrackSportEvent.Remove(trackSportEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackSportEventExists(int id)
        {
            return _context.TrackSportEvent.Any(e => e.Id == id);
        }
    }
}
