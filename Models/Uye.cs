using System.ComponentModel.DataAnnotations;

namespace kutuphaneApi2.Models
{
    public class Uye
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AdSoyad { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public List<OduncIslem> Islemler { get; set; } = new();
    }
}