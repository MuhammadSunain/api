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
    [RoutePrefix("api/fr_setup_CaseRules")]
    public class fr_CaseRulesController : ApiController
    {
        ecomSchoolEntities frCaseRules = new ecomSchoolEntities();
        [Route("Save/{CaseRules}")]
        [HttpPost]
        public IHttpActionResult SaveCaseRules(fr_CASERULES CaseRules)
        {
            try
            {
                fr_CASERULES CaseRule = new fr_CASERULES();
                CaseRule.Code = CaseRules.Code;
                CaseRule.CaseGroup = CaseRules.CaseGroup;
                CaseRule.CaseType= CaseRules.CaseType;
                CaseRule.CaseRule = CaseRules.CaseRule;
                CaseRule.Description= CaseRules.Description;
                CaseRule.AssignTo = CaseRules.AssignTo;
                CaseRule.entityId = CaseRules.entityId;
                CaseRule.clientId= CaseRules.clientId;
                frCaseRules.fr_CASERULES.Add(CaseRule);
                frCaseRules.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(CaseRules);
        }
        [HttpGet]
        [Route("GetfrCaseRules")]
        public IEnumerable<fr_CASERULES> GetCaseGroups()
        {
            var obj = frCaseRules.Set<fr_CASERULES>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("GetcaseRulesByEntityId/{id}")]
        public async Task<List<frCaseRules>> GetEntityById(int id)
        {
            var query = (from hdr in frCaseRules.fr_CASERULES
                         where
                         (id == hdr.entityId)
                         select new frCaseRules()
                         {
                             Code = hdr.Code,
                             CaseGroup = hdr.CaseGroup,
                             CaseType = hdr.CaseType,
                             CaseRule = hdr.CaseRule,
                             Description = hdr.Description,
                             asignto = hdr.AssignTo
                         }).ToList();
            return query;
        }
    }
}
