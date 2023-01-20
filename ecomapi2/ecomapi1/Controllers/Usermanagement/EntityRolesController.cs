using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ecomapi1.dto1;
using ecomapi1.Models;

namespace ecomapi1.Controllers.Usermanagement
{
    [RoutePrefix("api/ut_Entity_Roles")]
    public class EntityRolesController : ApiController
    {
        ecomSchoolEntities ut_EntityRole = new ecomSchoolEntities();
        [Route("Save/{ut_Role}")]
        [HttpPost]
        public IHttpActionResult Saveut_Role(Role ut_Role)
        {
            try
            {
                Role role = new Role();
                role.Code = ut_Role.Code;
                role.Role1 = ut_Role.Role1;
                role.client = ut_Role.client;
                role.entityId = ut_Role.entityId;
                ut_EntityRole.Roles.Add(role);
                ut_EntityRole.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(ut_Role);
        }
        [HttpGet]
        [Route("Get_ut_Roles")]
        public IEnumerable<Role> Get_ut_Roles()
        {
            var obj = ut_EntityRole.Set<Role>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Getut_Roles_ByentityId/{id}")]
        public async Task<List<dtout_Entity_Roles>> GetByEntityId(int id)
        {
            var query = (from hdr in ut_EntityRole.Roles
                         where
                         (id == hdr.client)
                         select new dtout_Entity_Roles()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             Role = hdr.Role1,
                             client = hdr.client
                         }).ToList();
            return query;
        }

        [HttpGet]
        [Route("getut_rolesby_clientid/{clientid}")]
        public async Task<List<dtout_Entity_Roles>> getut_rolesby_clientid(int clientid)
        {
            var query = (from hdr in ut_EntityRole.Roles
                         where
                         (clientid == hdr.client)
                         select new dtout_Entity_Roles()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             Role = hdr.Role1,
                             client = hdr.client
                         }).ToList();
            return query;
        }

    }
}
