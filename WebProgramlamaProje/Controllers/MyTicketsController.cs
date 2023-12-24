using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class MyTicketsController : Controller
    {
        Context _context = new Context();
        public IActionResult Index()
        {
            string mail = HttpContext.Session.GetString("UserName");
            var tickets = _context.FlightBookings.Where(t=> t.CustomerEmail == mail).ToList();
            if(tickets.Count() == 0)
            {
                return RedirectToAction("TicketNotFound");
            }
            foreach(var t in tickets)
            {
                var flight = _context.Flights.FirstOrDefault(f => f.FlightID == t.FlightId);
                t.Flight = flight;
            }
            ViewBag.Tickets = tickets;
            return View();
           
        }

        public IActionResult TicketNotFound()
        {
            return View();
        }
    }
}
