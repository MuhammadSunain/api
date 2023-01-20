using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecomapi1.Controllers.frontDesk
{
    [RoutePrefix("api/fr_setup_purpose")]
    public class FR_Setup_PurposeController : ApiController
    {
        ecomSchoolEntities frPurpose = new ecomSchoolEntities();
        [Route("Save/{Purpose}")]
        [HttpPost]
        public IHttpActionResult SavePurpose(fr_Purpose Purpose)
        {
            try
            {
                fr_Purpose Purposes = new fr_Purpose();
                Purposes.Code = Purpose.Code;
                Purposes.Purpose = Purpose.Purpose;
                Purposes.Description = Purpose.Description;
                Purposes.entityId = Purpose.entityId;
                Purposes.clientId = Purpose.clientId;
                frPurpose.fr_Purpose.Add(Purposes);
                frPurpose.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(Purpose);
            return Ok(Purpose);
        }
        [HttpGet]
        [Route("GetPurposes")]
        public IEnumerable<fr_Purpose> GetCaseGroups()
        {
            var obj = frPurpose.Set<fr_Purpose>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("GetPurposeityId/{id}")]
        public async Task<List<fr_purpose>> GetEntityById(int id)
        {
            var query = (from hdr in frPurpose.fr_Purpose
                         where
                         (id == hdr.entityId)
                         select new fr_purpose()
                         {
                             Code = hdr.Code,
                             Purpose = hdr.Purpose,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
