using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppLabs.BLL.Level1;
using AppLabs.BLL.Level2;
using AppLabs.DTOs.Level1;
using AppLabs.DTOs.Level2;
using AppLabs.UI.Models;
using Microsoft.Ajax.Utilities;


namespace AppLabs.UI.Controllers
{
    public class SimpleController : Controller
    {
        //
        // GET: /Simple/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FloorCalculatorInput()
        {
            var model = new FloorCalculatorModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult FloorCalculatorInput(FloorCalculatorModel request)
        {
            if (ModelState.IsValid)
            {
                var floorCalc = new FloorCalculator();
                var floorData = new FloorCalculatorRequest();
                floorData.Length = request.Length.Value;
                floorData.Width = request.Width.Value;
                floorData.UnitCost = request.UnitCost.Value;

                var result = floorCalc.CalculateFloorCost(floorData);
                return View("FloorCalculatorOutput", result);

            }
            else
            {
                return View(request);
            }
        }

        public ActionResult TipCalculatorInput()
        {
            var model = new TipCalculatorModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult TipCalculatorInput(TipCalculatorModel request)
        {
            if (ModelState.IsValid)
            {
                var tipCalc = new TipCalculator();
                var tipData = new TipCalculatorRequest();
                tipData.MealTotal = request.MealTotal.Value;
                tipData.TipPercent = request.TipPercent.Value;

                var result = tipCalc.CalculateTip(tipData);
                return View("TipCalculatorOutput", result);
            }
            else
            {
                return View(request);
            }
        }

        public ActionResult LeapYearInput()
        {
            var model = new LeapYearCalculatorModel();
            return View(model);

        }


        [HttpPost]
        public ActionResult LeapYearInput(LeapYearCalculatorModel request)
        {
            if (ModelState.IsValid)
            {
                var leapCalc = new LeapYearCalculator();
                var leapData = new LeapYearRequest();
                leapData.StartYear = request.StartYear.Value;
                leapData.EndYear = request.EndYear.Value;

                var result = leapCalc.FindLeapYear(leapData);
                return View("LeapYearOutput", result);
            }
            else
            {
                return View(request);
            }
        }

        public ActionResult StringReverserInput()
        {
            var model = new StringReverserModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult StringReverserInput(StringReverserModel request)
        {
            if (ModelState.IsValid)
            {
                var stringFind = new StringReverser();
                var stringData = new StringReverseRequest();
                stringData.String = request.String;
                

                var result = stringFind.FindReverseString(stringData);
                return View("StringReverserOutput", result);

            }
            else
            {
                return View(request);
            }
        }



        public ActionResult VowelCounterInput()
        {
            var model = new VowelCounterModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult VowelCounterInput(VowelCounterModel request)
        {
            if (ModelState.IsValid)
            {
                var vowelFind = new VowelCounterCalculator();
                var vowelData = new VowelCounterRequest();
                vowelData.Word = request.Word;


                var result = vowelFind.FindVowels(vowelData);
                return View("VowelCounterOutput", result);

            }
            else
            {
                return View(request);
            }
        }



        public ActionResult PalindromeInput()
        {
            var model = new PalidromeFinderModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult PalindromeInput(PalidromeFinderModel request)
        {
            if (ModelState.IsValid)
            {
                var palinFind = new PalindromeCalculator();
                var palinData = new PalindromFinderRequest();
                palinData.Word = request.Word;


                var result = palinFind.FindPalindrome(palinData);
                return View("PalindromeOutput", result);

            }
            else
            {
                return View(request);
            }
        }

        public ActionResult ChangeReturnInput()
        {
            var model = new ChangeReturnModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult ChangeReturnInput(ChangeReturnModel request)
        {
            if (ModelState.IsValid)
            {
                var changeFind = new ChangeReturnCalculator();
                var changeData = new ChangeReturnRequest();
                changeData.UserCash = request.UserCash;
                changeData.ItemCost = (decimal) (request.ItemCost);


                var result = changeFind.CalculateChange(changeData);
                return View("ChangeReturnOutput", result);

            }
            else
            {
                return View(request);
            }
        }


        public ActionResult FibonacciInput()
        {
            var model = new FibonacciModel();
            return View(model);

        }

        [HttpPost]
        public ActionResult FibonacciInput(FibonacciModel request)
        {
            if (ModelState.IsValid)
            {
                var fibCalc = new FibonacciCalculator();
                var fibData = new FibonacciListerRequest();
                fibData.givenNumber = request.givenNumber;
                

                var result = fibCalc.FibonacciLister(fibData);
                return View("FibonacciOutput", result);

            }
            else
            {
                return View(request);
            }
        }





    }
}