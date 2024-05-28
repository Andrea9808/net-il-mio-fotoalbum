using System.ComponentModel.DataAnnotations;

namespace il_mio_fotoalbum.Models
{
    public class Messaggio
    {
        [Key]public int Id { get; set; }
        public string Mittente { get; set; }
        public string Testo { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;


        public Messaggio() { }

        public Messaggio(string mittente, string testo)
        {
            Mittente = mittente;
            Testo = testo;
        }
    }
}
