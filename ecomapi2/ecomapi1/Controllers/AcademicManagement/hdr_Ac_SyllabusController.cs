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
    [RoutePrefix("api/hdr_Ac_syllabus")]
    public class hdr_Ac_SyllabusController : ApiController
    {
        ecomSchoolEntities hdr_Ac_Syllabus = new ecomSchoolEntities();

        [Route("Save/{hdr_Ac_syllabus}")]
        [HttpPost]
        public IHttpActionResult Savehdr_Ac_syllabus(hdr_Ac_Syllabus hdr_Ac_syllabus)
        {
            try
            {
                hdr_Ac_Syllabus hdr_Syllabus = new hdr_Ac_Syllabus();
                hdr_Syllabus.Code = hdr_Ac_syllabus.Code;
                hdr_Syllabus.Syllabus = hdr_Ac_syllabus.Syllabus;
                hdr_Syllabus.Description = hdr_Ac_syllabus.Description;
                hdr_Syllabus.entityId = hdr_Ac_syllabus.entityId;
                hdr_Ac_Syllabus.hdr_Ac_Syllabus.Add(hdr_Syllabus);
                hdr_Ac_Syllabus.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_Ac_syllabus);
        }
        [HttpGet]
        [Route("Get_hdr_Ac_Syllabus")]
        public IEnumerable<hdr_Ac_Syllabus> GetAll()
        {
            var obj = hdr_Ac_Syllabus.Set<hdr_Ac_Syllabus>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_Ac_SyllabusByentityId/{id}")]
        public async Task<List<dto_hdr_Ac_Syllabus>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_Ac_Syllabus.hdr_Ac_Syllabus
                         where
                         (id == hdr.entityId)
                         select new dto_hdr_Ac_Syllabus()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             Syllabus = hdr.Syllabus,
                             description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
