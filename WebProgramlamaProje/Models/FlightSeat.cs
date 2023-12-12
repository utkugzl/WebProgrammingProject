using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class FlightSeat
    {
        [Key]
        public int SeatID { get; set; }
        public int SeatNumber { get; set; }
        public bool IsTaken { get; set; }

        public int FlightID { get; set; }
        public virtual Flight? Flight { get; set; }
    }
}
