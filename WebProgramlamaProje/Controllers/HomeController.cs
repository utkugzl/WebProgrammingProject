using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebProgramlamaProje.Models;
using WebProgramlamaProje.Services;

namespace WebProgramlamaProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        private Context context = new Context();
        private readonly ILogger<HomeController> _logger;
        private  LanguageServices _localization;
        public HomeController(ILogger<HomeController> logger , LanguageServices localization)
        {
            _context = context;
            _localization = localization;
            _logger = logger;
        }

        public IActionResult changeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
              return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
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


        public async Task<IActionResult> SearchTicket(int ticketNo)
        {
            FlightBooking ticket = null;

            using (HttpClient client = new HttpClient())
            {
                // Ticket numarasını içeren URL'yi oluştur
                string apiUrl = $"https://localhost:7163/api/ApiSearchTicket/{ticketNo}";

                // GET isteği yap
                var response = await client.GetAsync(apiUrl);

                // Yanıtı oku
                if (response.IsSuccessStatusCode)
                {
                    var responseText = await response.Content.ReadAsStringAsync();

                    try
                    {
                        // JSON'u deserialize et
                        ticket = JsonConvert.DeserializeObject<FlightBooking>(responseText);
                    }
                    catch (JsonSerializationException)
                    {
                        // JSON bir dizi değilse veya deserialization hatası oluşursa
                        // Tek bir nesne olarak deserialize etmeye çalış
                        ticket = JsonConvert.DeserializeObject<FlightBooking>(responseText);
                    }
                }
                else
                {
                    // Başarısız bir durumda NotFound döndür
                    return NotFound();
                }
            }

            var flight = context.Flights.FirstOrDefault(f => f.FlightID == ticket.FlightId);
            ticket.Flight = flight;
            // ticket null değilse View'e gönder
            if (ticket != null)
            {

                return View(ticket);
            }
            else
            {
                ViewBag.ErrorMessage = "Belirtilen bilet numarası bulunamadı.";
                return RedirectToAction("Error");
            }



        }

        public IActionResult Error()
        {
            return View();
        }




    }
}
