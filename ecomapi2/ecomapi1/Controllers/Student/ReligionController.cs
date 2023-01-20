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
    [RoutePrefix("api/SmS_Religion")]
    public class ReligionController : ApiController
    {
        ecomSchoolEntities Religion = new ecomSchoolEntities();
        [HttpPost]
        [Route("Save/{sms_Religion}")]
        public IHttpActionResult Save(sms_Religion sms_Religion)
        {
            try
            {
                sms_Religion smsReligion = new sms_Religion();
                smsReligion.Code = sms_Religion.Code;
                smsReligion.Religion = sms_Religion.Religion;
                smsReligion.Description = sms_Religion.Description;
                smsReligion.entityid = sms_Religion.entityid;
                Religion.sms_Religion.Add(smsReligion);
                Religion.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(sms_Religion);
        }
        [HttpGet]
        [Route("SMS_Religion")]
        public IEnumerable<sms_Religion> SMS_Religion()
        {
            var obj = Religion.Set<sms_Religion>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("getSMS_Religion_By_entityId/{entityid}")]
        public async Task<List<sms_Religions>> GetByEntityId(int entityid)
        {
            var query = (from hdr in Religion.sms_Religion
                         where
                         (entityid == hdr.entityid)
                         select new sms_Religions()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             Religion = hdr.Religion,
                             Description = hdr.Description,
                         }).ToList();
            return query;
        }
    }
}
