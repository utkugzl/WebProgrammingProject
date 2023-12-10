using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlamaProje.Models
{
    [Table("FlightBooking")]
    public class FlightBooking
    {
        [Key]
        public int BookingID { get; set; }

        [Required(ErrorMessage = "Lütfen Adınızı giriniz.")]
        [Display(Name = "İsim")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Lütfen adresinizi giriniz.")]
        [Display(Name = "Adres")]
        [StringLength(50)]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)] 
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Koltuk numarası seçiniz.")]
        [Display(Name = "Koltuk numarası")]
        public int CustomerSeats { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
        [Display(Name = "Telefon numarası")]
        public string CustomerPhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen TC numaranızı giriniz.")]
        [Display(Name = "TC")]
        [StringLength(20)]
        public string CustomerTC { get; set; }

        public int FlightID { get; set; }

        public virtual Flight? Flight { get; set; }

    }
}

