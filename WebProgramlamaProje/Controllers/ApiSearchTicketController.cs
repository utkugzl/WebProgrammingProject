using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlamaProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiSearchTicketController : ControllerBase
    {
        private Context context = new Context();


        // GET api/<ApiSearchTicketController>/5
        [HttpGet("{ticketNo}")]
        public ActionResult<FlightBooking> Get(int? ticketNo)
        {
            if (ticketNo is null)
            {
                return NotFound();
            }
            var ticket = context.FlightBookings.FirstOrDefault(x => x.TicketNumber == ticketNo);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // POST api/<ApiSearchTicketController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiSearchTicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiSearchTicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
