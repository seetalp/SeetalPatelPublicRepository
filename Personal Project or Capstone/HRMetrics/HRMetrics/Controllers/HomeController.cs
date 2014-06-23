using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMetrics.Models;




namespace HRMetrics.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TotalTurnoverForm()
        {
            var model = new TurnoverRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult TotalTurnoverForm(TurnoverRequest request)
        {
            var model = new TurnoverResponse();
            model.StartHeadcount = request.StartHeadcount;
            model.EndHeadcount = request.EndHeadcount;
            model.TotalTerminations = request.TotalTerminations;
            model.AverageHeadcount = (model.StartHeadcount + model.EndHeadcount)/2;
            model.TotalTurnover = (model.TotalTerminations/model.AverageHeadcount)*100;

            return View("TotalTurnoverResult", model);
        }

        public ActionResult VolTurnoverForm()
        {
            var model = new TurnoverRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult VolTurnoverForm(TurnoverRequest request)
        {
            var model = new TurnoverResponse();
            model.StartHeadcount = request.StartHeadcount;
            model.EndHeadcount = request.EndHeadcount;
            model.VoluntaryTerminations = request.VoluntaryTerminations;
            model.AverageHeadcount = (model.StartHeadcount + model.EndHeadcount) / 2;
            model.VoluntaryTurnover = (model.VoluntaryTerminations / model.AverageHeadcount) * 100;//Format it to be ##.##%
            return View("VolTurnoverResult", model);
        }

        public ActionResult RegretTurnoverForm()
        {
            var model = new TurnoverRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult RegretTurnoverForm(TurnoverRequest request)
        {
            var model = new TurnoverResponse();
            model.StartHeadcount = request.StartHeadcount;
            model.EndHeadcount = request.EndHeadcount;
            model.VolunataryRegrettableTerminations = request.VolunataryRegrettableTerminations;
            model.AverageHeadcount = (model.StartHeadcount + model.EndHeadcount) / 2;
            model.RegrettableTurnover = (model.VolunataryRegrettableTerminations / model.AverageHeadcount) * 100;

            return View("RegretTurnoverResult", model);
        }

        public ActionResult OneYrRetentionForm()
        {
            var model = new RetentionRequest();
            return View(model);
        }

        [HttpPost]
        public ActionResult OneYrRetentionForm(RetentionRequest request)
        {
            var model = new RetentionResponse();
            model.OneYearTenureHeadcount = request.OneYearTenureHeadcount;
            model.TotalHeadcount = request.TotalHeadcount;
            model.RetentionPercentage = (model.OneYearTenureHeadcount / model.TotalHeadcount);
            
            return View("OneYrRetentionResult", model );
        }


    }
}