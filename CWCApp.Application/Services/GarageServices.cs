using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CWCApp.Application.Services
{
    public class GarageServices
    {
        GarageRepository garageRepository = new GarageRepository();
        ServiceProviderProfileRepository serviceProviderProfileRepository = new ServiceProviderProfileRepository();
        public Garage SaveGarageService(HttpPostedFileBase imageFile, int userId, Garage garage)
        {
            var objResult1 = serviceProviderProfileRepository.GetServiceProviderProfileByUserId(userId);
            Garage objResult = null;

            if (garage.GarageId <= 0)
            {
                garage.UserId = userId;
                garage.IsActive = true;
                garage.ServiceId = objResult1.ServiceId;
                objResult = garageRepository.PostGarage(garage);
            }
            else
            {
                objResult = garageRepository.GetGarageById(garage.GarageId);
                objResult.GarageId = garage.GarageId;
                objResult.GarageName = garage.GarageName;
                objResult.AddressOfGarage = garage.AddressOfGarage;
                objResult.City = garage.City;
                objResult.State = garage.State;
                objResult.VehicleCapacity = garage.VehicleCapacity;
                objResult.TOWCapability = garage.TOWCapability;
                objResult.TOWPayload = garage.TOWPayload;
                objResult.NumberOfMechanics = garage.NumberOfMechanics;
                objResult.RangeOfService = garage.RangeOfService;
                objResult.ExtraFeatures = garage.ExtraFeatures;
                objResult.Rates = garage.Rates;
                objResult = garageRepository.UpdateGarage(objResult.GarageId, objResult);
            }


            if (imageFile != null)
            {
                string extension = Path.GetExtension(imageFile.FileName);
                var fileName = "GaragePhotos-" + objResult.GarageId + extension;
                objResult.PictureOfGarage = "/Images/GaragePhotos/" + fileName;

                imageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/GaragePhotos/" + fileName));

                objResult = garageRepository.UpdateGarage(objResult.GarageId, objResult);
            }

            return objResult;
        }
    }
}
