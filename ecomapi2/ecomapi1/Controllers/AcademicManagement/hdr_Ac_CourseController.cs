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
    [RoutePrefix("api/hdr_Ac_Course")]
    public class hdr_Ac_CourseController : ApiController
    {
        ecomSchoolEntities hdr_Ac_Course = new ecomSchoolEntities();
        [Route("Save/{hdr_Ac_course}")]
        [HttpPost]
        public IHttpActionResult Savehdr_Ac_course(hdr_Ac_Course hdr_Ac_course)
        {
            try
            {
                hdr_Ac_Course hdr_Course = new hdr_Ac_Course();
                hdr_Course.Code = hdr_Ac_course.Code;
                hdr_Course.CourseCategory = hdr_Ac_course.CourseCategory;
                hdr_Course.Course = hdr_Ac_course.Course;
                hdr_Course.Syllabus = hdr_Ac_course.Syllabus;
                hdr_Course.AgeFrom = hdr_Ac_course.AgeFrom;
                hdr_Course.AgeTill = hdr_Ac_course.AgeTill;
                hdr_Course.entityId = hdr_Ac_course.entityId;
                hdr_Ac_Course.hdr_Ac_Course.Add(hdr_Course);
                hdr_Ac_Course.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_Ac_course);
        }
        //dto_hdr_Ac_Course
        [HttpGet]
        [Route("Get_hdr_Ac_Course")]
        public IEnumerable<hdr_Ac_Course> GetAll()
        {
            var obj = hdr_Ac_Course.Set<hdr_Ac_Course>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_Ac_CourseByentityId/{id}")]

        public async Task<List<dto_hdr_Ac_Course>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_Ac_Course.hdr_Ac_Course
                         where
                         (id == hdr.entityId)
                         select new dto_hdr_Ac_Course()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             CourseCategory = hdr.CourseCategory,
                             Course = hdr.Course,
                             Syllabus = hdr.Syllabus,
                             AgeFrom = hdr.AgeFrom,
                             AgeTill = hdr.AgeTill
                         }).ToList();
            return query;
        }
        [HttpGet]
        [Route("Gethdr_Ac_CourseByentityId_and_Syllabus/{id}/{Syllabus}")]

        public async Task<List<dto_hdr_Ac_Course>> GetEntityById(int id,string Syllabus)
        {
            var query = (from hdr in hdr_Ac_Course.hdr_Ac_Course
                         where
                         (id == hdr.entityId && Syllabus == hdr.Syllabus)
                         select new dto_hdr_Ac_Course()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             CourseCategory = hdr.CourseCategory,
                             Course = hdr.Course,
                             Syllabus = hdr.Syllabus,
                             AgeFrom = hdr.AgeFrom,
                             AgeTill = hdr.AgeTill
                         }).ToList();
            return query;
        }
    }
}
