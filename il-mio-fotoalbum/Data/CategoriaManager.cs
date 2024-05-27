using il_mio_fotoalbum.Models;

namespace il_mio_fotoalbum.Data
{
    public class CategoriaManager
    {
        public static void InsertCategoria(Categoria categoria)
        {
            using var db = new FotoContext();
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }
    }
}
