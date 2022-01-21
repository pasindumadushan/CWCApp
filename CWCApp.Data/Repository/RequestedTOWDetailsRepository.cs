using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class RequestedTOWDetailsRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public RequestedTOWDetail GetRequestedTOWDetailById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedTOWDetails.Where(x => x.DetailId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<RequestedTOWDetail> GetRequestedTOWDetailList()
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedTOWDetails.Where(x => x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<RequestedTOWDetail> GetRequestedTOWDetailsByShopOwnerIdList(int Id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedTOWDetails.Where(x => x.ShopOwnerId == Id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<RequestedTOWDetail> GetRequestedTOWDetailsByRequesterIdList(int Id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedTOWDetails.Where(x => x.RequesterId == Id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public RequestedTOWDetail PostRequestedTOWDetail(RequestedTOWDetail RequestedTOWDetail)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedTOWDetails.Add(RequestedTOWDetail);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RequestedTOWDetail UpdateRequestedTOWDetail(int id, RequestedTOWDetail RequestedTOWDetail)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedTOWDetails.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(RequestedTOWDetail);
                cwcAppDBEntities.SaveChanges();

                return RequestedTOWDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RequestedTOWDetail DeleteRequestedTOWDetail(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedTOWDetails.Find(id);
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
