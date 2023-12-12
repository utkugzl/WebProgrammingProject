using Microsoft.AspNetCore.Mvc;

namespace WebProgramlamaProje.Controllers
{
    public class TicketSeatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public bool IsSeatTaken(int seatNumber)
        {
            // Koltuğun durumu burada kontrol edilecek (veritabanından alınabilir)
            // Örneğin: Veritabanından ilgili koltuğun durumu alınıp kontrol edilebilir
            // Bu sadece bir örnek, gerçek uygulama bağlamına göre düzenlenmelidir
            // Örnek: var isTaken = dbContext.Seats.FirstOrDefault(s => s.SeatNumber == seatNumber)?.IsTaken;

            // Bu örnekte her koltuk dolu olarak kabul ediliyor
            return true;
        }
    }
}
