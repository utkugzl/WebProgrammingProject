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
    public class RegisterController : Controller
    {
        private readonly Context _context;
        private Context context = new Context();

        public RegisterController()
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
              return _context.PassengerLogins != null ? 
                          View(await _context.PassengerLogins.ToListAsync()) :
                          Problem("Entity set 'Context.PassengerLogins'  is null.");
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PassengerLogins == null)
            {
                return NotFound();
            }

            var passenger = await _context.PassengerLogins
                .FirstOrDefaultAsync(m => m.PassengerID == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassengerID,FirstName,LastName,Email,Password,ConfirmPassword,Age,PhoneNumber,TC")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login","Login");
            }
            
            return View(passenger);
        }



        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PassengerLogins == null)
            {
                return NotFound();
            }

            var passenger = await _context.PassengerLogins.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PassengerID,FirstName,LastName,Email,Password,ConfirmPassword,Age,PhoneNumber,TC")] Passenger passenger)
        {
            if (id != passenger.PassengerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerExists(passenger.PassengerID))
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
            return View(passenger);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PassengerLogins == null)
            {
                return NotFound();
            }

            var passenger = await _context.PassengerLogins
                .FirstOrDefaultAsync(m => m.PassengerID == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PassengerLogins == null)
            {
                return Problem("Entity set 'Context.PassengerLogins'  is null.");
            }
            var passenger = await _context.PassengerLogins.FindAsync(id);
            if (passenger != null)
            {
                _context.PassengerLogins.Remove(passenger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerExists(int id)
        {
          return (_context.PassengerLogins?.Any(e => e.PassengerID == id)).GetValueOrDefault();
        }
    }
}
