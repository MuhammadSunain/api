using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecomapi1.Controllers.AcademicManagement
{
    [RoutePrefix("api/hdr_Ac_Section_group")]
    public class hdr_Ac_section_groupController : ApiController
    {
        ecomSchoolEntities hdr_Ac_Section_group = new ecomSchoolEntities();
        [Route("Save/{hdr_Ac_section_group}")]
        [HttpPost]
        public IHttpActionResult Savehdr_Ac_section_group(hdr_Ac_Section_group hdr_Ac_section_group)
        {
            try
            {
                hdr_Ac_Section_group hdr_Section_group = new hdr_Ac_Section_group();
                hdr_Section_group.Code = hdr_Ac_section_group.Code;
                hdr_Section_group.SectionGroup = hdr_Ac_section_group.SectionGroup;
                hdr_Section_group.Description = hdr_Ac_section_group.Description;
                hdr_Section_group.Sections = hdr_Ac_section_group.Sections;
                hdr_Section_group.entityId = hdr_Ac_section_group.entityId;
                hdr_Ac_Section_group.hdr_Ac_Section_group.Add(hdr_Section_group);
                hdr_Ac_Section_group.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_Ac_section_group);
        }
        [HttpGet]
        [Route("Get_hdr_Ac_Section_group")]
        public IEnumerable<hdr_Ac_Section_group> GetAll()
        {
            var obj = hdr_Ac_Section_group.Set<hdr_Ac_Section_group>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_Ac_Section_groupByentityId/{id}")]

        public async Task<List<dtohdr_Ac_section_group>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_Ac_Section_group.hdr_Ac_Section_group
                         where
                         (id == hdr.entityId)
                         select new dtohdr_Ac_section_group()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             SectionGroup = hdr.SectionGroup,
                             Description = hdr.Description,
                             Section = hdr.Sections
                         }).ToList();
            return query;
        }
        [HttpGet]
        [Route("Gethdr_Ac_Section_groupByentityIdandSectionId/{id}/{Section}")]

        public async Task<List<dtohdr_Ac_section_group>> GetEntityById(int id, string Section)
        {
            var query = (from hdr in hdr_Ac_Section_group.hdr_Ac_Section_group
                         where
                         (id == hdr.entityId && Section == hdr.Sections)
                         select new dtohdr_Ac_section_group()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             SectionGroup = hdr.SectionGroup,
                             Section = hdr.Sections,
                             Description = hdr.Description,
                         }).ToList();
            return query;
        }
    }
}
