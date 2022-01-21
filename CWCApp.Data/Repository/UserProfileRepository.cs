using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class UserProfileRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public UserProfile GetUserProfileById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserProfiles.Where(x => x.UserId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public UserProfile GetUserProfileByEmail(UserProfile user)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserProfiles.Where(x => x.Email.ToUpper() == user.Email.ToUpper() && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<UserProfile> GetUserProfileList()
        {
            try
            {
                var objResult = cwcAppDBEntities.UserProfiles.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public UserProfile PostUserProfile(UserProfile user)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserProfiles.Add(user);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserProfile UpdateUserProfile(int id, UserProfile user)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserProfiles.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(user);
                cwcAppDBEntities.SaveChanges();

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserProfile DeleteUserProfile(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserProfiles.Find(id);
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
