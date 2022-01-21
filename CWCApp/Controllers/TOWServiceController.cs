using CWCApp.Application.Services;
using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    public class TOWServiceController : Controller
    {
        TOWServiceRepository towServiceRepository = new TOWServiceRepository();
        RequestedTOWDetailsRepository requestedTOWDetailsRepository = new RequestedTOWDetailsRepository();
        GarageRepository garageRepository = new GarageRepository();
        TOWServices towServices = new TOWServices();
        RateServices rateServices = new RateServices();
        // GET: TOWService
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddView()
        {
            return View();
        }

        public ActionResult LoadGarages()
        {
            var objResult = garageRepository.GetgaragesByIdList((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTOWService(HttpPostedFileBase imageFile, string data)
        {

            TOWService towService = JsonConvert.DeserializeObject<TOWService>(data);
            var objResult = towServices.SaveTOWService(imageFile, (int)Session["UserId"], towService);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTOWServiceRequest(RequestedTOWDetail requestedTOWDetails)
        {
            requestedTOWDetails.IsActive = true;
            requestedTOWDetails.RequesterId = (int)Session["UserId"];
            var objResult = requestedTOWDetailsRepository.PostRequestedTOWDetail(requestedTOWDetails);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadTableData()
        {
            var objResult = towServices.GetTOWServicesById((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult TOWSerivces()
        {
            return View();
        }
        public ActionResult RequestedTOWServicesForRequester()
        {
            return View();
        }
        public ActionResult RequestedTOWServicesForOwner()
        {
            return View();
        }

        public ActionResult GetTOWSerivces()
        {
            var objResult = towServices.GetTOWServices();

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRequestedTOWServicesForRequester()
        {
            var objResult = towServices.GetRequestedTOWServicesForRequester((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetRequestedTOWServicesForOwner()
        {
            var objResult = towServices.GetRequestedTOWServicesForOwner((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadFieldsEdit(int TOWServiceID)
        {

            var objResult = towServiceRepository.GetTOWServiceById(TOWServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadFieldsModal(int TOWServiceID)
        {

            var objResult = towServices.GetTOWServicesDetails(TOWServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteTOWService(int TOWServiceID)
        {
            var objResult = towServiceRepository.GetTOWServiceById(TOWServiceID);
            objResult.IsActive = false;

            var objResult2 = towServiceRepository.UpdateTOWService(objResult.TOWServiceID, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRateFeedbackByTOWProductId(int productOrServiceId)
        {
            var objResult = rateServices.GetRateFeedbackByTOWProductId(productOrServiceId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}