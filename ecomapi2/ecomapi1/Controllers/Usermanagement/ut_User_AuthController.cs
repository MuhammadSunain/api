using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecomapi1.Controllers.Usermanagement
{
    [RoutePrefix("api/ut_User_Auth")]
    public class ut_User_AuthController : ApiController
    {
        ecomSchoolEntities ut_user_auth = new ecomSchoolEntities();
        [HttpPost]
        [Route("Save/{ut_User_Auth}")]
        public IHttpActionResult Saveut_User_Auth(ut_user_auth ut_User_Auth)
        {
            try
            {
                ut_user_auth Ut_UserAuth = new ut_user_auth();
                Ut_UserAuth.Entity = ut_User_Auth.Entity;
                Ut_UserAuth.Username = ut_User_Auth.Username;
                Ut_UserAuth.Password = ut_User_Auth.Password;
                Ut_UserAuth.Fullname = ut_User_Auth.Fullname;
                Ut_UserAuth.Email = ut_User_Auth.Email;
                Ut_UserAuth.CellNo = ut_User_Auth.CellNo;
                Ut_UserAuth.UserCategory = ut_User_Auth.UserCategory;
                Ut_UserAuth.Role = ut_User_Auth.Role;
                Ut_UserAuth.Status = ut_User_Auth.Status;
                Ut_UserAuth.entityId = ut_User_Auth.entityId;
                Ut_UserAuth.clientid = ut_User_Auth.clientid;
                Ut_UserAuth.entitiesname = ut_User_Auth.entitiesname;
                ut_user_auth.ut_user_auth.Add(Ut_UserAuth);
                ut_user_auth.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(ut_User_Auth);
        }
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<ut_user_auth> GetAll()
        {
            var obj = ut_user_auth.Set<ut_user_auth>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Getut_Users_auth_ByentityId/{id}")]
        public async Task<List<dtout_User_Auth>> GetByEntityId(int id)
        {
            var query = (from hdr in ut_user_auth.ut_user_auth
                         where
                         (id == hdr.entityId)
                         select new dtout_User_Auth()
                         {
                             Id = hdr.Id,
                             Entity = hdr.Entity,
                             Username = hdr.Username,
                             Password = hdr.Password,
                             Fullname = hdr.Fullname,
                             Email = hdr.Email,
                             CellNo = hdr.CellNo,
                             UserCategory = hdr.UserCategory,
                             Role = hdr.Role,
                             Status = hdr.Status
                         }).ToList();
            return query;
        }
        [HttpGet]
        [Route("Getut_Users_auth_ByclientId/{clientid}")]
        public async Task<List<dtout_User_Auth>> GetByclientId(int clientid)
        {
            var query = (from hdr in ut_user_auth.ut_user_auth
                         where
                         (clientid == hdr.clientid)
                         select new dtout_User_Auth()
                         {
                             Id = hdr.Id,
                             Entity = hdr.Entity,
                             Username = hdr.Username,
                             Password = hdr.Password,
                             Fullname = hdr.Fullname,
                             Email = hdr.Email,
                             CellNo = hdr.CellNo,
                             UserCategory = hdr.UserCategory,
                             Role = hdr.Role,
                             Status = hdr.Status,
                             entityid = hdr.clientid
                         }).ToList();
            return query;
        }
    }
}
