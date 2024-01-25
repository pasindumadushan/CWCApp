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
    [Route("api/[controller]")]
    public class VehiclePartsStoreController : Controller
    {
        ShoppingMethodMstrRepository shoppingMethodMstrRepository = new ShoppingMethodMstrRepository();
        VehiclePartsStoreService VehiclePartsStoreService = new VehiclePartsStoreService();
        VehiclePartsStoreRepository vehiclePartsStoreRepository = new VehiclePartsStoreRepository();
        // GET: VehiclePartsStore

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
        [Route("LoadShoppingMethods")]
        public ActionResult LoadShoppingMethods()
        {
            var objResult = shoppingMethodMstrRepository.GetShoppingMethodMstrList();

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LoadTableData")]
        public ActionResult LoadTableData()
        {
            var objResult = VehiclePartsStoreService.GetvehiclePartsStoresByIdList((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("SaveVehiclePartsStore")]
        public ActionResult SaveVehiclePartsStore(VehiclePartsStore vehiclePartsStore)
        {
            var objResult = VehiclePartsStoreService.SaveVehiclePartsService((int)Session["UserId"], vehiclePartsStore);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("DeleteVehiclePartsStore/{storeId}")]
        public ActionResult DeleteVehiclePartsStore(int storeId)
        {
            var objResult = vehiclePartsStoreRepository.GetVehiclePartsStoreById(storeId);
            objResult.IsActive = false;

            var objResult2 = vehiclePartsStoreRepository.UpdateVehiclePartsStore(objResult.StoreId, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LoadFieldsEdit/{storeId}")]
        public ActionResult LoadFieldsEdit(int storeId)
        {
            var objResult = vehiclePartsStoreRepository.GetVehiclePartsStoreById(storeId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}