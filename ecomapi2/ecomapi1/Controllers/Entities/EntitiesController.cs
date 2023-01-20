using ecomapi1.Controllers.Student;
using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ecomapi1.Controllers.Entities
{
    [RoutePrefix("api/Entities")]
    public class EntitiesController : BaseController<Entity>
    {
        ecomSchoolEntities Entities = new ecomSchoolEntities();
        [Route("Save/{entity}")]
        [HttpPost]
        public IHttpActionResult SaveCategory(Entity entity)
        {
            try
            {
                // Entity entities = new Entity();
                //entities.Code = entity.Code;
                // entities.EntityName = entity.EntityName;
                // entities.EntityDate = entity.EntityDate;
                // entities.EntityType = entity.EntityType;
                // entities.ownerName = entity.ownerName;
                // entities.contsctno = entity.contsctno;
                // entities.email = entity.email;
                // entities.address = entity.address;
                // entities.clientid = entity.clientid;
                // Entities.Entities.Add(entities);
                // Entities.SaveChanges();
                Save(entity);
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(entity);
        }
        [HttpGet]
        [Route("GetEntities")]
        public IEnumerable<Entity> GetAll()
        {
            var obj = Entities.Set<Entity>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("GetEntityById/{clientid}")]
        public async Task<List<dtoentity>> GetEntityById(int clientid)
        {
            var query = (from hdr in Entities.Entities
                         where
                         (clientid == hdr.clientid)
                         select new dtoentity()
                         {
                            Id = hdr.Id,
                            Code = hdr.Code,
                            EntityName = hdr.EntityName,
                            EntityDate = hdr.EntityDate,
                            EntityType = hdr.EntityType,
                            ownerName = hdr.ownerName,
                             contsctno = hdr.contsctno,
                             email = hdr.email,
                             address = hdr.address
                         }).ToList();
            return query;
        }
        [HttpGet]
        [Route("GetEntityByIdandid/{entityid}")]
        public async Task<List<dtoentity>> GetEntityByIdandid(int entityid)
        {
            var query = (from hdr in Entities.Entities
                         where
                         (entityid == hdr.Id)
                         select new dtoentity()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             EntityName = hdr.EntityName
                         }).ToList();
            return query;
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var item = Delete<Entity>(id);
            if (item != null)
            {
                return Ok("Record Deleted Successfully...");
            }
            return (Ok()); 
        }
    }
}
