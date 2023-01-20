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
    [RoutePrefix("api/hdr_AC_Book_Author")]
    public class hdr_Ac_bookAuthorController : ApiController
    {
        ecomSchoolEntities hdr_Ac_Book_Author = new ecomSchoolEntities();
        [Route("Save/{hdr_Ac_BookAuthor}")]
        [HttpPost]
        public IHttpActionResult Savehdr_Ac_BookAuthor(hdr_Ac_bookAuthor hdr_Ac_BookAuthor)
        {
            try
            {
                hdr_Ac_bookAuthor hdracbookauthor = new hdr_Ac_bookAuthor();
                hdracbookauthor.Code = hdr_Ac_BookAuthor.Code;
                hdracbookauthor.AuthorType = hdr_Ac_BookAuthor.AuthorType;
                hdracbookauthor.NickName = hdr_Ac_BookAuthor.NickName;
                hdracbookauthor.Name = hdr_Ac_BookAuthor.Name;
                hdracbookauthor.Country = hdr_Ac_BookAuthor.Country;
                hdracbookauthor.YearBorn = hdr_Ac_BookAuthor.YearBorn;
                hdracbookauthor.YearDied = hdr_Ac_BookAuthor.YearDied;
                hdracbookauthor.Awards = hdr_Ac_BookAuthor.Awards;
                hdracbookauthor.entityId = hdr_Ac_BookAuthor.entityId;
                hdr_Ac_Book_Author.hdr_Ac_bookAuthor.Add(hdracbookauthor);
                hdr_Ac_Book_Author.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_Ac_BookAuthor);
        }
        [HttpGet]
        [Route("Get_hdr_AC_BookAuthor")]
        public IEnumerable<hdr_Ac_bookAuthor> GetAll()
        {
            var obj = hdr_Ac_Book_Author.Set<hdr_Ac_bookAuthor>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_AC_BookAuthor_ByentityId/{id}")]

        public async Task<List<hdr_Ac_Author>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_Ac_Book_Author.hdr_Ac_bookAuthor
                         where
                         (id == hdr.entityId)
                         select new hdr_Ac_Author()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             AuthorType = hdr.AuthorType,
                             NickName = hdr.NickName,
                             Name = hdr.Name,
                             Country = hdr.Country,
                             YearBorn = hdr.YearBorn,
                             YearDied = hdr.YearDied,
                             Awards = hdr.Awards,
                         }).ToList();
            return query;
        }
    }
}
