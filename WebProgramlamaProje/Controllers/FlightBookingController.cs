using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class FlightBookingController : Controller

    {
        private Context context = new Context();

        public IActionResult Index(int flightId)
        {
         
            var flight = context.Flights.Where(f => f.FlightID == flightId).FirstOrDefault();
            if (flight is null)
            {
                return NotFound();
            }
            var seatCapacity = flight.PlaneSeat;
            ViewBag.capacity = seatCapacity;
            ViewBag.flightid = flight.FlightID;
            return View();
        }

        public IActionResult bookTicket(int CustomerSeats, FlightBooking booking)
        {
            var seat = context.FlightSeats.FirstOrDefault(s => s.SeatNumber == CustomerSeats);
            if (seat is not null)
            {

                seat.IsTaken = true;

                context.FlightBookings.Add(booking);

                // Veritabanındaki değişiklikleri kaydet
                context.SaveChanges();

                // Oluşturulan FlightBooking ID'sini alarak TicketDetails sayfasına yönlendir
                return RedirectToAction("TicketDetails", new { bookingId = booking.BookingID });

            }
            else
            {
                return View();
            }
        }



        public IActionResult TicketDetails()
        {
            var latestBooking = context.FlightBookings
           .Include(b => b.Flight)
           .OrderByDescending(b => b.BookingID)
           .FirstOrDefault();

            if (latestBooking != null)
            {
                return View(latestBooking);
            }
            else
            {
                return NotFound(); // Veya uygun bir hata işleme mekanizması
            }
        }
        //public IActionResult bookTicket()
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    _context.Add(flight);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    //ViewData["PlaneID"] = new SelectList(_context.PlaneInfos, "PlaneID", "PlaneName", flight.PlaneID);
        //    //return View(flight);
        //    return View();
        //}
    }
}


