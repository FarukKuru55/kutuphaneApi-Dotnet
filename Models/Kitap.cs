using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kutuphaneApi2.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Baslik { get; set; } = string.Empty;

        public bool MevcutMu { get; set; } = true;

        // Foreign Key: Bu kitap hangi yazara ait?
        public int YazarId { get; set; }

        [ForeignKey("YazarId")]
        public Yazar? Yazar { get; set; }
    }
}