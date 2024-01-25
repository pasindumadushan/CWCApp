using CWCApp.Application.Services;
using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace CWCApp.Controllers
{

    [Route("api/[controller]")]
    public class GarageController : Controller
    {
        GarageServices garageServices = new GarageServices();
        GarageRepository garageRepository = new GarageRepository();
        // GET: Garage

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("SaveGarage")]
        public ActionResult SaveGarage(HttpPostedFileBase imageFile, string data)
        {
            Garage garage = JsonConvert.DeserializeObject<Garage>(data);
            var objResult = garageServices.SaveGarageService(imageFile, (int)Session["UserId"], garage);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LoadTableData")]
        public ActionResult LoadTableData()
        {
            var objResult = garageRepository.GetgaragesByIdList((int)Session["UserId"]);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("DeleteGarage/{garageId}")]
        public ActionResult DeleteGarage(int garageId)
        {
            var objResult = garageRepository.GetGarageById(garageId);
            objResult.IsActive = false;

            var objResult2 = garageRepository.UpdateGarage(objResult.GarageId, objResult);

            return Json(new { data = objResult2 }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("LoadFieldsEdit/{garageId}")]
        public ActionResult LoadFieldsEdit(int garageId)
        {
            var objResult = garageRepository.GetGarageById(garageId);

            return Json(new { data = objResult }, JsonRequestBehavior.AllowGet);
        }
    }
}