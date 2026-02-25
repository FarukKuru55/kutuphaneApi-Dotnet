using System.ComponentModel.DataAnnotations;

namespace kutuphaneApi2.Models
{
    public class Yazar
    {
        [Key] // Primary Key
        public int Id { get; set; }

        [Required] // Boş geçilemez
        public string AdSoyad { get; set; } = string.Empty;

        // Bir yazarın birden fazla kitabı olabilir
        public List<Kitap> Kitaplar { get; set; } = new();
    }
}