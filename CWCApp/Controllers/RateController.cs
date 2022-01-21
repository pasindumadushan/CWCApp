using CWCApp.Application.Services;
using CWCApp.Data.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    public class RateController : Controller
    {
        RateServices rateServices = new RateServices();
        // GET: Rate
        public ActionResult SetRateTOW(string rateData, string feedBackData)
        {
            Rate rate = JsonConvert.DeserializeObject<Rate>(rateData);
            string feedBack = JsonConvert.DeserializeObject<string>(feedBackData);

            rate.RatedUserId = (int)Session["UserId"];
            rate.IsActive = true;
            var objResult = rateServices.SetRateTOW(rate, feedBack);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetRateRepair(string rateData, string feedBackData)
        {
            Rate rate = JsonConvert.DeserializeObject<Rate>(rateData);
            string feedBack = JsonConvert.DeserializeObject<string>(feedBackData);

            rate.RatedUserId = (int)Session["UserId"];
            rate.IsActive = true;
            var objResult = rateServices.SetRateRepair(rate, feedBack);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetRateRent(string rateData, string feedBackData)
        {
            Rate rate = JsonConvert.DeserializeObject<Rate>(rateData);
            string feedBack = JsonConvert.DeserializeObject<string>(feedBackData);

            rate.RatedUserId = (int)Session["UserId"];
            rate.IsActive = true;
            var objResult = rateServices.SetRateRent(rate, feedBack);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetRateStoreItem(string rateData, string feedBackData)
        {
            Rate rate = JsonConvert.DeserializeObject<Rate>(rateData);
            string feedBack = JsonConvert.DeserializeObject<string>(feedBackData);

            rate.RatedUserId = (int)Session["UserId"];
            rate.IsActive = true;
            var objResult = rateServices.SetRateStoreItem(rate, feedBack);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

    }
}