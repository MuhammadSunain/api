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
    [RoutePrefix("api/ut_Countries")]
    public class CountriesController : ApiController
    {
        ecomSchoolEntities Ut_Countries = new ecomSchoolEntities();
        [HttpPost]
        [Route("Save/{ut_Countries}")]
        public IHttpActionResult SaveUt_Countries(Country ut_Countries)
        {
            try
            {
                Country Ut_Country = new Country();
                Ut_Country.Code = ut_Countries.Code;
                Ut_Country.Country1 = ut_Countries.Country1;
                Ut_Country.isocode = ut_Countries.isocode;
                Ut_Country.DialCode = ut_Countries.DialCode;
                Ut_Country.Description = ut_Countries.Description;
                Ut_Country.entityId = ut_Countries.entityId;
                Ut_Countries.Countries.Add(Ut_Country);
                Ut_Countries.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(ut_Countries);
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Country> GetAll()
        {
            var obj = Ut_Countries.Set<Country>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Getut_Country_ByentityId/{id}")]
        public async Task<List<dtoCountry>> GetByEntityId(int id)
        {
            var query = (from hdr in Ut_Countries.Countries
                         where
                         (id == hdr.entityId)
                         select new dtoCountry()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             Country = hdr.Country1,
                             IsoCode = hdr.isocode,
                             DialCode = hdr.DialCode,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
