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
    [Route("api/[controller]")]
    public class VehicleRepairServiceController : Controller
    {
        RepairServiceRepository repairServiceRepository = new RepairServiceRepository();
        RequestRepairDetailsRepository requestRepairDetailsRepository = new RequestRepairDetailsRepository();
        GarageRepository garageRepository = new GarageRepository();
        VehicleRepairService vehicleRepairService = new VehicleRepairService();
        RateServices rateServices = new RateServices();
        // GET: VehicleRepairService

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
        [Route("SaveRepairService/{data}")]
        public ActionResult SaveRepairService(string data)
        {

            RepairService repairService = JsonConvert.DeserializeObject<RepairService>(data);
            var objResult = vehicleRepairService.SaveRepairService((int)Session["UserId"], repairService);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LoadTableData")]
        public ActionResult LoadTableData()
        {
            var objResult = vehicleRepairService.GetRepairServicesById((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("LoadFieldsEdit/{RepairServiceID}")]
        public ActionResult LoadFieldsEdit(int RepairServiceID)
        {

            var objResult = repairServiceRepository.GetRepairServiceById(RepairServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("DeleteRepairService/{RepairServiceID}")]
        public ActionResult DeleteRepairService(int RepairServiceID)
        {
            var objResult = repairServiceRepository.GetRepairServiceById(RepairServiceID);
            objResult.IsActive = false;

            var objResult2 = repairServiceRepository.UpdateRepairService(objResult.RepairServiceID, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("RepairServices")]
        public ActionResult RepairServices()
        {
            return View();
        }

        [HttpPost]
        [Route("LoadFieldsModal/{RepairServiceID}")]
        public ActionResult LoadFieldsModal(int RepairServiceID)
        {

            var objResult = vehicleRepairService.GetRepairServicesDetails(RepairServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("SaveRepairServiceRequest/{requestedRepairDetail}")]
        public ActionResult SaveRepairServiceRequest(RequestedRepairDetail requestedRepairDetail)
        {
            requestedRepairDetail.IsActive = true;
            requestedRepairDetail.RequesterId = (int)Session["UserId"];
            var objResult = requestRepairDetailsRepository.PostRequestedRepairDetail(requestedRepairDetail);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetRepairSerivces")]
        public ActionResult GetRepairSerivces()
        {
            var objResult = vehicleRepairService.GetRepairServices();

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("GetGarageById/{id}")]
        public ActionResult GetGarageById(int id)
        {
            var objResult = garageRepository.GetGarageById(id);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("RequestedRepairServicesForRequester")]
        public ActionResult RequestedRepairServicesForRequester()
        {
            return View();
        }

        [HttpGet]
        [Route("RequestedRepairServicesForOwner")]
        public ActionResult RequestedRepairServicesForOwner()
        {
            return View();
        }

        [HttpGet]
        [Route("GetRequestedRepairServicesForRequester")]
        public ActionResult GetRequestedRepairServicesForRequester()
        {
            var objResult = vehicleRepairService.GetRequestedRepairServicesForRequester((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetRequestedRepairServicesForOwner")]
        public ActionResult GetRequestedRepairServicesForOwner()
        {
            var objResult = vehicleRepairService.GetRequestedRepairServicesForOwner((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("GetRateFeedbackByRepairProductId/{productOrServiceId}")]
        public ActionResult GetRateFeedbackByRepairProductId(int productOrServiceId)
        {
            var objResult = rateServices.GetRateFeedbackByRepairProductId(productOrServiceId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}