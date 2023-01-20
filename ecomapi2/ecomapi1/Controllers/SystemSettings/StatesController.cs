using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecomapi1.Controllers.SystemSettings
{
    [RoutePrefix("api/ut_States")]
    public class StatesController : ApiController
    {
        ecomSchoolEntities Ut_State = new ecomSchoolEntities();
        [HttpPost]
        [Route("Save/{ut_States}")]
        public IHttpActionResult SaveUt_Countries(State ut_States)
        {
            try
            {
                State Ut_States = new State();
                Ut_States.Code = ut_States.State1;
                Ut_States.Country = ut_States.Country;
                Ut_States.State1 = ut_States.Description;
                Ut_States.Description = ut_States.Description;
                Ut_States.entityId = ut_States.entityId;
                Ut_State.States.Add(Ut_States);
                Ut_State.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(ut_States);
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<State> GetAll()
        {
            var obj = Ut_State.Set<State>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Getut_States_ByentityId/{id}")]
        public async Task<List<dtout_States>> GetByEntityId(int id)
        {
            var query = (from hdr in Ut_State.States
                         where
                         (id == hdr.entityId)
                         select new dtout_States()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             State = hdr.State1,
                             Country = hdr.Country,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
        [HttpGet]
        [Route("Getut_States_ByentityIdandCountryId/{id}/{Country}")]
        public async Task<List<dtout_States>> GetByEntityId(int id, string Country)
        {
            var query = (from hdr in Ut_State.States
                         where
                         (id == hdr.entityId && Country == hdr.Country)
                         select new dtout_States()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             State = hdr.State1,
                             Country = hdr.Country,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
