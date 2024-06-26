﻿using il_mio_fotoalbum.Data;
using il_mio_fotoalbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace il_mio_fotoalbum.Controllers
{
    public class FotoController : Controller
    {

        //INDEX
        [Authorize(Roles = "ADMIN, USER")]
        public IActionResult Index()
        {
            return View(FotoManger.GetAllFoto());
        }


        //SHOW
        [Authorize(Roles = "ADMIN, USER")]
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
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create()
        {
            FotoFormModel model = new FotoFormModel();
            model.Foto = new Foto();
            model.CreaCategorie();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create(FotoFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.CreaCategorie();
                return View("Create", data);
            }

            data.SetImmagine();
            FotoManger.InsertFoto(data.Foto, data.SelectCategorie);
            return RedirectToAction("Index");
        }


        //EDIT
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id)
        {
            var FotoDaModificare = FotoManger.GetFoto(id);

            if (FotoDaModificare == null)
            {
                return View("Errore");
            }
            else
            {
                FotoFormModel model = new FotoFormModel(FotoDaModificare);
                model.CreaCategorie();
                return View(model);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id, FotoFormModel data)
        {
            if(!ModelState.IsValid)
            {
                data.CreaCategorie();
                return View("Update", data);
            }

            data.SetImmagine();
            if (FotoManger.UpdateFoto(id, data.Foto.Titolo, data.Foto.Descrizione, data.Foto.Visibile, data.Foto.Immagine, data.SelectCategorie))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Errore");
            }
        }


        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            if (FotoManger.DeleteFoto(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Errore");
            }
        }
    }
}
