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
    [RoutePrefix("api/hdr_AC_Subject")]
    public class hdr_ac_SubjectController : ApiController
    {
        ecomSchoolEntities hdr_Ac_Subject = new ecomSchoolEntities();
        [Route("Save/{hdr_Ac_subject}")]
        [HttpPost]
        public IHttpActionResult Savehdr_Ac_subject(hdr_AC_Subject hdr_Ac_subject)
        {
            try
            {
                hdr_AC_Subject hdracsubject = new hdr_AC_Subject();
                hdracsubject.Code = hdr_Ac_subject.Code;
                hdracsubject.entityId = hdr_Ac_subject.entityId;
                hdracsubject.SubjectType = hdr_Ac_subject.SubjectType;
                hdracsubject.Syllabus = hdr_Ac_subject.Syllabus;
                hdracsubject.Course = hdr_Ac_subject.Course;
                hdracsubject.Language = hdr_Ac_subject.Language;
                hdracsubject.PeriodsPerWeek = hdr_Ac_subject.PeriodsPerWeek;
                hdracsubject.SubjectName = hdr_Ac_subject.SubjectName;
                hdracsubject.SubjectCategory = hdr_Ac_subject.SubjectCategory;
                hdracsubject.SubjectClass = hdr_Ac_subject.SubjectClass;
                hdracsubject.Compulsory = hdr_Ac_subject.Compulsory;
                hdr_Ac_Subject.hdr_AC_Subject.Add(hdracsubject);
                hdr_Ac_Subject.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_Ac_subject);
        }
        [Route("Get_hdr_AC_Subjects")]
        public IEnumerable<hdr_AC_Subject> GetAll()
        {
            var obj = hdr_Ac_Subject.Set<hdr_AC_Subject>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_AC_Subjects_ByentityId/{id}")]

        public async Task<List<dto_hdr_AC_subject>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_Ac_Subject.hdr_AC_Subject
                         where
                         (id == hdr.entityId)
                         select new dto_hdr_AC_subject()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             SubjectType = hdr.SubjectType,
                             Course = hdr.Course,
                             Syllabus = hdr.Syllabus,
                             Language = hdr.Language,
                             PeriodsPerWeek = hdr.PeriodsPerWeek,
                             SubjectName = hdr.SubjectName,
                             SubjectCategory = hdr.SubjectCategory,
                             SubjectClass = hdr.SubjectClass,
                             Compulsory = hdr.Compulsory,
                         }).ToList();
            return query;
        }
        [HttpGet]
        [Route("Gethdr_AC_Subjects_ByentityId_and_courseID/{id}/{courseid}")]

        public async Task<List<dto_hdr_AC_subject>> GetEntityById(int id, string courseid)
        {
            var query = (from hdr in hdr_Ac_Subject.hdr_AC_Subject
                         where
                         (id == hdr.entityId && courseid == hdr.Course)
                         select new dto_hdr_AC_subject()
                         {
                             Id = hdr.Id,
                             Code = hdr.Code,
                             SubjectType = hdr.SubjectType,
                             Syllabus = hdr.Syllabus,
                             Course = hdr.Course,
                             Language = hdr.Language,
                             PeriodsPerWeek = hdr.PeriodsPerWeek,
                             SubjectName = hdr.SubjectName,
                             SubjectCategory = hdr.SubjectCategory,
                             SubjectClass = hdr.SubjectClass,
                             Compulsory = hdr.Compulsory,
                         }).ToList();
            return query;
        }
    }
}
