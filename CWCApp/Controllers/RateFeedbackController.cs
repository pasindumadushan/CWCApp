using CWCApp.Application.Services;
using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    public class RateFeedbackController : Controller
    {
        RateServices rateServices = new RateServices();
        ServiceFeedBackRepository serviceFeedBackRepository = new ServiceFeedBackRepository();
        // GET: RateFeedback
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRateFeedback()
        {
            var objResult = rateServices.GetRateFeedback((int)Session["UserId"]);
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveServiceFeedback(ServiceFeedBack serviceFeedBack)
        {
            serviceFeedBack.IsActive = true;
            var objResult = rateServices.SaveServiceFeedback(serviceFeedBack);
            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}