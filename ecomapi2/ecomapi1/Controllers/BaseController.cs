using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using ecomapi1.Models;

namespace ecomapi1.Controllers
{
    public class BaseController<T> : ApiController where T : class, new()
    {
        static ecomSchoolEntities ecom;
        static DbSet<T> dbset;
        public BaseController()
        {
            ecom = new ecomSchoolEntities();
            dbset = ecom.Set<T>();
        }
        public static void Save(T item)
        {
            ecom.Set<T>().Add(item);
            ecom.SaveChanges();
        }

        public static string Delete<T>(int id) where T : class
        {
            string error = "";
            var item = ecom.Set<T>().Find(id);
            if (item != null)
            {
                ecom.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                ecom.SaveChanges();
            }
            else
            {
                error = "No Record Found to Delete";
            }
            return error;
        }
    }
}