using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMetrics.Models;

namespace HRMetrics.Controllers
{
    public class TipController : Controller
    {
        //
        // GET: /Tip/
        public ActionResult Index()
        {
            var model = new TipCaculator();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TipCaculator model)
        {
            model.Tip = model.MealTotal*(model.TipPercent/100);
            model.TotalCost = model.Tip + model.MealTotal;

            return View(model);
        }
	}
}