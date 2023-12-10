using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Flight
    {
        [Key]
        public int FlightID { get; set; }

        [Required(ErrorMessage = "Lütfen kalkış noktasını giriniz.")]
        [Display(Name = "Nereden")]
        [StringLength(50)]
        public string FlightFrom { get; set; }

        [Required(ErrorMessage = "Lütfen varış noktasını giriniz.")]
        [Display(Name = "Nereye")]
        [StringLength(50)]
        public string FlightTo { get; set; }

        [Required(ErrorMessage = "Lütfen tarih seçiniz.")]
        [Display(Name = "Tarih")]
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; }

        [Required(ErrorMessage = "Lütfen saat seçiniz.")]
        [Display(Name = "Saat")]
        public string FlightTime { get; set; }

        [Required(ErrorMessage = "Lütfen uçak seçiniz.")]
        [Display(Name = "Uçak numarası")]
        public int PlaneID { get; set; }
        public PlaneInfo? Plane { get; set; }

        [Display(Name = "Boş koltuk sayısı")]
        [Required(ErrorMessage = "Lütfen boş koltuk sayısını giriniz.")]
        public int PlaneSeat { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat giriniz.")]
        [Display(Name = "Bilet ücreti")]
        public float FlightTicketPrice { get; set; }

        [Required(ErrorMessage = "Lütfen uçak tipini giriniz.")]
        [Display(Name = "Uçak tipi")]
        public string FlightPlaneType { get; set; }   
        
        //public virtual ICollection<FlightBooking> FlightBookings_tbls { get; set; }
    }
}
