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
    public class VehicleRantalServiceController : Controller
    {
        VehicleRentalServices vehicleRentalServices = new VehicleRentalServices();
        VehicleRentalServiceRepository vehicleRentalServiceRepository = new VehicleRentalServiceRepository();
        RequestRentalDetailsRepository requestRentalDetailsRepository = new RequestRentalDetailsRepository();
        RateServices rateServices = new RateServices();
        // GET: rentalService
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddView()
        {
            return View();
        }

        public ActionResult SaveRentalService(HttpPostedFileBase imageFile, string data)
        {
            VehicleRentalService vehicleRentalService = JsonConvert.DeserializeObject<VehicleRentalService>(data);
            var objResult = vehicleRentalServices.SaveVehicleRentalService(imageFile, (int)Session["UserId"], vehicleRentalService);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadTableData()
        {
            var objResult = vehicleRentalServiceRepository.GetvehicleRentalServicesByIdList((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteRentalService(int rentalServiceID)
        {
            var objResult = vehicleRentalServiceRepository.GetVehicleRentalServiceById(rentalServiceID);
            objResult.IsActive = false;

            var objResult2 = vehicleRentalServiceRepository.UpdateVehicleRentalService(objResult.RentalServiceID, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadFieldsEdit(int rentalServiceID)
        {
            var objResult = vehicleRentalServiceRepository.GetVehicleRentalServiceById(rentalServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RentalServices()
        {
            return View();
        }

        public ActionResult GetRentalSerivces()
        {
            var objResult = vehicleRentalServiceRepository.GetVehicleRentalServiceList();

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRatings(int id)
        {
            var objResult = rateServices.GetRateFeedbackByRentProductId(id).Select(item => item.RatedValue).ToList().Average() != null ? rateServices.GetRateFeedbackByRentProductId(id).Select(item => item.RatedValue).ToList().Average() : 0;

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveRentalServiceRequest(RequestedRentalDetail requestedRentalDetail)
        {
            requestedRentalDetail.IsActive = true;
            requestedRentalDetail.RequesterId = (int)Session["UserId"];
            var objResult = requestRentalDetailsRepository.PostRequestedRentalDetail(requestedRentalDetail);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadFieldsModal(int RentalServiceID)
        {

            var objResult = vehicleRentalServiceRepository.GetVehicleRentalServiceById(RentalServiceID);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RequestedRentalServicesForRequester()
        {
            return View();
        }
        public ActionResult RequestedRentalServicesForOwner()
        {
            return View();
        }

        public ActionResult GetRequestedRentalServicesForRequester()
        {
            var objResult = vehicleRentalServices.GetRequestedRentalServicesForRequester((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRequestedRentalServicesForOwner()
        {
            var objResult = vehicleRentalServices.GetRequestedRentalServicesForOwner((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRateFeedbackByRentProductId(int productOrServiceId)
        {
            var objResult = rateServices.GetRateFeedbackByRentProductId(productOrServiceId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}