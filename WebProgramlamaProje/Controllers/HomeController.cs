using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        private Context context = new Context();

        public HomeController()
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.dcity = _context.Flights.Select(f=> f.FlightFrom).Distinct().ToList();
            ViewBag.acity = _context.Flights.Select(f=> f.FlightTo).Distinct().ToList();
            return View();
        }
        
        public IActionResult Search(string cityFrom, string cityTo, DateTime flightDate)
        {
           
            var control = _context.Flights.Where(f => f.FlightFrom.Equals(cityFrom) && f.FlightTo.Equals(cityTo) && f.FlightDate.Equals(flightDate)).ToList();
            ViewBag.searchedFlights = control;
            return View();
        }
    }
}
