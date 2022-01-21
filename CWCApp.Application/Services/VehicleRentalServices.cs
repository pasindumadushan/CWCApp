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
    public class VehicleRentalServices
    {
        VehicleRentalServiceRepository vehicleRentalServiceRepository = new VehicleRentalServiceRepository();
        ServiceProviderProfileRepository serviceProviderProfileRepository = new ServiceProviderProfileRepository();
        RequestRentalDetailsRepository requestRentalDetailsRepository = new RequestRentalDetailsRepository();
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        public VehicleRentalService SaveVehicleRentalService(HttpPostedFileBase imageFile, int userId, VehicleRentalService vehicleRentalService)
        {
            var objResult1 = serviceProviderProfileRepository.GetServiceProviderProfileByUserId(userId);
            VehicleRentalService objResult = null;

            if (vehicleRentalService.RentalServiceID <= 0)
            {
                vehicleRentalService.UserId = userId;
                vehicleRentalService.IsActive = true;
                vehicleRentalService.ServiceId = objResult1.ServiceId;
                objResult = vehicleRentalServiceRepository.PostVehicleRentalService(vehicleRentalService);
            }
            else
            {
                objResult = vehicleRentalServiceRepository.GetVehicleRentalServiceById(vehicleRentalService.RentalServiceID);
                objResult.RentalServiceID = vehicleRentalService.RentalServiceID;
                objResult.RantalServiceName = vehicleRentalService.RantalServiceName;
                objResult.TypeOfVehicleOwn = vehicleRentalService.TypeOfVehicleOwn;
                objResult.NoOfVehicleOwn = vehicleRentalService.NoOfVehicleOwn;
                objResult.RatePreKM = vehicleRentalService.RatePreKM;
                objResult.RangeOfService = vehicleRentalService.RangeOfService;
                objResult.ExtraFeatures = vehicleRentalService.ExtraFeatures;
                objResult = vehicleRentalServiceRepository.UpdateVehicleRentalService(objResult.RentalServiceID, objResult);
            }


            if (imageFile != null)
            {
                string extension = Path.GetExtension(imageFile.FileName);
                var fileName = "VehicleRentPhotos-" + objResult.RentalServiceID + extension;
                objResult.VehicleImage = "/Images/VehicleRentPhotos/" + fileName;

                imageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/VehicleRentPhotos/" + fileName));

                objResult = vehicleRentalServiceRepository.UpdateVehicleRentalService(objResult.RentalServiceID, objResult);
            }

            return objResult;
        }

        public List<RequestedRentalServiceViewModel> GetRequestedRentalServicesForRequester(int userId)
        {
            List<RequestedRentalServiceViewModel> requestedRentalServiceViewModel = new List<RequestedRentalServiceViewModel>();
            var objResult = requestRentalDetailsRepository.GetRequestedRentalDetailsByRequesterIdList(userId);

            foreach (var i in objResult)
            {
                var shopOwnerName = userProfileRepository.GetUserProfileById((int)i.ShopOwnerId).UserName;
                var requesterName = userProfileRepository.GetUserProfileById((int)i.RequesterId).UserName;
                var RentalServiceName = vehicleRentalServiceRepository.GetVehicleRentalServiceById((int)i.RentalServiceID).RantalServiceName;
                var TypeOfVehicleOwn = vehicleRentalServiceRepository.GetVehicleRentalServiceById((int)i.RentalServiceID).TypeOfVehicleOwn;

                requestedRentalServiceViewModel.Add(new RequestedRentalServiceViewModel
                {
                    DetailId = i.DetailId,
                    RentalServiceID = i.RentalServiceID,
                    RantalServiceName = RentalServiceName,
                    TypeOfVehicleOwn = TypeOfVehicleOwn,
                    ShopOwnerId = i.ShopOwnerId,
                    ShopOwnerName = shopOwnerName,
                    RequesterId = i.RequesterId,
                    RequesterName = requesterName,
                    RequestedCity = i.RequestedCity,
                    ContactNo = i.ContactNo,
                    RatePerKM = i.RatePerKM,
                    IsActive = i.IsActive
                });
            }
            return requestedRentalServiceViewModel;
        }

        public List<RequestedRentalServiceViewModel> GetRequestedRentalServicesForOwner(int userId)
        {
            List<RequestedRentalServiceViewModel> requestedRentalServiceViewModel = new List<RequestedRentalServiceViewModel>();
            var objResult = requestRentalDetailsRepository.GetRequestedRentalDetailsByShopOwnerIdList(userId);
            

            foreach (var i in objResult)
            {
                var shopOwnerName = userProfileRepository.GetUserProfileById((int)i.ShopOwnerId).UserName;
                var requesterName = userProfileRepository.GetUserProfileById((int)i.RequesterId).UserName;
                var RentalServiceName = vehicleRentalServiceRepository.GetVehicleRentalServiceById((int)i.RentalServiceID).RantalServiceName;
                var TypeOfVehicleOwn = vehicleRentalServiceRepository.GetVehicleRentalServiceById((int)i.RentalServiceID).TypeOfVehicleOwn;

                requestedRentalServiceViewModel.Add(new RequestedRentalServiceViewModel
                {
                    DetailId = i.DetailId,
                    RentalServiceID = i.RentalServiceID,
                    RantalServiceName = RentalServiceName,
                    TypeOfVehicleOwn = TypeOfVehicleOwn,
                    ShopOwnerId = i.ShopOwnerId,
                    ShopOwnerName = shopOwnerName,
                    RequesterId = i.RequesterId,
                    RequesterName = requesterName,
                    RequestedCity = i.RequestedCity,
                    ContactNo = i.ContactNo,
                    RatePerKM = i.RatePerKM,
                    IsActive = i.IsActive
                });
            }
            return requestedRentalServiceViewModel;
        }
    }
}
