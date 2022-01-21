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
    public class GarageController : Controller
    {
        GarageServices garageServices = new GarageServices();
        GarageRepository garageRepository = new GarageRepository();
        // GET: Garage
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddView()
        {
            return View();
        }

        public ActionResult SaveGarage(HttpPostedFileBase imageFile, string data)
        {
            Garage garage = JsonConvert.DeserializeObject<Garage>(data);
            var objResult = garageServices.SaveGarageService(imageFile, (int)Session["UserId"], garage);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadTableData()
        {
            var objResult = garageRepository.GetgaragesByIdList((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteGarage(int garageId)
        {
            var objResult = garageRepository.GetGarageById(garageId);
            objResult.IsActive = false;

            var objResult2 = garageRepository.UpdateGarage(objResult.GarageId, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadFieldsEdit(int garageId)
        {
            var objResult = garageRepository.GetGarageById(garageId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}