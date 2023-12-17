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
    public class FlightsController : Controller
    {
        private readonly Context _context;
        private Context context = new Context();

        public FlightsController()
        {
            _context = context;
        }

        // GET: Flights
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

            var context = _context.Flights.Include(f => f.Plane);
            return View(await context.ToListAsync());
        }

        // GET: Flights/Details/5
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

            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Plane)
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
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

            ViewData["PlaneID"] = new SelectList(_context.PlaneInfos, "PlaneID", "PlaneName");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightID,FlightFrom,FlightTo,FlightDate,FlightTime,PlaneID,PlaneSeat,FlightTicketPrice,FlightPlaneType")] Flight flight)
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
                _context.Add(flight);
                await _context.SaveChangesAsync();
                for (int i = 1; i <= flight.PlaneSeat ; i++) // Örneğin 50 koltuk olsun
                {
                    var newSeat = new FlightSeat
                    {
                        SeatNumber = i,
                        IsTaken = false,
                        FlightID = flight.FlightID
                    };

                    _context.FlightSeats.Add(newSeat);
                }
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaneID"] = new SelectList(_context.PlaneInfos, "PlaneID", "PlaneName", flight.PlaneID);
            return View(flight);
        }

        // GET: Flights/Edit/5
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

            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewData["PlaneID"] = new SelectList(_context.PlaneInfos, "PlaneID", "PlaneName", flight.PlaneID);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightID,FlightFrom,FlightTo,FlightDate,FlightTime,PlaneID,PlaneSeat,FlightTicketPrice,FlightPlaneType")] Flight flight)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightID))
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
            ViewData["PlaneID"] = new SelectList(_context.PlaneInfos, "PlaneID", "PlaneName", flight.PlaneID);
            return View(flight);
        }

        // GET: Flights/Delete/5
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

            if (id == null || _context.Flights == null)
            {
                return NotFound();
            }

            var flight = await _context.Flights
                .Include(f => f.Plane)
                .FirstOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
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

            if (_context.Flights == null)
            {
                return Problem("Entity set 'Context.Flights'  is null.");
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
          return (_context.Flights?.Any(e => e.FlightID == id)).GetValueOrDefault();
        }
    }
}
