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
    [RoutePrefix("api/fr_case_group")]
    public class fr_CaseGroupController : ApiController
    {
        ecomSchoolEntities frCaseGroup = new ecomSchoolEntities();
        [Route("Save/{caseGroup}")]
        [HttpPost]
        public IHttpActionResult SavecaseGroup(fr_CaseGroup caseGroup)
        {
            try
            {
                fr_CaseGroup casegroup = new fr_CaseGroup();
                casegroup.Code = caseGroup.Code;
                casegroup.CaseGroup = caseGroup.CaseGroup;
                casegroup.Description = caseGroup.Description;
                casegroup.entityId = caseGroup.entityId;
                casegroup.clientId = caseGroup.clientId;
                frCaseGroup.fr_CaseGroup.Add(casegroup);
                frCaseGroup.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(caseGroup);
        }
        [HttpGet]
        [Route("GetCaseGroups")]
        public IEnumerable<fr_CaseGroup> GetCaseGroups()
        {
            var obj = frCaseGroup.Set<fr_CaseGroup>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("GetCaseGroupsByentityId/{id}")]
        public async Task<List<caseGROUP>> GetEntityById(int id)
        {
            var query = (from hdr in frCaseGroup.fr_CaseGroup
                         where
                         (id == hdr.entityId)
                         select new caseGROUP()
                         {
                             Code = hdr.Code,
                             CaseGroup = hdr.CaseGroup,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
