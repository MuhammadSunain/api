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
    [RoutePrefix("api/ut_Cities")]
    public class CitiesController : ApiController
    {
        ecomSchoolEntities Ut_City = new ecomSchoolEntities();
        [HttpPost]
        [Route("Save/{ut_City}")]
        public IHttpActionResult SaveUt_Countries(City ut_City)
        {
            try
            {
                City Ut_Cities = new City();
                Ut_Cities.Code = ut_City.Code;
                Ut_Cities.Country = ut_City.Country;
                Ut_Cities.State = ut_City.State;
                Ut_Cities.City1 = ut_City.City1;
                Ut_Cities.Description = ut_City.Description;
                Ut_Cities.entityId = ut_City.entityId;
                Ut_City.Cities.Add(Ut_Cities);
                Ut_City.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(ut_City);
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<City> GetAll()
        {
            var obj = Ut_City.Set<City>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Getut_Cities_ByentityId/{id}")]
        public async Task<List<dtout_Cities>> GetByEntityId(int id)
        {
            var query = (from hdr in Ut_City.Cities
                         where
                         (id == hdr.entityId)
                         select new dtout_Cities()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             City = hdr.City1,
                             Country = hdr.Country,
                             State = hdr.State,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
