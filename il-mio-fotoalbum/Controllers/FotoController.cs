using il_mio_fotoalbum.Data;
using Microsoft.AspNetCore.Mvc;

namespace il_mio_fotoalbum.Controllers
{
    public class FotoController : Controller
    {
        public IActionResult Index()
        {
            return View(FotoManger.GetFoto());
        }
    }
}
