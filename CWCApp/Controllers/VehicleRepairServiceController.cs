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
    public class VehicleRepairServiceController : Controller
    {
        RepairServiceRepository repairServiceRepository = new RepairServiceRepository();
        RequestRepairDetailsRepository requestRepairDetailsRepository = new RequestRepairDetailsRepository();
        GarageRepository garageRepository = new GarageRepository();
        VehicleRepairService vehicleRepairService = new VehicleRepairService();
        RateServices rateServices = new RateServices();
        // GET: VehicleRepairService
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

        public ActionResult SaveRepairService(string data)
        {

            RepairService repairService = JsonConvert.DeserializeObject<RepairService>(data);
            var objResult = vehicleRepairService.SaveRepairService((int)Session["UserId"], repairService);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadTableData()
        {
            var objResult = vehicleRepairService.GetRepairServicesById((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadFieldsEdit(int RepairServiceID)
        {

            var objResult = repairServiceRepository.GetRepairServiceById(RepairServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteRepairService(int RepairServiceID)
        {
            var objResult = repairServiceRepository.GetRepairServiceById(RepairServiceID);
            objResult.IsActive = false;

            var objResult2 = repairServiceRepository.UpdateRepairService(objResult.RepairServiceID, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RepairServices()
        {
            return View();
        }

        public ActionResult LoadFieldsModal(int RepairServiceID)
        {

            var objResult = vehicleRepairService.GetRepairServicesDetails(RepairServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveRepairServiceRequest(RequestedRepairDetail requestedRepairDetail)
        {
            requestedRepairDetail.IsActive = true;
            requestedRepairDetail.RequesterId = (int)Session["UserId"];
            var objResult = requestRepairDetailsRepository.PostRequestedRepairDetail(requestedRepairDetail);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRepairSerivces()
        {
            var objResult = vehicleRepairService.GetRepairServices();

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGarageById(int id)
        {
            var objResult = garageRepository.GetGarageById(id);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RequestedRepairServicesForRequester()
        {
            return View();
        }
        public ActionResult RequestedRepairServicesForOwner()
        {
            return View();
        }

        public ActionResult GetRequestedRepairServicesForRequester()
        {
            var objResult = vehicleRepairService.GetRequestedRepairServicesForRequester((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRequestedRepairServicesForOwner()
        {
            var objResult = vehicleRepairService.GetRequestedRepairServicesForOwner((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRateFeedbackByRepairProductId(int productOrServiceId)
        {
            var objResult = rateServices.GetRateFeedbackByRepairProductId(productOrServiceId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}