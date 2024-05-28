using il_mio_fotoalbum.Models;

namespace il_mio_fotoalbum.Data
{
    public class CategoriaManager
    {

        //METODO PER INSERIRE UNA NUOVA CATEGORIA
        public static void InsertCategoria(Categoria categoria)
        {
            using var db = new FotoContext();
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        //METODO PER ELIMINARE UNA CATEGORIA
        public static void DeleteCategoria(int id)
        {
            using var db = new FotoContext();
            var categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
        }
    }


}
