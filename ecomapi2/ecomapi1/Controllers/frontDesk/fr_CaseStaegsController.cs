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
    [RoutePrefix("api/fr_setup_CaseStages")]
    public class fr_CaseStagesController : BaseController<fr_casestage>
    {
        ecomSchoolEntities fr_caseStages = new ecomSchoolEntities();
        [Route("Save/{casestage}")]
        [HttpPost]
        public IHttpActionResult Savecasestage(fr_casestage casestage)
        {
            try
            {
                //fr_casestage caseStage = new fr_casestage();
                //caseStage.Code = casestage.Code;
                //caseStage.Caseuser = casestage.Caseuser;
                //caseStage.Stagetype = casestage.Stagetype;
                //caseStage.Stages = casestage.Stages;
                //caseStage.description = casestage.description;
                //caseStage.entityId = casestage.entityId;
                //caseStage.clientID = casestage.clientID;
                //fr_caseStages.fr_casestage.Add(caseStage);
                //fr_caseStages.SaveChanges();
                Save(casestage);
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(casestage);
        }
        [HttpGet]
        [Route("GetCaseStages")]
        public IEnumerable<fr_casestage> GetCaseGroups()
        {
            var obj = fr_caseStages.Set<fr_casestage>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("GetCaseStagesByentityId/{id}")]
        public async Task<List<casestages>> GetEntityById(int id)
        {
            var query = (from hdr in fr_caseStages.fr_casestage
                         where
                         (id == hdr.entityId)
                         select new casestages()
                         {
                             Code = hdr.Code,
                             casesuer = hdr.Caseuser,
                             stagetype = hdr.Stagetype,
                             stages = hdr.Stages,
                             Description = hdr.description,
                         }).ToList();
            return query;
        }
    }
}
    