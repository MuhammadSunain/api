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
    [RoutePrefix("api/fr_setup_source")]
    public class FR_Setup_SourceController : ApiController
    {
        ecomSchoolEntities frSources = new ecomSchoolEntities();
        [Route("Save/{Sources}")]
        [HttpPost]
        public IHttpActionResult SaveSources(fr_Source Sources)
        {
            try
            {
                fr_Source Source = new fr_Source();
                Source.Code = Sources.Code;
                Source.Source = Sources.Source;
                Source.Description = Sources.Description;
                Source.entityId = Sources.entityId;
                Source.clientId = Sources.clientId;
                frSources.fr_Source.Add(Source);
                frSources.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(Sources);
        }
        [HttpGet]
        [Route("GetSources")]
        public IEnumerable<fr_Source> GetCaseGroups()
        {
            var obj = frSources.Set<fr_Source>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("GetSourcesByentityId/{id}")]
        public async Task<List<fr_Sources>> GetEntityById(int id)
        {
            var query = (from hdr in frSources.fr_Source
                         where
                         (id == hdr.entityId)
                         select new fr_Sources()
                         {
                             Code = hdr.Code,
                             Source = hdr.Source,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
