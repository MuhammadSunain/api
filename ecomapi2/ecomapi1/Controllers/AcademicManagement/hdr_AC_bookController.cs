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
    [RoutePrefix("api/hdr_AC_Book")]
    public class hdr_AC_bookController : ApiController
    {
        ecomSchoolEntities hdr_Ac_Course_Book = new ecomSchoolEntities();
        [Route("Save{hdr_ac_Book}")]
        [HttpPost]
        public IHttpActionResult Savehdr_ac_Book(hdr_Ac_Book hdr_ac_Book, int booknum)
        {   
            try
            {
                hdr_Ac_Book bookobj = new hdr_Ac_Book();
                bookobj.bookno = bookobj.bookno;
                bookobj.course = hdr_ac_Book.course;
                bookobj.Subject = hdr_ac_Book.Subject;
                bookobj.subtype = hdr_ac_Book.subtype;
                bookobj.bookname = hdr_ac_Book.bookname;
                bookobj.tag = hdr_ac_Book.tag;
                bookobj.author = hdr_ac_Book.author;
                bookobj.publisher = hdr_ac_Book.publisher;
                bookobj.barcode = hdr_ac_Book.barcode;
                bookobj.price = hdr_ac_Book.price;
                bookobj.edition = hdr_ac_Book.edition;
                bookobj.year = hdr_ac_Book.year;
                bookobj.seriesname = hdr_ac_Book.seriesname;
                bookobj.entityId = hdr_ac_Book.entityId;
                bookobj.clientId = hdr_ac_Book.clientId;
                hdr_Ac_Course_Book.hdr_Ac_Book.Add(bookobj);
                hdr_Ac_Course_Book.SaveChanges();
                return Ok("MESSAGE"); 
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_ac_Book);
        }
        [HttpGet]
        [Route("Get_hdr_AC_CourseBook")]
        public IEnumerable<hdr_Ac_Book> GetAll()
        {
            var obj = hdr_Ac_Course_Book.Set<hdr_Ac_Book>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Getut_getCourseBooks_ByentityId/{id}")]
        public async Task<List<coursebooks>> GetByEntityId(int id)
        {
            var query = (from hdr in hdr_Ac_Course_Book.hdr_Ac_Book
                         where
                         (id == hdr.entityId)
                         select new coursebooks()
                         {
                             Id = hdr.Id,
                             bookno = hdr.bookno,
                             course = hdr.course,
                             subject = hdr.Subject,
                             subtype = hdr.subtype,
                             bookname = hdr.bookname,
                             tag = hdr.tag,
                             author = hdr.author,
                             publisher = hdr.publisher,
                             barcode = hdr.barcode,
                             price = hdr.price,
                             edition = hdr.edition,
                             year = hdr.year,
                             seriesname = hdr.seriesname
                         }).ToList();
            return query;
        }
    }

}
