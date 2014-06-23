using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.DTOs;
using DVDLibrary.DTOs.Interfaces;
using DVDLibrary.Web.Models;


namespace DVDLibrary.Web.Controllers
{
    public class DVDController : Controller
    {

        private readonly IDVDRepository _repository;

        public DVDController(IDVDRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Add()
        {
            var model = new AddDVDRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddDVDRequest model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(model.CreateDVD());
                TempData["Message"] = "You just added a new DVD to your library!";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var dvd = _repository.GetbyID(id);
            var model = new EditDVDRequest(dvd);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditDVDRequest model)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(model.CreateDvd());
                TempData["Message"] = "DVD details have been changed!";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {

            _repository.Delete(id);
            TempData["Message"] = "The DVD has been deleted from your library!";
            return RedirectToAction("Index", "Home", new{id});
        }



        public ActionResult Details(int id)
        {
            var model = _repository.GetbyID(id);

            return View(model);
        }

    }
}