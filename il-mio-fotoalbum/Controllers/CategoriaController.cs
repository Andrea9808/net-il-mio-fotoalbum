using il_mio_fotoalbum.Data;
using il_mio_fotoalbum.Models;
using Microsoft.AspNetCore.Mvc;

namespace il_mio_fotoalbum.Controllers
{
    public class CategoriaController : Controller
    {

        //INDEX
        public IActionResult Index()
        {
           return View(FotoManger.GetCategorie());
        }


        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", categoria);
            }

            CategoriaManager.InsertCategoria(categoria);
            return RedirectToAction("Index");
        }

        //DELETE
        [HttpPost]
        public IActionResult Delete(int id)
        {
            CategoriaManager.DeleteCategoria(id);
            return RedirectToAction("Index");
        }
    }
}
