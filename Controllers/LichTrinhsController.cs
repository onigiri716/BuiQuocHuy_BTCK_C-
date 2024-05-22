using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuiQuocHuy_BTCK_C_.Data;
using BuiQuocHuy_BTCK_C_.Models;

namespace BuiQuocHuy_BTCK_C_.Controllers
{
    public class LichTrinhsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LichTrinhsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LichTrinhs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LichTrinhs.Include(l => l.PhongBan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LichTrinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichTrinh = await _context.LichTrinhs
                .Include(l => l.PhongBan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lichTrinh == null)
            {
                return NotFound();
            }

            return View(lichTrinh);
        }

        // GET: LichTrinhs/Create
        public IActionResult Create()
        {
            ViewData["PhongBanId"] = new SelectList(_context.PhongBans, "Id", "TenPB");
            return View();
        }

        // POST: LichTrinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LichTrinh lichTrinh)
        {
           
                _context.Add(lichTrinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["PhongBanId"] = new SelectList(_context.PhongBans, "Id", "TenPB", lichTrinh.PhongBanId);
            return View(lichTrinh);
        }

        // GET: LichTrinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichTrinh = await _context.LichTrinhs.FindAsync(id);
            if (lichTrinh == null)
            {
                return NotFound();
            }
            ViewData["PhongBanId"] = new SelectList(_context.PhongBans, "Id", "TenPB", lichTrinh.PhongBanId);
            return View(lichTrinh);
        }

        // POST: LichTrinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LichTrinh lichTrinh)
        {
            if (id != lichTrinh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichTrinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichTrinhExists(lichTrinh.Id))
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
            ViewData["PhongBanId"] = new SelectList(_context.PhongBans, "Id", "TenPB", lichTrinh.PhongBanId);
            return View(lichTrinh);
        }

        // GET: LichTrinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichTrinh = await _context.LichTrinhs
                .Include(l => l.PhongBan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lichTrinh == null)
            {
                return NotFound();
            }

            return View(lichTrinh);
        }

        // POST: LichTrinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lichTrinh = await _context.LichTrinhs.FindAsync(id);
            if (lichTrinh != null)
            {
                _context.LichTrinhs.Remove(lichTrinh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichTrinhExists(int id)
        {
            return _context.LichTrinhs.Any(e => e.Id == id);
        }
    }
}
