using il_mio_fotoalbum.Data;
using il_mio_fotoalbum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace il_mio_fotoalbum.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FotoWebApiController : ControllerBase
    {
        //............./api/FotoWebApi/GetAllFoto/
        [HttpGet]
        public IActionResult GetAllFoto()
        {
            return Ok(FotoManger.GetAllFoto());
        }


        //............./api/FotoWebApi/CreaMessaggio/
        [HttpPost]
        public IActionResult CreaMessaggio([FromBody] Messaggio messaggio)
        {
            MessaggioManager.InsertMessaggio(messaggio);
            return Ok();
        }
    }
}
