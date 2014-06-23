using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppLabs.BLL.Level3;
using AppLabs.DTOs.Level3;
using AppLabs.UI.Models;

namespace AppLabs.UI.Controllers
{
    public class ModerateController : Controller
    {
        //
        // GET: /Moderate/
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult WordCounterInput()
        {
            var model = new WordCounterModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult WordCounterInput(WordCounterModel request)
        {
            if (ModelState.IsValid)
            {
                var wordFinder = new WordCounter();
                var wordData = new WordCounterRequest();
                wordData.UserInput = request.UserInput;
                

                var result = wordFinder.CountWords(wordData);
                return View("WordCounterOutput", result);

            }
            else
            {
                return View(request);
            }
        }


        public ActionResult CommonDenominatorInput()
        {
            var model = new CommonDenominatorModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult CommonDenominatorInput(CommonDenominatorModel request)
        {
            if (ModelState.IsValid)
            {
                var gcdFinder = new CommonDenominatorFinder();
                var gcdData = new CommonDenominatorRequest();
                gcdData.UserNumerator1 = request.UserNumerator1;
                gcdData.UserDenominator1 = request.UserDenominator1;
                gcdData.UserNumerator2 = request.UserNumerator2;
                gcdData.UserDenominator2 = request.UserDenominator2;


                var result = gcdFinder.FindDenominator(gcdData);
                return View("CommonDenominatorOutput", result);

            }
            else
            {
                return View(request);
            }
        }

	}
}