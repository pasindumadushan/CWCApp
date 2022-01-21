using CWCApp.Data.Data;
using CWCApp.Data.Repository;
using CWCApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CWCApp.Application.Services
{
    
    public class TOWServices
    {
        TOWServiceRepository towServiceRepository = new TOWServiceRepository();
        GarageRepository garageRepository = new GarageRepository();
        RequestedTOWDetailsRepository requestedTOWDetailsRepository = new RequestedTOWDetailsRepository();
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        RateServices rateServices = new RateServices();
        public TOWService SaveTOWService(HttpPostedFileBase imageFile, int userId, TOWService towService)
        {

            TOWService objResult = null;

            if (towService.TOWServiceID <= 0)
            {
                towService.UserId = userId;
                towService.IsActive = true;
                objResult = towServiceRepository.PostTOWService(towService);
            }
            else
            {
                objResult = towServiceRepository.GetTOWServiceById(towService.TOWServiceID);
                objResult.GarageId = towService.GarageId;
                objResult.TypeOfVehicleOwn = towService.TypeOfVehicleOwn;
                objResult.MaxPayLoad = towService.MaxPayLoad;
                objResult.NoOfVehicleOwn = towService.NoOfVehicleOwn;
                objResult.RatePerKm = towService.RatePerKm;
                objResult.RangeOfService = towService.RangeOfService;
                objResult.ExtraFeatures = towService.ExtraFeatures;
                objResult = towServiceRepository.UpdateTOWService(objResult.TOWServiceID, objResult);
            }


            if (imageFile != null)
            {
                string extension = Path.GetExtension(imageFile.FileName);
                var fileName = "TOWVehiclePhoto-" + objResult.TOWServiceID + extension;
                objResult.VehicleImage = "/Images/TOWVehiclePhoto/" + fileName;

                imageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/TOWVehiclePhoto/" + fileName));

                objResult = towServiceRepository.UpdateTOWService(objResult.TOWServiceID, objResult);
            }

            return objResult;
        }

        public List<TOWServiceViewModel> GetTOWServicesById(int userId)
        {
            var objResult = towServiceRepository.GettowServicesByIdList(userId);

            List<TOWServiceViewModel> towServiceViewModel = new List<TOWServiceViewModel>();

            foreach (var i in objResult)
            {
                towServiceViewModel.Add(new TOWServiceViewModel
                {
                    TOWServiceID = i.TOWServiceID,
                    GarageId = i.GarageId,
                    GarageName = garageRepository.GetGarageById((int)i.GarageId).GarageName,
                    NoOfVehicleOwn = i.NoOfVehicleOwn,
                    TypeOfVehicleOwn = i.TypeOfVehicleOwn,
                    MaxPayLoad = i.MaxPayLoad,
                    RatePerKm = i.RatePerKm,
                    RangeOfService = i.RangeOfService,
                    ExtraFeatures = i.ExtraFeatures,
                    VehicleImage = i.VehicleImage,
                });
            }

            return towServiceViewModel;
        }

        public List<TOWServiceViewModel> GetTOWServices()
        {
            var objResult = towServiceRepository.GetTOWServiceList();

            List<TOWServiceViewModel> towServiceViewModel = new List<TOWServiceViewModel>();

            foreach (var i in objResult)
            {
                towServiceViewModel.Add(new TOWServiceViewModel
                {
                    TOWServiceID = i.TOWServiceID,
                    GarageId = i.GarageId,
                    GarageName = garageRepository.GetGarageById((int)i.GarageId).GarageName,
                    NoOfVehicleOwn = i.NoOfVehicleOwn,
                    TypeOfVehicleOwn = i.TypeOfVehicleOwn,
                    MaxPayLoad = i.MaxPayLoad,
                    RatePerKm = i.RatePerKm,
                    RangeOfService = i.RangeOfService,
                    ExtraFeatures = i.ExtraFeatures,
                    AvgRate = rateServices.GetRateFeedbackByTOWProductId(i.TOWServiceID).Select(item => item.RatedValue).ToList().Average() != null ? rateServices.GetRateFeedbackByTOWProductId(i.TOWServiceID).Select(item => item.RatedValue).ToList().Average() : 0,
                    VehicleImage = i.VehicleImage,
                });
            }

            return towServiceViewModel;
        }
        
        public TOWServiceViewModel GetTOWServicesDetails(int TOWServiceID)
        {
            var objResult = towServiceRepository.GetTOWServiceById(TOWServiceID);
            var garageName = garageRepository.GetGarageById((int)objResult.GarageId).GarageName;
            var shopOwnerId = garageRepository.GetGarageById((int)objResult.GarageId).UserId;
            TOWServiceViewModel towServiceViewModel = new TOWServiceViewModel();

            towServiceViewModel.TOWServiceID = objResult.TOWServiceID;
            towServiceViewModel.GarageId = objResult.GarageId;
            towServiceViewModel.GarageName = garageName;
            towServiceViewModel.ShopOwnerId = shopOwnerId;
            towServiceViewModel.NoOfVehicleOwn = objResult.NoOfVehicleOwn;
            towServiceViewModel.TypeOfVehicleOwn = objResult.TypeOfVehicleOwn;
            towServiceViewModel.MaxPayLoad = objResult.MaxPayLoad;
            towServiceViewModel.RatePerKm = objResult.RatePerKm;
            towServiceViewModel.RangeOfService = objResult.RangeOfService;
            towServiceViewModel.ExtraFeatures = objResult.ExtraFeatures;
            towServiceViewModel.VehicleImage = objResult.VehicleImage;

            return towServiceViewModel;
        }

        public List<RequestedTOWServiceViewModel> GetRequestedTOWServicesForRequester(int userId)
        {
            List<RequestedTOWServiceViewModel> requestedTOWServiceViewModel = new List<RequestedTOWServiceViewModel>();
            var objResult = requestedTOWDetailsRepository.GetRequestedTOWDetailsByRequesterIdList(userId);

            foreach (var i in objResult)
            {
                var garageId = towServiceRepository.GetTOWServiceById((int)i.TOWServiceID).GarageId;
                var garageName = garageRepository.GetGarageById((int)garageId).GarageName;
                var shopOwnerName = userProfileRepository.GetUserProfileById((int)i.ShopOwnerId).UserName;
                var requesterName = userProfileRepository.GetUserProfileById((int)i.RequesterId).UserName;
                var vehicleImage = towServiceRepository.GetTOWServiceById((int)i.TOWServiceID).VehicleImage;
                var typeOfVehicle = towServiceRepository.GetTOWServiceById((int)i.TOWServiceID).TypeOfVehicleOwn;

                requestedTOWServiceViewModel.Add(new RequestedTOWServiceViewModel
                {
                    DetailId = i.DetailId,
                    TOWServiceID = i.TOWServiceID,
                    GarageName = garageName,
                    ShopOwnerId = i.ShopOwnerId,
                    ShopOwnerName = shopOwnerName,
                    RequesterId = i.RequesterId,
                    RequesterName = requesterName,
                    ReqestedCity = i.ReqestedCity,
                    ContactNo = i.ContactNo,
                    VehicleImage = vehicleImage,
                    TypeOfVehicle = typeOfVehicle,
                    ApproximateKMs = i.ApproximateKMs,
                    TotalCost = i.TotalCost,
                    IsActive = i.IsActive
                });
            }
            return requestedTOWServiceViewModel;
        }
        
        public List<RequestedTOWServiceViewModel> GetRequestedTOWServicesForOwner(int userId)
        {
            List<RequestedTOWServiceViewModel> requestedTOWServiceViewModel = new List<RequestedTOWServiceViewModel>();
            var objResult = requestedTOWDetailsRepository.GetRequestedTOWDetailsByShopOwnerIdList(userId);

            foreach (var i in objResult)
            {
                var garageId = towServiceRepository.GetTOWServiceById((int)i.TOWServiceID).GarageId;
                var garageName = garageRepository.GetGarageById((int)garageId).GarageName;
                var shopOwnerName = userProfileRepository.GetUserProfileById((int)i.ShopOwnerId).UserName;
                var requesterName = userProfileRepository.GetUserProfileById((int)i.RequesterId).UserName;
                var vehicleImage = towServiceRepository.GetTOWServiceById((int)i.TOWServiceID).VehicleImage;
                var typeOfVehicle = towServiceRepository.GetTOWServiceById((int)i.TOWServiceID).TypeOfVehicleOwn;

                requestedTOWServiceViewModel.Add(new RequestedTOWServiceViewModel
                {
                    DetailId = i.DetailId,
                    TOWServiceID = i.TOWServiceID,
                    GarageName = garageName,
                    ShopOwnerId = i.ShopOwnerId,
                    ShopOwnerName = shopOwnerName,
                    RequesterId = i.RequesterId,
                    RequesterName = requesterName,
                    ReqestedCity = i.ReqestedCity,
                    ContactNo = i.ContactNo,
                    VehicleImage = vehicleImage,
                    TypeOfVehicle = typeOfVehicle,
                    ApproximateKMs = i.ApproximateKMs,
                    TotalCost = i.TotalCost,
                    IsActive = i.IsActive
                });
            }
            return requestedTOWServiceViewModel;
        }

    }


}
