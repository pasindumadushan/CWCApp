using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class ServiceFeedBackRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public ServiceFeedBack GetServiceFeedBackById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceFeedBacks.Where(x => x.ServiceFeedBackId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ServiceFeedBack GetServiceFeedBackByFeedBackId(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceFeedBacks.Where(x => x.FeedBackId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ServiceFeedBack> GetServiceFeedBackByFeedBackId(ServiceFeedBack serviceFeedBack)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceFeedBacks.Where(x => x.FeedBackId == serviceFeedBack.FeedBackId && x.IsActive == true).ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ServiceFeedBack> GetServiceFeedBackList()
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceFeedBacks.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ServiceFeedBack PostServiceFeedBack(ServiceFeedBack serviceFeedBack)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceFeedBacks.Add(serviceFeedBack);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceFeedBack UpdateServiceFeedBack(int id, ServiceFeedBack serviceFeedBack)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceFeedBacks.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(serviceFeedBack);
                cwcAppDBEntities.SaveChanges();

                return serviceFeedBack;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceFeedBack DeleteServiceFeedBack(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ServiceFeedBacks.Find(id);
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
