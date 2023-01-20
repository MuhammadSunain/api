using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecomapi1.Controllers.AcademicManagement
{
    [RoutePrefix("api/hdr_AC_Book_Category")]
    public class hdr_Ac_bookCategoryController : ApiController
    {
        ecomSchoolEntities hdr_Ac_Book_Category = new ecomSchoolEntities();
        [Route("Save/{hdr_Ac_BookCategory}")]
        [HttpPost]
        public IHttpActionResult Savehdr_Ac_BookCategory(hdr_Ac_bookCategory hdr_Ac_BookCategory)
        {
            try
            {
                hdr_Ac_bookCategory hdrac_bookCategory = new hdr_Ac_bookCategory();
                hdrac_bookCategory.Code = hdr_Ac_BookCategory.Code;
                hdrac_bookCategory.BookCategory = hdr_Ac_BookCategory.BookCategory;
                hdrac_bookCategory.entityId = hdr_Ac_BookCategory.entityId;
                hdr_Ac_Book_Category.hdr_Ac_bookCategory.Add(hdrac_bookCategory);
                hdr_Ac_Book_Category.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(hdr_Ac_BookCategory);
        }
        [HttpGet]
        [Route("Get_hdr_AC_BookCategory")]
        public IEnumerable<hdr_Ac_bookCategory> GetAll()
        {
            var obj = hdr_Ac_Book_Category.Set<hdr_Ac_bookCategory>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_AC_BookCategory_ByentityId/{id}")]

        public async Task<List<dtohdr_Ac_bookCategory>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_Ac_Book_Category.hdr_Ac_bookCategory
                         where
                         (id == hdr.entityId)
                         select new dtohdr_Ac_bookCategory()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             BookCategory = hdr.BookCategory,
                         }).ToList();
            return query;
        }
    }
}
