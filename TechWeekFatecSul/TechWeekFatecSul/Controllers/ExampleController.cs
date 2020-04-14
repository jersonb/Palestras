using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechWeekFatecSul.Data;
using TechWeekFatecSul.Models;

namespace TechWeekFatecSul.Controllers
{
    public class ExampleController : Controller
    {
        private readonly TechWeekFatecSulContext _context;

        public ExampleController(TechWeekFatecSulContext context)
        {
            _context = context;
        }

        // GET: Example
        public async Task<IActionResult> Index()
        {
            return View(await _context.Example.ToListAsync());
        }

        // GET: Example/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var example = await _context.Example
                .FirstOrDefaultAsync(m => m.Id == id);
            if (example == null)
            {
                return NotFound();
            }

            return View(example);
        }

        // GET: Example/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Example/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Registration,Attended")] Example example)
        {
            if (ModelState.IsValid)
            {
                _context.Add(example);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(example);
        }

        // GET: Example/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var example = await _context.Example.FindAsync(id);
            if (example == null)
            {
                return NotFound();
            }
            return View(example);
        }

        // POST: Example/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Registration,Attended")] Example example)
        {
            if (id != example.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(example);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExampleExists(example.Id))
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
            return View(example);
        }

        // GET: Example/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var example = await _context.Example
                .FirstOrDefaultAsync(m => m.Id == id);
            if (example == null)
            {
                return NotFound();
            }

            return View(example);
        }

        // POST: Example/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var example = await _context.Example.FindAsync(id);
            _context.Example.Remove(example);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExampleExists(int id)
        {
            return _context.Example.Any(e => e.Id == id);
        }
    }
}
