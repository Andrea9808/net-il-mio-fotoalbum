using il_mio_fotoalbum.Models;

namespace il_mio_fotoalbum.Data
{
    public class FotoManger
    {

        //PRENDE LE FOTO DAL DATABASE
        public static List<Foto> GetFoto()
        {
            using (FotoContext db = new FotoContext())
            {
                return db.Fotos.ToList();
            }
        }

        //INSERISCI FOTO
        public static void InsertFoto(Foto foto)
        {
            using (FotoContext db = new FotoContext())
            {
                db.Fotos.Add(foto);
                db.SaveChanges();
            }
        }


        //SOLO PER GENERARE DATI FAKE PER VEDERE SE TUTTO FUNZIONA
        //COUNT FOTO
        public static int CountFoto()
        {
            using (FotoContext db = new FotoContext())
            {
                return db.Fotos.Count();
            }
        }
        public static void Seed()
        {
            if(FotoManger.CountFoto() == 0)
            {
                FotoManger.InsertFoto(new Foto("Foto 1", "Descrizione foto 1", null, true));
                FotoManger.InsertFoto(new Foto("Foto 2", "Descrizione foto 2", null, true));
                FotoManger.InsertFoto(new Foto("Foto 3", "Descrizione foto 3", null, true));
                FotoManger.InsertFoto(new Foto("Foto 4", "Descrizione foto 4", null, true));
            }
        }
    }
}
