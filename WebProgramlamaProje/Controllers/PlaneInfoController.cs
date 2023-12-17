using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class PlaneInfoController : Controller
    {
        private readonly Context _context;
        private Context context = new Context();

        public PlaneInfoController()
        {
            _context = context;
        }

        // GET: PlaneInfo
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return _context.PlaneInfos != null ? 
                          View(await _context.PlaneInfos.ToListAsync()) :
                          Problem("Entity set 'Context.PlaneInfos'  is null.");
        }

        // GET: PlaneInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null || _context.PlaneInfos == null)
            {
                return NotFound();
            }

            var planeInfo = await _context.PlaneInfos
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (planeInfo == null)
            {
                return NotFound();
            }

            return View(planeInfo);
        }

        // GET: PlaneInfo/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        // POST: PlaneInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneID,PlaneName,SeatCapacity,Price")] PlaneInfo planeInfo)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (ModelState.IsValid)
            {
                _context.Add(planeInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planeInfo);
        }

        // GET: PlaneInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null || _context.PlaneInfos == null)
            {
                return NotFound();
            }

            var planeInfo = await _context.PlaneInfos.FindAsync(id);
            if (planeInfo == null)
            {
                return NotFound();
            }
            return View(planeInfo);
        }

        // POST: PlaneInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlaneID,PlaneName,SeatCapacity,Price")] PlaneInfo planeInfo)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id != planeInfo.PlaneID)
            {
                return NotFound();
            }

            _context.Update(planeInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: PlaneInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id == null || _context.PlaneInfos == null)
            {
                return NotFound();
            }

            var planeInfo = await _context.PlaneInfos
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (planeInfo == null)
            {
                return NotFound();
            }

            return View(planeInfo);
        }

        // POST: PlaneInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (_context.PlaneInfos == null)
            {
                return Problem("Entity set 'Context.PlaneInfos'  is null.");
            }
            var planeInfo = await _context.PlaneInfos.FindAsync(id);
            if (planeInfo != null)
            {
                _context.PlaneInfos.Remove(planeInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaneInfoExists(int id)
        {
            return (_context.PlaneInfos?.Any(e => e.PlaneID == id)).GetValueOrDefault();
        }
    }
}
