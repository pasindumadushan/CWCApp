using CWCApp.Application.Services;
using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{
    public class VehiclePartsStoreItemController : Controller
    {
        VehiclePartsStoreItemService vehiclePartsStoreItemService = new VehiclePartsStoreItemService();
        VehiclePartsStoreItemRepository vehiclePartsStoreItemRepository = new VehiclePartsStoreItemRepository();
        VehiclePartsStoreRepository vehiclePartsStoreRepository = new VehiclePartsStoreRepository();
        BoughtItemDetailsRepository boughtItemDetailsRepository = new BoughtItemDetailsRepository();
        RateServices rateServices = new RateServices();
        // GET: VehiclePartsStoreItem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadTableData()
        {
            var objResult = vehiclePartsStoreItemService.GetvehicleParts((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddView()
        {
            return View();
        }

        public ActionResult LoadStores()
        {
            var objResult = vehiclePartsStoreRepository.GetvehiclePartsStoresByIdList((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveVehiclePartsStoreItem(HttpPostedFileBase imageFile, string data)
        {

            VehiclePartsStoreItem vehiclePartsStoreItem = JsonConvert.DeserializeObject<VehiclePartsStoreItem>(data);
            var objResult = vehiclePartsStoreItemService.SaveVehiclePartsService(imageFile,(int)Session["UserId"], vehiclePartsStoreItem);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadFieldsEdit(int ItemId)
        {

            var objResult = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById(ItemId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteVehiclePartsStoreItem(int ItemId)
        {
            var objResult = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById(ItemId);
            objResult.IsActive = false;

            var objResult2 = vehiclePartsStoreItemRepository.UpdateVehiclePartsStoreItem(objResult.ItemId, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VehicleParts()
        {
            return View();
        }
        
        public ActionResult GetVehicleParts()
        {
            var objResult = vehiclePartsStoreItemService.GetVehicleParts();

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetVehiclePartDetails(int itemId)
        {
            var objResult = vehiclePartsStoreItemService.GetVehiclePartDetails(itemId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult BuyVehiclePartsStoreItem(BoughtItemDetail boughtItemDetail)
        {
            boughtItemDetail.BuyerId = (int)Session["UserId"];
            boughtItemDetail.IsActive = true;

            var objResult = boughtItemDetailsRepository.PostBoughtItemDetails(boughtItemDetail);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BoughtItems()
        {
            return View();
        }
        
        public ActionResult SoldItems()
        {
            return View();
        }

        public ActionResult LoadBoughtItems()
        {
            var objResult = vehiclePartsStoreItemService.GetBoughtItems((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadSoldItems()
        {
            var objResult = vehiclePartsStoreItemService.GetSoldItems((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRateFeedbackByStoreItemProductId(int productOrServiceId)
        {
            var objResult = rateServices.GetRateFeedbackByStoreItemProductId(productOrServiceId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}