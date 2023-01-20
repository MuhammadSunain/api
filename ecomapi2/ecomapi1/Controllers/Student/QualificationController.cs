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
    [RoutePrefix("api/SmS_Qualification")]
    public class QualificationController : ApiController
    {
        ecomSchoolEntities Qualifications = new ecomSchoolEntities();
        [HttpPost]
        [Route("Save/{sms_Qualification}")]
        public IHttpActionResult Save(Sms_Qualification sms_Qualification)
        {
            try
            {
                Sms_Qualification smsQualification = new Sms_Qualification();
                smsQualification.Code = sms_Qualification.Code;
                smsQualification.qualificationtypeid = sms_Qualification.qualificationtypeid;
                smsQualification.qualification = sms_Qualification.qualification;
                smsQualification.Description = sms_Qualification.Description;
                smsQualification.entityid = sms_Qualification.entityid;
                Qualifications.Sms_Qualification.Add(smsQualification);
                Qualifications.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(sms_Qualification);
        }
        [HttpGet]
        [Route("SMS_Qualification")]
        public IEnumerable<Sms_Qualification> SMS_Qualification()
        {
            var obj = Qualifications.Set<Sms_Qualification>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("getSMS_Qualification_By_entityId/{entityid}")]
        public async Task<List<Qualification>> GetByEntityId(int entityid)
        {
            var query = (from hdr in Qualifications.Sms_Qualification
                         where
                         (entityid == hdr.entityid)
                         select new Qualification()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             QualificationType = hdr.qualificationtypeid,
                             qualification = hdr.qualification,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
