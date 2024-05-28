using il_mio_fotoalbum.Models;

namespace il_mio_fotoalbum.Data
{
    public class MessaggioManager
    {
        //METODO PER INSERIRE UN NUOVO MESSAGGIO
        public static void InsertMessaggio(Messaggio messaggio)
        {
            using FotoContext db = new FotoContext();
            db.Messaggi.Add(messaggio);
            db.SaveChanges();
        }
   
    }
}
