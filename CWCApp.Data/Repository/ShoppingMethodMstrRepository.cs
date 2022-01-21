using CWCApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Data.Repository
{
    public class ShoppingMethodMstrRepository
    {
        CWCAppDBEntities cwcAppDBEntities = new CWCAppDBEntities();
        public ShoppingMethodMstr GetShoppingMethodMstrById(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ShoppingMethodMstrs.Where(x => x.ShoppingMethodId == id && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ShoppingMethodMstr GetShoppingMethodMstrByName(ShoppingMethodMstr shoppingMethodMstr)
        {
            try
            {
                var objResult = cwcAppDBEntities.ShoppingMethodMstrs.Where(x => x.ShoppingMethod.ToUpper() == shoppingMethodMstr.ShoppingMethod.ToUpper() && x.IsActive == true).FirstOrDefault();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ShoppingMethodMstr> GetShoppingMethodMstrList()
        {
            try
            {
                var objResult = cwcAppDBEntities.ShoppingMethodMstrs.ToList();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ShoppingMethodMstr PostShoppingMethodMstr(ShoppingMethodMstr shoppingMethodMstr)
        {
            try
            {
                var objResult = cwcAppDBEntities.ShoppingMethodMstrs.Add(shoppingMethodMstr);
                cwcAppDBEntities.SaveChanges();
                return objResult;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ShoppingMethodMstr UpdateShoppingMethodMstr(int id, ShoppingMethodMstr shoppingMethodMstr)
        {
            try
            {
                var objResult = cwcAppDBEntities.ShoppingMethodMstrs.Find(id);

                cwcAppDBEntities.Entry(objResult).CurrentValues.SetValues(shoppingMethodMstr);
                cwcAppDBEntities.SaveChanges();

                return shoppingMethodMstr;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ShoppingMethodMstr DeleteShoppingMethodMstr(int id)
        {
            try
            {
                var objResult = cwcAppDBEntities.ShoppingMethodMstrs.Find(id);
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
