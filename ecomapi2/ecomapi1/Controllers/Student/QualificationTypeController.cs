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
    [RoutePrefix("api/SmS_QualificationType")]
    public class SMS_QualificationTypeController : ApiController
    {
        ecomSchoolEntities QualificationType = new ecomSchoolEntities();
        [HttpPost]
        [Route("Save/{sms_Qualificationtype}")]
        public IHttpActionResult Save(SMS_QualificationType sms_Qualificationtype)
        {
            try
            {
                SMS_QualificationType smsQualificationType = new SMS_QualificationType();
                smsQualificationType.Code = sms_Qualificationtype.Code;
                smsQualificationType.QualificationType = sms_Qualificationtype.QualificationType;
                smsQualificationType.Dexcription = sms_Qualificationtype.Dexcription;
                smsQualificationType.entityid = sms_Qualificationtype.entityid;
                QualificationType.SMS_QualificationType.Add(smsQualificationType);
                QualificationType.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(sms_Qualificationtype);
        }
        [HttpGet]
        [Route("getSMS_QualificationType_By_entityId/{entityid}")]
        public async Task<List<sms_Qualification_Type>> GetByEntityId(int entityid)
        {
            var query = (from hdr in QualificationType.SMS_QualificationType
                         where
                         (entityid == hdr.entityid)
                         select new sms_Qualification_Type()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             QualificationType = hdr.QualificationType,
                             Description = hdr.Dexcription,
                         }).ToList();
            return query;
        }
    }
}
