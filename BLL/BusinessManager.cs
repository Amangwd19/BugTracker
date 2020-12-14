using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
namespace BLL
{
    public class BusinessManager
    {
        public static usermanager GetProduct(int id)
        {
            // return new Product { ID = id, Title = "Gerbera", Description = "wedding Flower", UnitPrice = 6, Quantity = 5000 };
            //  return DBManager.GetByID(id);
            return DBManager.GetByID(id);
        }

        public static List<usermanager> GetAllManagers()
        {
            List<usermanager> allManagers = new List<usermanager>();
            allManagers = DBManager.GetAllManagers();
            return allManagers;
        }


    }
    }
