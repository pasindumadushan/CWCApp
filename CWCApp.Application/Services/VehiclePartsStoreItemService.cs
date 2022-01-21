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
    public class VehiclePartsStoreItemService
    {
        VehiclePartsStoreItemRepository vehiclePartsStoreItemRepository = new VehiclePartsStoreItemRepository();
        VehiclePartsStoreRepository vehiclePartsStoreRepository = new VehiclePartsStoreRepository();
        BoughtItemDetailsRepository boughtItemDetailsRepository = new BoughtItemDetailsRepository();
        UserProfileRepository userProfileRepository = new UserProfileRepository();
        RateServices rateServices = new RateServices();
        public List<VehiclePartsStoreItemViewModel> GetvehicleParts(int userId)
        {
            var objResult = vehiclePartsStoreItemRepository.GetvehiclePartsStoreItemsByIdList(userId);
            List<VehiclePartsStoreItemViewModel> vehiclePartsStoreItemViewModel = new List<VehiclePartsStoreItemViewModel>();

            foreach (var i in objResult)
            {
                vehiclePartsStoreItemViewModel.Add(new VehiclePartsStoreItemViewModel {
                    ItemId = i.ItemId,
                    StoreId = i.StoreId,
                    StoreName = vehiclePartsStoreRepository.GetVehiclePartsStoreById((int)i.StoreId).StoreName,
                    UserId = i.UserId,
                    ItemName = i.ItemName,
                    ItemType = i.ItemType,
                    ItemTotalAmount = i.ItemTotalAmount,
                    ItemBoughtAmount = i.ItemBoughtAmount,
                    ItemBalance = i.ItemBalance,
                    ItemBrand = i.ItemBrand,
                    ItemImage = i.ItemImage,
                    ItemDiscription = i.ItemDiscription,
                    RetailPrice = i.RetailPrice,
                    WholeSalePrice = i.WholeSalePrice,
                    ItemSpecs = i.ItemSpecs,
                    IsActive = i.IsActive,
                });
            }

            return vehiclePartsStoreItemViewModel;
        }

        public VehiclePartsStoreItem SaveVehiclePartsService(HttpPostedFileBase imageFile, int userId, VehiclePartsStoreItem vehiclePartsStoreItem)
        {

            VehiclePartsStoreItem objResult = null;

            if (vehiclePartsStoreItem.ItemId <= 0)
            {
                vehiclePartsStoreItem.UserId = userId;
                vehiclePartsStoreItem.IsActive = true;
                vehiclePartsStoreItem.ItemBoughtAmount = 0;
                vehiclePartsStoreItem.ItemBalance = vehiclePartsStoreItem.ItemTotalAmount;
                objResult = vehiclePartsStoreItemRepository.PostVehiclePartsStoreItem(vehiclePartsStoreItem);
            }
            else
            {
                objResult = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById(vehiclePartsStoreItem.ItemId);
                objResult.StoreId = vehiclePartsStoreItem.StoreId;
                objResult.ItemName = vehiclePartsStoreItem.ItemName;
                objResult.ItemType = vehiclePartsStoreItem.ItemType;
                objResult.ItemTotalAmount = vehiclePartsStoreItem.ItemTotalAmount;
                objResult.ItemBalance = vehiclePartsStoreItem.ItemTotalAmount - objResult.ItemBoughtAmount;
                objResult.ItemBrand = vehiclePartsStoreItem.ItemBrand;
                objResult.RetailPrice = vehiclePartsStoreItem.RetailPrice;
                objResult.ItemDiscription = vehiclePartsStoreItem.ItemDiscription;
                objResult.WholeSalePrice = vehiclePartsStoreItem.WholeSalePrice;
                objResult.ItemSpecs = vehiclePartsStoreItem.ItemSpecs;
                objResult = vehiclePartsStoreItemRepository.UpdateVehiclePartsStoreItem(objResult.ItemId, objResult);
            }


            if (imageFile != null)
            {
                string extension = Path.GetExtension(imageFile.FileName);
                var fileName = "StoreItemPhotos-" + objResult.ItemId + extension;
                objResult.ItemImage = "/Images/StoreItemPhotos/" + fileName;

                imageFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Images/StoreItemPhotos/" + fileName));

                objResult = vehiclePartsStoreItemRepository.UpdateVehiclePartsStoreItem(objResult.ItemId, objResult);
            }

            return objResult;
        }

        public List<VehiclePartsStoreItemViewModel> GetVehicleParts()
        {
            var objResult = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemList();
            List<VehiclePartsStoreItemViewModel> vehiclePartsStoreItemViewModel = new List<VehiclePartsStoreItemViewModel>();

            foreach (var i in objResult)
            {
                
                vehiclePartsStoreItemViewModel.Add(new VehiclePartsStoreItemViewModel
                {
                    ItemId = i.ItemId,
                    StoreId = i.StoreId,
                    StoreName = vehiclePartsStoreRepository.GetVehiclePartsStoreById((int)i.StoreId).StoreName,
                    UserId = i.UserId,
                    ItemName = i.ItemName,
                    ItemType = i.ItemType,
                    ItemTotalAmount = i.ItemTotalAmount,
                    ItemBoughtAmount = i.ItemBoughtAmount,
                    ItemBalance = i.ItemBalance,
                    ItemBrand = i.ItemBrand,
                    ItemImage = i.ItemImage,
                    ItemDiscription = i.ItemDiscription,
                    RetailPrice = i.RetailPrice,
                    WholeSalePrice = i.WholeSalePrice,
                    ItemSpecs = i.ItemSpecs,
                    AvgRate = rateServices.GetRateFeedbackByStoreItemProductId(i.ItemId).Select(item => item.RatedValue).ToList().Average() != null ? rateServices.GetRateFeedbackByStoreItemProductId(i.ItemId).Select(item => item.RatedValue).ToList().Average() : 0,
                    IsActive = i.IsActive,
                });
            }

            return vehiclePartsStoreItemViewModel;
        }

        public VehiclePartsStoreItemViewModel GetVehiclePartDetails(int itemId)
        {
            var objResult = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById(itemId);
            var objResult2 = vehiclePartsStoreRepository.GetVehiclePartsStoreById((int)objResult.StoreId);
            VehiclePartsStoreItemViewModel vehiclePartsStoreItemViewModel = new VehiclePartsStoreItemViewModel();

            vehiclePartsStoreItemViewModel.ItemId = objResult.ItemId;
            vehiclePartsStoreItemViewModel.StoreId = objResult.StoreId;
            vehiclePartsStoreItemViewModel.StoreName = vehiclePartsStoreRepository.GetVehiclePartsStoreById((int)objResult.StoreId).StoreName;
            vehiclePartsStoreItemViewModel.UserId = objResult.UserId;
            vehiclePartsStoreItemViewModel.ItemName = objResult.ItemName;
            vehiclePartsStoreItemViewModel.ItemType = objResult.ItemType;
            vehiclePartsStoreItemViewModel.ItemTotalAmount = objResult.ItemTotalAmount;
            vehiclePartsStoreItemViewModel.ItemBoughtAmount = objResult.ItemBoughtAmount;
            vehiclePartsStoreItemViewModel.ItemBalance = objResult.ItemBalance;
            vehiclePartsStoreItemViewModel.ItemBrand = objResult.ItemBrand;
            vehiclePartsStoreItemViewModel.ItemImage = objResult.ItemImage;
            vehiclePartsStoreItemViewModel.ItemDiscription = objResult.ItemDiscription;
            vehiclePartsStoreItemViewModel.RetailPrice = objResult.RetailPrice;
            vehiclePartsStoreItemViewModel.WholeSalePrice = objResult.WholeSalePrice;
            vehiclePartsStoreItemViewModel.ItemSpecs = objResult.ItemSpecs;
            vehiclePartsStoreItemViewModel.IsActive = objResult.IsActive;

            vehiclePartsStoreItemViewModel.AddressOfStore = objResult2.AddressOfStore;
            vehiclePartsStoreItemViewModel.ContactNumber = objResult2.ContactNumber;
            vehiclePartsStoreItemViewModel.ShoppingMethod = objResult2.ShoppingMethod;


            return vehiclePartsStoreItemViewModel;
        }

        public List<BoughtItemViewModel> GetBoughtItems(int userId)
        {
            List<BoughtItemViewModel> boughtItemViewModel = new List<BoughtItemViewModel>();
            var objResult = boughtItemDetailsRepository.GetBoughtItemDetailsByIdBuyerId(userId);

            foreach (var i in objResult)
            {
                var itemName = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById((int)i.ItemId).ItemName;
                var itemImage= vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById((int)i.ItemId).ItemImage;
                var storeId = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById((int)i.ItemId).StoreId;
                var storeName = vehiclePartsStoreRepository.GetVehiclePartsStoreById((int)storeId).StoreName;
                boughtItemViewModel.Add(new BoughtItemViewModel
                {
                    DetailsId = (int)i.DetailsId,
                    ItemId = (int)i.ItemId,
                    ItemName = itemName,
                    ItemImage = itemImage,
                    ShopOwnerId = (int)i.ShopOwnerId,
                    BuyerId = (int)i.BuyerId,
                    StoreId = storeId,
                    StoreName = storeName,
                    DeliveryAddress = i.DeliveryAddress,
                    Quantity = i.Quantity,
                    ContactNo = (int)i.ContactNo,
                    RetailPrice = i.RetailPrice,
                    WholeSalePrice = i.WholeSalePrice,
                    TotalPrice = i.TotalPrice,
                    IsActive = i.IsActive,
                });
            }

            return boughtItemViewModel;
        }
        
        public List<BoughtItemViewModel> GetSoldItems(int userId)
        {
            List<BoughtItemViewModel> boughtItemViewModel = new List<BoughtItemViewModel>();
            var objResult = boughtItemDetailsRepository.GetBoughtItemDetailsByShopOwnerId(userId);

            foreach (var i in objResult)
            {
                var userName = userProfileRepository.GetUserProfileById((int)i.BuyerId).UserName;
                var itemName = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById((int)i.ItemId).ItemName;
                var itemImage= vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById((int)i.ItemId).ItemImage;
                var storeId = vehiclePartsStoreItemRepository.GetVehiclePartsStoreItemById((int)i.ItemId).StoreId;
                var storeName = vehiclePartsStoreRepository.GetVehiclePartsStoreById((int)storeId).StoreName;
                boughtItemViewModel.Add(new BoughtItemViewModel
                {
                    DetailsId = (int)i.DetailsId,
                    UserId = (int)i.BuyerId,
                    UserName = userName,
                    ItemId = (int)i.ItemId,
                    ItemName = itemName,
                    ItemImage = itemImage,
                    ShopOwnerId = (int)i.ShopOwnerId,
                    BuyerId = (int)i.BuyerId,
                    StoreId = storeId,
                    StoreName = storeName,
                    DeliveryAddress = i.DeliveryAddress,
                    Quantity = i.Quantity,
                    ContactNo = (int)i.ContactNo,
                    RetailPrice = i.RetailPrice,
                    WholeSalePrice = i.WholeSalePrice,
                    TotalPrice = i.TotalPrice,
                    IsActive = i.IsActive,
                });
            }

            return boughtItemViewModel;
        }
    }
    

}
