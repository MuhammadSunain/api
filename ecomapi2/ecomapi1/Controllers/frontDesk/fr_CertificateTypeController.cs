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
    [RoutePrefix("api/fr_setup_CertificateType")]
    public class fr_CertificateTypeController : ApiController
    {
        ecomSchoolEntities frCertificateType = new ecomSchoolEntities();
        [Route("Save/{CertificateType}")]
        [HttpPost]
        public IHttpActionResult SaveCertificateType(fr_certificateType CertificateType)
        {
            try
            {
                fr_certificateType CertificateTypes = new fr_certificateType();
                CertificateTypes.Code = CertificateType.Code;
                CertificateTypes.CertificateFor = CertificateType.CertificateFor;
                CertificateTypes.CertificateType=CertificateType.CertificateType;
                CertificateTypes.Description= CertificateType.Description;
                CertificateTypes.entityId= CertificateType.entityId;
                CertificateTypes.clientId= CertificateType.clientId;
                frCertificateType.fr_certificateType.Add(CertificateTypes);
                frCertificateType.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(CertificateType);
        }
        [HttpGet]
        [Route("GetfrCertificateType")]
        public IEnumerable<fr_certificateType> GetCaseGroups()
        {
            var obj = frCertificateType.Set<fr_certificateType>().ToList();
            return obj;
        }
        [HttpGet]
        
        [Route("GetcertificateTypesByEntityId/{id}")]
        public async Task<List<frCertificateType>> GetEntityById(int id)
        {
            var query = (from hdr in frCertificateType.fr_certificateType
                         where
                         (id == hdr.entityId)
                         select new frCertificateType()
                         {
                             Code = hdr.Code,
                             CertificateFor=hdr.CertificateFor,
                             certificateType = hdr.CertificateType,
                             Description = hdr.Description
                         }).ToList();
            return query;
        }
    }
}
