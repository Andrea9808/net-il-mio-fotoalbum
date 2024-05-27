using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace il_mio_fotoalbum.Models
{
    [Table("Foto")]
    public class Foto
    {

        [Key]public int Id { get; set; }

        [Column("titolo")]
        public string Titolo { get; set; }

        [Column("descrizione")]
        public string Descrizione { get; set; }

        [Column("immagine")]
        public byte[]? Immagine { get; set; }
        public string ImgSrc => Immagine != null ? $"data:image/jpeg;base64,{System.Convert.ToBase64String(Immagine)}" : "";

        [Column("visibile")]
        public bool Visibile { get; set; }

        // * to *
        public List<Categoria> Categorias { get; set; }
        public Foto() { }

        public Foto(string titolo, string descrizione, byte[] immagine, bool visibile)
        {
            this.Titolo = titolo;
            this.Descrizione = descrizione;
            this.Immagine = immagine;
            this.Visibile = visibile;
        }
    }
}
