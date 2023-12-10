using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class PlaneInfo
    {
        [Key]
        public int PlaneID { get; set; }

        [Required(ErrorMessage = "Uçak adını giriniz.")]
        [Display(Name = "Uçak Adı")]
        public string PlaneName { get; set; }

        [Required(ErrorMessage = "Yolcu kapasitesini giriniz.")]
        [Display(Name = "Yolcu Kapasitesi")]
        public int SeatCapacity { get; set; }

        [Required(ErrorMessage = "Bilet ücretini giriniz.")]
        [Display(Name = "Ücret")]
        public float Price { get; set; }
        public ICollection<Flight>? Flights { get; set; }

    }
}
