using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;

namespace ecomapi1.Controllers.Entities
{
    [RoutePrefix("api/Entities_Type")]
    public class Entity_TypeController : ApiController
    {
        ecomSchoolEntities Entities_Type = new ecomSchoolEntities();
        [Route("Save/{entity_Type}")]
        [HttpPost]
        public IHttpActionResult SaveEntityType(entity_Type entity_Type)
        {
            try
            {
                entity_Type entities_type = new entity_Type();
                entities_type.Code = entity_Type.Code;
                entities_type.Type = entity_Type.Type;
                entities_type.Description = entity_Type.Description;
                Entities_Type.entity_Type.Add(entities_type);
                Entities_Type.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(entity_Type);
        }
        [HttpGet]
        [Route("GetEntities_Type")]
        public IEnumerable<entity_Type> GetEntities_Type()
        {
            var obj = Entities_Type.Set<entity_Type>().ToList();
            return obj;
        }
       // [HttpDelete]
        //[Route("Delete/{id}")]
        //public IHttpActionResult Delete(int id)
        //{
          //  var item = Delete<entity_Type>(id);
            //if (item != null)
            //{
              //  return Ok("Record Deleted Successfully");
            //}
            //return Ok();
        //}
    }
}
