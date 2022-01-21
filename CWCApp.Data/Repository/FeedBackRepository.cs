using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class FeedBackRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public FeedBack GetFeedBackById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.FeedBacks.Where(x => x.FeedBackId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public FeedBack GetFeedBackByRateId(int feedBackId)
        {
            try
            {
                var objResult = cwcAppDBEntities.FeedBacks.Where(x => x.RateId == feedBackId && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<FeedBack> GetFeedBackList()
        {
            try
            {
                var objResult = cwcAppDBEntities.FeedBacks.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public FeedBack PostFeedBack(FeedBack feedBack)
        {
            try
            {
                var objResult = cwcAppDBEntities.FeedBacks.Add(feedBack);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FeedBack UpdateFeedBack(int id, FeedBack feedBack)
        {
            try
            {
                var objResult = cwcAppDBEntities.FeedBacks.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(feedBack);
                cwcAppDBEntities.SaveChanges();

                return feedBack;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FeedBack DeleteFeedBack(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.FeedBacks.Find(id);
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
