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
    [RoutePrefix("api/hdr_AC_Book_Publisher")]
    public class hdr_Ac_bookPublisherController : ApiController
    {
        ecomSchoolEntities hdr_Ac_Book_Publisher = new ecomSchoolEntities();
        [Route("Save/{hdr_Ac_BookPublisher}")]
        [HttpPost]
        public IHttpActionResult Savehdr_Ac_BookPublisher(hdr_Ac_bookPublisher hdr_Ac_BookPublisher)
        {
            try
            {
                hdr_Ac_bookPublisher hdracbookPublisher = new hdr_Ac_bookPublisher();
                hdracbookPublisher.Code = hdr_Ac_BookPublisher.Code;
                hdracbookPublisher.Publisher = hdr_Ac_BookPublisher.Publisher;
                hdracbookPublisher.Address = hdr_Ac_BookPublisher.Address;
                hdracbookPublisher.Country = hdr_Ac_BookPublisher.Country;
                hdracbookPublisher.PhoneNo = hdr_Ac_BookPublisher.PhoneNo;
                hdracbookPublisher.Email = hdr_Ac_BookPublisher.Email;
                hdracbookPublisher.WebUrl = hdr_Ac_BookPublisher.WebUrl;
                hdracbookPublisher.entityId = hdr_Ac_BookPublisher.entityId;
                hdr_Ac_Book_Publisher.hdr_Ac_bookPublisher.Add(hdracbookPublisher);
                hdr_Ac_Book_Publisher.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_Ac_BookPublisher);
        }
        [HttpGet]
        [Route("Get_hdr_AC_BookPublisher")]
        public IEnumerable<hdr_Ac_bookPublisher> GetAll()
        {
            var obj = hdr_Ac_Book_Publisher.Set<hdr_Ac_bookPublisher>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_AC_BookPublisher_ByentityId/{id}")]

        public async Task<List<hdr_Ac_pulisher>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_Ac_Book_Publisher.hdr_Ac_bookPublisher
                         where
                         (id == hdr.entityId)
                         select new hdr_Ac_pulisher()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             Publisher = hdr.Publisher,
                             Address = hdr.Address,
                             Country = hdr.Country,
                             PhoneNo = hdr.PhoneNo,
                             Email = hdr.Email,
                             WebUrl = hdr.WebUrl,
                         }).ToList();
            return query;
        }
    }
}
