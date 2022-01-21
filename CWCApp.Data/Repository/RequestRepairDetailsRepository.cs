using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class RequestRepairDetailsRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public RequestedRepairDetail GetRequestedRepairDetailById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRepairDetails.Where(x => x.DetailId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<RequestedRepairDetail> GetRequestedRepairDetailList()
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRepairDetails.Where(x => x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<RequestedRepairDetail> GetRequestedRepairDetailsByShopOwnerIdList(int Id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRepairDetails.Where(x => x.ShopOwnerId == Id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<RequestedRepairDetail> GetRequestedRepairDetailsByRequesterIdList(int Id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRepairDetails.Where(x => x.RequesterId == Id && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public RequestedRepairDetail PostRequestedRepairDetail(RequestedRepairDetail RequestedRepairDetail)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRepairDetails.Add(RequestedRepairDetail);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RequestedRepairDetail UpdateRequestedRepairDetail(int id, RequestedRepairDetail RequestedRepairDetail)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRepairDetails.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(RequestedRepairDetail);
                cwcAppDBEntities.SaveChanges();

                return RequestedRepairDetail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RequestedRepairDetail DeleteRequestedRepairDetail(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.RequestedRepairDetails.Find(id);
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
