using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Reservacii_3_pr.Data;
using ASP_Reservacii_3_pr.Models;

namespace ASP_Reservacii_3_pr.Controllers
{
    public class DiningTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiningTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiningTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tables.ToListAsync());
        }

        // GET: DiningTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diningTable = await _context.Tables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diningTable == null)
            {
                return NotFound();
            }

            return View(diningTable);
        }

        // GET: DiningTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiningTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Capacity")] DiningTable diningTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diningTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diningTable);
        }

        // GET: DiningTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diningTable = await _context.Tables.FindAsync(id);
            if (diningTable == null)
            {
                return NotFound();
            }
            return View(diningTable);
        }

        // POST: DiningTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Capacity")] DiningTable diningTable)
        {
            if (id != diningTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diningTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiningTableExists(diningTable.Id))
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
            return View(diningTable);
        }

        // GET: DiningTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diningTable = await _context.Tables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diningTable == null)
            {
                return NotFound();
            }

            return View(diningTable);
        }

        // POST: DiningTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diningTable = await _context.Tables.FindAsync(id);
            if (diningTable != null)
            {
                _context.Tables.Remove(diningTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiningTableExists(int id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }
    }
}
