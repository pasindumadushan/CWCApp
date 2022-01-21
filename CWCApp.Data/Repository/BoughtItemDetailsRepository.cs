using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class BoughtItemDetailsRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public BoughtItemDetail GetBoughtItemDetailsById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.BoughtItemDetails.Where(x => x.DetailsId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<BoughtItemDetail> GetBoughtItemDetailsByShopOwnerId(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.BoughtItemDetails.Where(x => x.ShopOwnerId == id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<BoughtItemDetail> GetBoughtItemDetailsByIdBuyerId(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.BoughtItemDetails.Where(x => x.BuyerId == id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<BoughtItemDetail> GetBoughtItemDetailsList()
        {
            try
            {
                var objResult = cwcAppDBEntities.BoughtItemDetails.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public BoughtItemDetail PostBoughtItemDetails(BoughtItemDetail boughtItemDetails)
        {
            try
            {
                var objResult = cwcAppDBEntities.BoughtItemDetails.Add(boughtItemDetails);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BoughtItemDetail UpdateBoughtItemDetails(int id, BoughtItemDetail boughtItemDetails)
        {
            try
            {
                var objResult = cwcAppDBEntities.BoughtItemDetails.Find(id);

                cwcAppDBEntities.Entry(boughtItemDetails).State = EntityState.Modified;
                cwcAppDBEntities.SaveChanges();

                return boughtItemDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BoughtItemDetail DeleteBoughtItemDetails(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.BoughtItemDetails.Find(id);
                objResult.IsActive = false;

                cwcAppDBEntities.Entry(objResult).State = EntityState.Modified;
                cwcAppDBEntities.SaveChanges();

                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

