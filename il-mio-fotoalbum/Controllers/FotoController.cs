using il_mio_fotoalbum.Data;
using il_mio_fotoalbum.Models;
using Microsoft.AspNetCore.Mvc;

namespace il_mio_fotoalbum.Controllers
{
    public class FotoController : Controller
    {

        //INDEX
        public IActionResult Index()
        {
            return View(FotoManger.GetAllFoto());
        }


        //SHOW
        public IActionResult Show(int id)
        {
            var foto = FotoManger.GetFoto(id);
            if (foto != null)
            {
                return View(foto); 
            }

            return View("Errore");
        }

        //CREATE
        public IActionResult Create()
        {
            FotoFormModel model = new FotoFormModel();
            model.Foto = new Foto();
            model.CreaCategorie();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FotoFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.CreaCategorie();
                return View("Create", data);
            }

            FotoManger.InsertFoto(data.Foto, data.SelectCategorie);
            return RedirectToAction("Index");
        }
    }
}
