using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.Web.Models;
using DVDLibrary.DTOs.Interfaces;

namespace DVDLibrary.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IDVDRepository _repository;


        public HomeController(IDVDRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            var model = new SearchDVDRequest();//You need to instantiate in the home controller since your search function is on your home index page
            model.SearchResults= _repository.GetAllDvds();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchDVDRequest model)
        {
            if (string.IsNullOrWhiteSpace(model.SearchActor) && string.IsNullOrWhiteSpace(model.SearchTitle) &&
                string.IsNullOrWhiteSpace(model.SearchDirector))
            {
                ModelState.AddModelError("", "You must fill in at least one search field");
                model.SearchResults = _repository.GetAllDvds();

                return View(model);
            }

            model.SearchResults = _repository.Search(model.SearchDirector, model.SearchTitle, model.SearchActor);

            return View(model);
        }

	}
}

