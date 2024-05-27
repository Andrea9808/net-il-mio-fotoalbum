using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace il_mio_fotoalbum.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]public int Id { get; set; }

        [Column("nome")]

        public string Nome { get; set; }

        // * to *
        public List<Foto>? Fotos { get; set; }

        public Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
        }
    }
}
