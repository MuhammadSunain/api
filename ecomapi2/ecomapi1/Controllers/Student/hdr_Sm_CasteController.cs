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
    [RoutePrefix("api/hdr_SM_Caste")]
    public class hdr_Sm_CasteController : ApiController
    {
        ecomSchoolEntities hdr_SM_Caste = new ecomSchoolEntities();
        [Route("Save/{hdr_SM_caste}")]
        [HttpPost]
        public IHttpActionResult Savehdr_SM_caste(Caste hdr_SM_caste)
        {
            try
            {
                Caste hdr_caste = new Caste();
                hdr_caste.Code = hdr_SM_caste.Code;
                hdr_caste.Caste1 = hdr_SM_caste.Caste1;
                hdr_caste.description = hdr_SM_caste.description;
                hdr_caste.entityId = hdr_SM_caste.entityId;
                hdr_SM_Caste.Castes.Add(hdr_caste);
                hdr_SM_Caste.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_SM_caste);
        }
        //dto_Castes
        [HttpGet]
        [Route("Get_hdr_SM_Castes")]
        public IEnumerable<Caste> GetAll()
        {
            var obj = hdr_SM_Caste.Set<Caste>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_SM_Castes_ByentityId/{id}")]

        public async Task<List<dto_Castes>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_SM_Caste.Castes
                         where
                         (id == hdr.entityId)
                         select new dto_Castes()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             Caste = hdr.Caste1,
                             Description = hdr.description,
                         }).ToList();
            return query;
        }
    }
}
