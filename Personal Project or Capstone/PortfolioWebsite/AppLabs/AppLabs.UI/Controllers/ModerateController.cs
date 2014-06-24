using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppLabs.BLL.Level3;
using AppLabs.BLL.Level4;
using AppLabs.BLL.Level5;
using AppLabs.DTOs.Level3;
using AppLabs.DTOs.Level4;
using AppLabs.DTOs.Level5;
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



        public ActionResult RomanNumeralInput()
        {
            var model = new RomanNumeralModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult RomanNumeralInput(RomanNumeralModel request)
        {
            if (ModelState.IsValid)
            {
                var romanConverter = new RomanNumeralConverter();
                var romanData = new RomanNumeralRequest();
                romanData.UserNumber = request.UserNumber;
                
                var result = romanConverter.ConvertNumber(romanData);
                return View("RomanNumeralOutput", result);

            }
            else
            {
                return View(request);
            }
        }



        public ActionResult MorseCodeInput()
        {
            var model = new MorseCodeModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult MorseCodeInput(MorseCodeModel request)
        {
            if (ModelState.IsValid)
            {
                var morseConverter = new MorseCodeConverter();
                var morseData = new MorseCodeRequest();
                morseData.UserInput = request.UserInput;

                var result = morseConverter.ConvertToMorse(morseData);
                return View("MorseCodeOutput", result);

            }
            else
            {
                return View(request);
            }
        }



        public ActionResult CipherInput()
        {
            var model = new CipherModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult CipherInput(CipherModel request)
        {
            if (ModelState.IsValid)
            {
                var cipherConverter = new CipherConverter();
                var cipherData = new CipherRequest();
                cipherData.UserInput = request.UserInput;

                var result = cipherConverter.EncryptWord(cipherData);
                return View("CipherOutput", result);

            }
            else
            {
                return View(request);
            }
        }


	}
}