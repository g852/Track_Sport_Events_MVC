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
    public class TimingRecordsController : Controller
    {
        private readonly Track_Sport_EventsDataContext _context;

        public TimingRecordsController(Track_Sport_EventsDataContext context)
        {
            _context = context;
        }

        // GET: TimingRecords
        public async Task<IActionResult> Index()
        {
            var track_Sport_EventsDataContext = _context.TimingRecord.Include(t => t.Runner).Include(t => t.TrackSportEvent);
            return View(await track_Sport_EventsDataContext.ToListAsync());
        }

        // GET: TimingRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timingRecord = await _context.TimingRecord
                .Include(t => t.Runner)
                .Include(t => t.TrackSportEvent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timingRecord == null)
            {
                return NotFound();
            }

            return View(timingRecord);
        }

        // GET: TimingRecords/Create
        public IActionResult Create()
        {
            ViewData["RunnerId"] = new SelectList(_context.Runner, "Id", "Name");
            ViewData["TrackSportEventId"] = new SelectList(_context.Set<TrackSportEvent>(), "Id", "EventName");
            return View();
        }

        // POST: TimingRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RunnerId,TrackSportEventId,RecordedTime,Date")] TimingRecord timingRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timingRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RunnerId"] = new SelectList(_context.Runner, "Id", "Name", timingRecord.RunnerId);
            ViewData["TrackSportEventId"] = new SelectList(_context.Set<TrackSportEvent>(), "Id", "EventName", timingRecord.TrackSportEventId);
            return View(timingRecord);
        }

        // GET: TimingRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timingRecord = await _context.TimingRecord.FindAsync(id);
            if (timingRecord == null)
            {
                return NotFound();
            }
            ViewData["RunnerId"] = new SelectList(_context.Runner, "Id", "Name", timingRecord.RunnerId);
            ViewData["TrackSportEventId"] = new SelectList(_context.Set<TrackSportEvent>(), "Id", "EventName", timingRecord.TrackSportEventId);
            return View(timingRecord);
        }

        // POST: TimingRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RunnerId,TrackSportEventId,RecordedTime,Date")] TimingRecord timingRecord)
        {
            if (id != timingRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timingRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimingRecordExists(timingRecord.Id))
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
            ViewData["RunnerId"] = new SelectList(_context.Runner, "Id", "Name", timingRecord.RunnerId);
            ViewData["TrackSportEventId"] = new SelectList(_context.Set<TrackSportEvent>(), "Id", "EventName", timingRecord.TrackSportEventId);
            return View(timingRecord);
        }

        // GET: TimingRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timingRecord = await _context.TimingRecord
                .Include(t => t.Runner)
                .Include(t => t.TrackSportEvent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timingRecord == null)
            {
                return NotFound();
            }

            return View(timingRecord);
        }

        // POST: TimingRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timingRecord = await _context.TimingRecord.FindAsync(id);
            _context.TimingRecord.Remove(timingRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimingRecordExists(int id)
        {
            return _context.TimingRecord.Any(e => e.Id == id);
        }
    }
}
