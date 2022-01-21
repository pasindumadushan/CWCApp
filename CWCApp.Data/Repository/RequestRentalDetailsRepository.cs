using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class RequestRentalDetailsRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public RequestedRentalDetail GetRequestedRentalDetailById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRentalDetails.Where(x => x.DetailId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<RequestedRentalDetail> GetRequestedRentalDetailList()
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRentalDetails.Where(x => x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<RequestedRentalDetail> GetRequestedRentalDetailsByShopOwnerIdList(int Id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRentalDetails.Where(x => x.ShopOwnerId == Id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<RequestedRentalDetail> GetRequestedRentalDetailsByRequesterIdList(int Id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRentalDetails.Where(x => x.RequesterId == Id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public RequestedRentalDetail PostRequestedRentalDetail(RequestedRentalDetail RequestedRentalDetail)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRentalDetails.Add(RequestedRentalDetail);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RequestedRentalDetail UpdateRequestedRentalDetail(int id, RequestedRentalDetail RequestedRentalDetail)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRentalDetails.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(RequestedRentalDetail);
                cwcAppDBEntities.SaveChanges();

                return RequestedRentalDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RequestedRentalDetail DeleteRequestedRentalDetail(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRentalDetails.Find(id);
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
