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
    [RoutePrefix("api/hdr_AC_Subject_Type")]
    public class hdr_Ac_subjectTypeController : ApiController
    {
        ecomSchoolEntities hdr_AC_subjectType = new ecomSchoolEntities();
        [Route("Save/{hdr_AC_SubjectType}")]
        [HttpPost]
        public IHttpActionResult Savehdr_AC_SubjectType(hdr_Ac_subjectType hdr_AC_SubjectType)
        {
            try
            {
                hdr_Ac_subjectType hdrac_subjectType = new hdr_Ac_subjectType();
                hdrac_subjectType.Code = hdr_AC_SubjectType.Code;
                hdrac_subjectType.SubjectType = hdr_AC_SubjectType.SubjectType;
                hdrac_subjectType.Description = hdr_AC_SubjectType.Description;
                hdrac_subjectType.entityId = hdr_AC_SubjectType.entityId;
                hdr_AC_subjectType.hdr_Ac_subjectType.Add(hdrac_subjectType);
                hdr_AC_subjectType.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_AC_SubjectType);
        }
        [HttpGet]
        [Route("Get_hdr_AC_SubjectType")]
        public IEnumerable<hdr_Ac_subjectType> GetAll()
        {
            var obj = hdr_AC_subjectType.Set<hdr_Ac_subjectType>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_AC_SubjectType_ByentityId/{id}")]

        public async Task<List<dto_ac_subjectType>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_AC_subjectType.hdr_Ac_subjectType
                         where
                         (id == hdr.entityId)
                         select new dto_ac_subjectType()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             SubjectType = hdr.SubjectType,
                             Description = hdr.Description,
                         }).ToList();
            return query;
        }
    }
}
