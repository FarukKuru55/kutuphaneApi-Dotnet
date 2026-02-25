using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphaneApi2.Models
{
    public class OduncIslem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int KitapId { get; set; }
        [ForeignKey("KitapId")]
        public Kitap? Kitap { get; set; }

        [Required]
        public int UyeId { get; set; }
        [ForeignKey("UyeId")]
        public Uye? Uye { get; set; }

        public DateTime VerilisTarihi { get; set; } = DateTime.Now;
        public DateTime? IadeTarihi { get; set; }
    }
}