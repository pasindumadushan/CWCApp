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
    [Route("api/[conroller]")]
    public class TOWServiceController : Controller
    {
        TOWServiceRepository towServiceRepository = new TOWServiceRepository();
        RequestedTOWDetailsRepository requestedTOWDetailsRepository = new RequestedTOWDetailsRepository();
        GarageRepository garageRepository = new GarageRepository();
        TOWServices towServices = new TOWServices();
        RateServices rateServices = new RateServices();
        // GET: TOWService

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("AddView")]
        public ActionResult AddView()
        {
            return View();
        }

        [HttpGet]
        [Route("LoadGarages")]
        public ActionResult LoadGarages()
        {
            var objResult = garageRepository.GetgaragesByIdList((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Route("SaveTOWService")]
        public ActionResult SaveTOWService(HttpPostedFileBase imageFile, string data)
        {

            TOWService towService = JsonConvert.DeserializeObject<TOWService>(data);
            var objResult = towServices.SaveTOWService(imageFile, (int)Session["UserId"], towService);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("SaveTOWServiceRequest")]
        public ActionResult SaveTOWServiceRequest(RequestedTOWDetail requestedTOWDetails)
        {
            requestedTOWDetails.IsActive = true;
            requestedTOWDetails.RequesterId = (int)Session["UserId"];
            var objResult = requestedTOWDetailsRepository.PostRequestedTOWDetail(requestedTOWDetails);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LoadTableData")]
        public ActionResult LoadTableData()
        {
            var objResult = towServices.GetTOWServicesById((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("TOWSerivces")]
        public ActionResult TOWSerivces()
        {
            return View();
        }

        [HttpGet]
        [Route("RequestedTOWServicesForRequester")]
        public ActionResult RequestedTOWServicesForRequester()
        {
            return View();
        }

        [HttpGet]
        [Route("RequestedTOWServicesForOwner")]
        public ActionResult RequestedTOWServicesForOwner()
        {
            return View();
        }


        [HttpGet]
        [Route("GetTOWSerivces")]
        public ActionResult GetTOWSerivces()
        {
            var objResult = towServices.GetTOWServices();

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetRequestedTOWServicesForRequester")]
        public ActionResult GetRequestedTOWServicesForRequester()
        {
            var objResult = towServices.GetRequestedTOWServicesForRequester((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetRequestedTOWServicesForOwner")]
        public ActionResult GetRequestedTOWServicesForOwner()
        {
            var objResult = towServices.GetRequestedTOWServicesForOwner((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("LoadFieldsEdit/{TOWServiceID}")]
        public ActionResult LoadFieldsEdit(int TOWServiceID)
        {

            var objResult = towServiceRepository.GetTOWServiceById(TOWServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Route("LoadFieldsModal/{TOWServiceID}")]
        public ActionResult LoadFieldsModal(int TOWServiceID)
        {

            var objResult = towServices.GetTOWServicesDetails(TOWServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("DeleteTOWService/{TOWServiceID}")]
        public ActionResult DeleteTOWService(int TOWServiceID)
        {
            var objResult = towServiceRepository.GetTOWServiceById(TOWServiceID);
            objResult.IsActive = false;

            var objResult2 = towServiceRepository.UpdateTOWService(objResult.TOWServiceID, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [Route("GetRateFeedbackByTOWProductId/{productOrServiceId}")]
        public ActionResult GetRateFeedbackByTOWProductId(int productOrServiceId)
        {
            var objResult = rateServices.GetRateFeedbackByTOWProductId(productOrServiceId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}