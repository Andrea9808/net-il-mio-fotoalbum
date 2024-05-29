using il_mio_fotoalbum.Models;
using Microsoft.EntityFrameworkCore;

namespace il_mio_fotoalbum.Data
{
    public class FotoManger
    {

        //PRENDE LA LISTA DELLE FOTO DAL DB
        public static List<Foto> GetAllFoto()
        {
            using FotoContext db = new FotoContext();
            return db.Fotos.Include(f => f.Categorias).ToList();
        }

        //PRENDE LE FOTO TRAMITE ID
        public static Foto GetFotoById(int id)
        {
            using (FotoContext db = new FotoContext())
            {
                return db.Fotos.Where(x => x.Id == id).FirstOrDefault();
            }  
        }

        //PRENDE LE FOTO DAL DATABASE
        public static Foto GetFoto(int id, bool includeReferences = true)
        {
            using FotoContext db = new FotoContext();
            if(includeReferences)
            {
                return db.Fotos.Where(x => x.Id == id).Include(x => x.Categorias).FirstOrDefault();
            }

            return db.Fotos.FirstOrDefault(x => x.Id == id);

        }

        //PRENDE TUTTE LE CATEGORIE
        public static List<Categoria> GetCategorie()
        {
            using (FotoContext db = new FotoContext())
            {
                return db.Categorias.ToList();
            }
        }

        //INSERISCI FOTO
        public static void InsertFoto(Foto foto, List<string> SelectCategorie = null)
        {
            using FotoContext db = new FotoContext();

            if(SelectCategorie != null)
            {
                foto.Categorias = new List<Categoria>();

                foreach (var CategoriaId in SelectCategorie)
                {
                   int id = int.Parse(CategoriaId);
                   var categoria = db.Categorias.FirstOrDefault(x => x.Id == id);
                   foto.Categorias.Add(categoria);
                }
            }

            db.Fotos.Add(foto);
            db.SaveChanges();
        }

        //MODIFICA FOTO
        public static bool UpdateFoto(int id, string titolo, string descrizione, bool visibile, byte[] immagine, List<string> categorie )
        {
            using FotoContext db = new FotoContext();

            var fotoDaModificare = db.Fotos.Where(x => x.Id == id).Include(x => x.Categorias).FirstOrDefault();

            if(fotoDaModificare == null)
            {
                return false;
            }

            fotoDaModificare.Titolo = titolo;
            fotoDaModificare.Descrizione = descrizione;
            fotoDaModificare.Immagine = immagine;
            fotoDaModificare.Visibile = visibile;


            fotoDaModificare.Categorias.Clear();
            if(categorie != null)
            {
                foreach (var categoria in categorie)
                {
                    int idCategoria = int.Parse(categoria);
                    var categoriaDaAggiungere = db.Categorias.FirstOrDefault(x => x.Id == idCategoria);
                    fotoDaModificare.Categorias.Add(categoriaDaAggiungere);
                }
            }

            db.SaveChanges();
            return true;
        }


        //ELIMINA FOTO
        public static bool DeleteFoto(int id)
        {
            using FotoContext db = new FotoContext();
            var fotoDaEliminare = db.Fotos.FirstOrDefault(x => x.Id == id);

            if (fotoDaEliminare == null)
            {
                return false;
            }

            db.Fotos.Remove(fotoDaEliminare);
            db.SaveChanges();

            return true;
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
