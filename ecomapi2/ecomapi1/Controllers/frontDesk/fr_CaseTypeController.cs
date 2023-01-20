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
    [RoutePrefix("api/fr_caseType")]
    public class fr_CaseTypeController : ApiController
    {
        ecomSchoolEntities frCaseType = new ecomSchoolEntities();
        [Route("Save/{caseType}")]
        [HttpPost]
        public IHttpActionResult SavecaseType(fr_CaseType caseType)
        {
            try
            {
                fr_CaseType CaseType = new fr_CaseType();
                CaseType.Code = caseType.Code;
                CaseType.CaseGroup = caseType.CaseGroup;
                CaseType.CaseType = caseType.CaseType;
                CaseType.Description = caseType.Description;
                CaseType.CaseFor = caseType.CaseFor;
                CaseType.entityId = caseType.entityId;
                CaseType.clientId = caseType.clientId;
                frCaseType.fr_CaseType.Add(CaseType);
                frCaseType.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(caseType);
        }
        [HttpGet]
        [Route("GetCaseTypes")]
        public IEnumerable<fr_CaseType> GetCaseGroups()
        {
            var obj = frCaseType.Set<fr_CaseType>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("GetCaseTypesByentityId/{id}")]
        public async Task<List<fr_caseTypes>> GetEntityById(int id)
        {
            var query = (from hdr in frCaseType.fr_CaseType
                         where
                         (id == hdr.entityId)
                         select new fr_caseTypes()
                         {
                             Code = hdr.Code,
                             CaseGroup = hdr.CaseGroup,
                             CaseType = hdr.CaseType,
                             Description = hdr.Description,
                             CaseFor = hdr.CaseFor,
                         }).ToList();
            return query;
        }
        [HttpGet]
        [Route("GetCaseTypesByentityidandcasegroup/{id}/{casegroup}")]
        public async Task<List<fr_caseTypes>> getBycaseGroup(int id, string casegroup)
        {
            var query = (from hdr in frCaseType.fr_CaseType
                         where
                         (id == hdr.entityId && casegroup == hdr.CaseGroup)
                         select new fr_caseTypes()
                         {
                             Code = hdr.Code,
                             CaseGroup = hdr.CaseGroup,
                             CaseType = hdr.CaseType,
                             Description = hdr.Description,
                             CaseFor = hdr.CaseFor,
                         }).ToList();
            return query;
        }
    }
}
