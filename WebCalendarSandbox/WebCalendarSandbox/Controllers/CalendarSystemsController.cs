using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCalendarSandbox.Data;
using WebCalendarSandbox.Models;

namespace WebCalendarSandbox.Controllers
{
    public class CalendarSystemsController : Controller
    {
        private readonly WebCalendarSandboxContext _context;

        public CalendarSystemsController(WebCalendarSandboxContext context)
        {
            _context = context;
        }

        // GET: CalendarSystems1
        public async Task<IActionResult> Index()
        {
            return View(await _context.CalendarSystem.ToListAsync());
        }

        // GET: CalendarSystems1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendarSystem = await _context.CalendarSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendarSystem == null)
            {
                return NotFound();
            }

            return View(calendarSystem);
        }

        // GET: CalendarSystems1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalendarSystems1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author,ReleaseDate,isAbstract,MonthCount,DaysPerWeek")] CalendarSystem calendarSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendarSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calendarSystem);
        }

        // GET: CalendarSystems1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendarSystem = await _context.CalendarSystem.FindAsync(id);
            if (calendarSystem == null)
            {
                return NotFound();
            }
            return View(calendarSystem);
        }

        // POST: CalendarSystems1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Author,ReleaseDate,isAbstract,MonthCount,DaysPerWeek")] CalendarSystem calendarSystem)
        {
            if (id != calendarSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendarSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarSystemExists(calendarSystem.Id))
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
            return View(calendarSystem);
        }

        // GET: CalendarSystems1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendarSystem = await _context.CalendarSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calendarSystem == null)
            {
                return NotFound();
            }

            return View(calendarSystem);
        }

        // POST: CalendarSystems1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calendarSystem = await _context.CalendarSystem.FindAsync(id);
            if (calendarSystem != null)
            {
                _context.CalendarSystem.Remove(calendarSystem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarSystemExists(int id)
        {
            return _context.CalendarSystem.Any(e => e.Id == id);
        }
    }
}
