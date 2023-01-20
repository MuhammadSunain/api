using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecomapi1.Controllers.Student
{
    [RoutePrefix("api/student_Category")]
    public class StudentCategoryController : ApiController
    {
        ecomSchoolEntities stdcategory = new ecomSchoolEntities();
        [Route("Save/{stdCategory}")]
        [HttpPost]
        public IHttpActionResult SaveStdCategory(student_category stdCategory)
        {
            try
            {
                student_category stdCat = new student_category();
                stdCat.Code = stdCategory.Code;
                stdCat.studentcategory = stdCategory.studentcategory;
                stdCat.description = stdCategory.description;
                stdCat.entityId = stdCategory.entityId;
                stdcategory.student_category.Add(stdCat);
                stdcategory.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(stdCategory);
        }
        [HttpGet]
        [Route("Getstudent_Category")]
        public IEnumerable<student_category> Getstudent_Category()
        {
            var obj = stdcategory.Set<student_category>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("GetStdCategoryByentityId/{id}")]
        public async Task<List<dtoStdCategory>> GetEntityById(int id)
        {
            var query = (from hdr in stdcategory.student_category
                         where
                         (id == hdr.entityId)
                         select new dtoStdCategory()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             studentcategory = hdr.studentcategory,
                             description = hdr.description
                         }).ToList();
            return query;
        }
    }
}
