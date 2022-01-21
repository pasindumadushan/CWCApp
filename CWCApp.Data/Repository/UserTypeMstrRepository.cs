using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class UserTypeMstrRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public UserTypeMstr GetUserTypeMstrById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserTypeMstrs.Where(x => x.UserTypeId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<UserTypeMstr> GetUserTypeMstrList()
        {
            try
            {
                var objResult = cwcAppDBEntities.UserTypeMstrs.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public UserTypeMstr PostUserTypeMstr(UserTypeMstr userTypeMstr)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserTypeMstrs.Add(userTypeMstr);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserTypeMstr UpdateUserTypeMstr(int id, UserTypeMstr userTypeMstr)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserTypeMstrs.Find(id);

                cwcAppDBEntities.Entry(userTypeMstr).State = EntityState.Modified;
                cwcAppDBEntities.SaveChanges();

                return userTypeMstr;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserTypeMstr DeleteUserTypeMstr(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.UserTypeMstrs.Find(id);
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
