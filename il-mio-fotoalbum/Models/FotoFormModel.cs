using il_mio_fotoalbum.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace il_mio_fotoalbum.Models
{
    public class FotoFormModel
    {
        public Foto Foto { get; set; }
        public List<SelectListItem>? Categorie { get; set; }
        public List <string>? SelectCategorie { get; set; }
        public IFormFile? ImmagineFile { get; set; }



        public FotoFormModel() { }
        public FotoFormModel(Foto foto)
        {
            Foto = foto;
        }


        public void CreaCategorie()
        {
            this.Categorie = new List<SelectListItem>();
            this.SelectCategorie = new List<string>();
            var categorieFromDb = FotoManger.GetCategorie();
            foreach (var categoria in categorieFromDb)
            {
                bool Selezionata = this.SelectCategorie.Contains(categoria.Id.ToString());
                this.Categorie.Add(new SelectListItem()
                {
                    Text = categoria.Nome,
                    Value = categoria.Id.ToString(),
                    Selected = Selezionata
                });
                if(Selezionata)
                {
                    this.SelectCategorie.Add(categoria.Id.ToString());
                }
            }
        }

        public byte[] SetImmagine()
        {
            if(ImmagineFile == null)
            {
                return null;
            }

            using var stream = new MemoryStream();
            this.ImmagineFile?.CopyTo(stream);
            Foto.Immagine = stream.ToArray();

            return Foto.Immagine;
        }
    }



}
