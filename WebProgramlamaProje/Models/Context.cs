using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Models
{
    public class Context:DbContext
    {
        public DbSet<Admin> AdminLogins { get; set; }
        public DbSet<Passenger> PassengerLogins { get; set; }
        public DbSet<PlaneInfo> PlaneInfos { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PlaneSystem;Trusted_Connection=True;");
        }

        
    }
}
