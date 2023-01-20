using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecomapi1.Controllers.Student
{
    [RoutePrefix("api/hdr_SM_StudentInfo")]
    public class hdr_Sm_studentinfoController : ApiController
    {
        ecomSchoolEntities hdr_SM_StudentInfo = new ecomSchoolEntities();
        [Route("Save/{hdr_SM_studentInfo}")]
        [HttpPost]
        public IHttpActionResult Savehdr_SM_studentInfo(hdr_Sm_studentinfo hdr_SM_studentInfo)
        {
            try
            {
                hdr_Sm_studentinfo hdr_studentinfo = new hdr_Sm_studentinfo();
                hdr_studentinfo.StudentID = hdr_SM_studentInfo.StudentID;
                hdr_studentinfo.grno = hdr_SM_studentInfo.grno;
                hdr_studentinfo.StudentCategory = hdr_SM_studentInfo.StudentCategory;
                hdr_studentinfo.FullName = hdr_SM_studentInfo.FullName;
                hdr_studentinfo.LastName = hdr_SM_studentInfo.LastName;
                hdr_studentinfo.DateofBirth = hdr_SM_studentInfo.DateofBirth;
                hdr_studentinfo.CNIC = hdr_SM_studentInfo.CNIC;
                hdr_studentinfo.Nationality = hdr_SM_studentInfo.Nationality;
                hdr_studentinfo.gender = hdr_SM_studentInfo.gender;
                hdr_studentinfo.Religon = hdr_SM_studentInfo.Religon;
                hdr_studentinfo.Address = hdr_SM_studentInfo.Address;
                hdr_studentinfo.Country = hdr_SM_studentInfo.Country;
                hdr_studentinfo.State = hdr_SM_studentInfo.State;
                hdr_studentinfo.City = hdr_SM_studentInfo.City;
                hdr_studentinfo.Phoneno = hdr_SM_studentInfo.Phoneno;
                hdr_studentinfo.mobileno = hdr_SM_studentInfo.mobileno;
                hdr_studentinfo.joingdate = hdr_SM_studentInfo.joingdate;
                hdr_studentinfo.admissiondate = hdr_SM_studentInfo.admissiondate;
                hdr_studentinfo.syllabus = hdr_SM_studentInfo.syllabus;
                hdr_studentinfo.Course = hdr_SM_studentInfo.Course;
                hdr_studentinfo.Section = hdr_SM_studentInfo.Section;
                hdr_studentinfo.Sectiongroup = hdr_SM_studentInfo.Sectiongroup;
                hdr_studentinfo.fatherName = hdr_SM_studentInfo.fatherName;
                hdr_studentinfo.fatherincome = hdr_SM_studentInfo.fatherincome;
                hdr_studentinfo.Contactno = hdr_SM_studentInfo.Contactno;
                hdr_studentinfo.fathercnic = hdr_SM_studentInfo.fathercnic;
                hdr_studentinfo.whatsappno = hdr_SM_studentInfo.whatsappno;
                hdr_studentinfo.fatheremail = hdr_SM_studentInfo.fatheremail;
                hdr_studentinfo.fatheraddress = hdr_SM_studentInfo.fatheraddress;
                hdr_studentinfo.fathercountry = hdr_SM_studentInfo.fathercountry;
                hdr_studentinfo.fatherstate = hdr_SM_studentInfo.fatherstate;
                hdr_studentinfo.fathercity = hdr_SM_studentInfo.fathercity;
                hdr_studentinfo.mothername = hdr_SM_studentInfo.mothername;
                hdr_studentinfo.mothercnic = hdr_SM_studentInfo.mothercnic;
                hdr_studentinfo.mothercontactno = hdr_SM_studentInfo.mothercontactno;
                hdr_studentinfo.motherwhatsapp = hdr_SM_studentInfo.motherwhatsapp;
                hdr_studentinfo.motheremail = hdr_SM_studentInfo.motheremail;
                hdr_studentinfo.motheraddres = hdr_SM_studentInfo.motheraddres;
                hdr_studentinfo.mothercountry = hdr_SM_studentInfo.mothercountry;
                hdr_studentinfo.motherstate = hdr_SM_studentInfo.motherstate;
                hdr_studentinfo.mothercity = hdr_SM_studentInfo.mothercity;
                hdr_studentinfo.emergencyrelagion = hdr_SM_studentInfo.emergencyrelagion;
                hdr_studentinfo.emergencypersonname = hdr_SM_studentInfo.emergencypersonname;
                hdr_studentinfo.emergencycnic = hdr_SM_studentInfo.emergencycnic;
                hdr_studentinfo.emergencycontactno = hdr_SM_studentInfo.emergencycontactno;
                hdr_studentinfo.entityId = hdr_SM_studentInfo.entityId;
                hdr_SM_StudentInfo.hdr_Sm_studentinfo.Add(hdr_studentinfo);
                hdr_SM_StudentInfo.SaveChanges();
                return Ok("MESSAGE");
            }
            catch(Exception)
            {
                throw;
            }
            return Ok(hdr_SM_studentInfo);
        }
        [HttpGet]
        [Route("Get_hdr_SM_student_Info")]
        public IEnumerable<hdr_Sm_studentinfo> GetAll()
        {
            var obj = hdr_SM_StudentInfo.Set<hdr_Sm_studentinfo>().ToList();
            return obj;
        }
        [HttpGet]
        [Route("Gethdr_SM_student_InfoByentityId/{id}")]

        public async Task<List<dto_hdr_SM_student_info>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_SM_StudentInfo.hdr_Sm_studentinfo
                         where
                         (id == hdr.entityId)
                         select new dto_hdr_SM_student_info()
                         {
                             Id = hdr.Id,
                             requesterid = hdr.StudentID,
                             StudentID = hdr.StudentID,
                             grno = hdr.grno,
                             StudentCategory = hdr.StudentCategory,
                             FullName = hdr.FullName,
                             requestername = hdr.FullName,
                             LastName = hdr.LastName,
                             DateofBirth = hdr.DateofBirth,
                             CNIC = hdr.CNIC,
                             Nationality = hdr.Nationality,
                             gender = hdr.gender,
                             Religon = hdr.Religon,
                             Address = hdr.Address,
                             Country = hdr.Country,
                             State = hdr.State,
                             City = hdr.City,
                             Phoneno = hdr.Phoneno,
                             mobileno = hdr.mobileno,
                             Email = hdr.Email,
                             joingdate = hdr.joingdate,
                             admissiondate = hdr.admissiondate,
                             syllabus = hdr.syllabus,
                             Course = hdr.Course,
                             Section = hdr.Section,
                             Sectiongroup = hdr.Sectiongroup,
                             fatherName = hdr.fatherName,
                             fatherincome = hdr.fatherincome,
                             Contactno = hdr.Contactno,
                             fathercnic = hdr.fathercnic,
                             whatsappno = hdr.whatsappno,
                             fatheremail = hdr.fatheremail,
                             fatheraddress = hdr.fatheraddress,
                             fathercountry = hdr.fathercountry,
                             fatherstate = hdr.fatherstate,
                             fathercity = hdr.fathercity,
                             mothername = hdr.mothername,
                             mothercnic = hdr.mothercnic,
                             mothercontactno = hdr.mothercontactno,
                             motherwhatsapp = hdr.motherwhatsapp,
                             motheremail = hdr.motheremail,
                             motheraddres = hdr.motheraddres,
                             mothercountry = hdr.mothercountry,
                             motherstate = hdr.motherstate,
                             mothercity = hdr.mothercity,
                             emergencyrelagion = hdr.emergencyrelagion,
                             emergencypersonname = hdr.emergencypersonname,
                             emergencycnic = hdr.emergencycnic,
                             emergencycontactno = hdr.emergencycontactno
                         }).ToList();
            return query;
        }
        [HttpGet]
        [Route("Gethdr_SM_student_InfoByentityId_course_and_section/{id}/{course}/{section}")]

        public async Task<List<dto_hdr_SM_student_info>> GetEntityById(int id, string course, string section)
        {
            var query = (from hdr in hdr_SM_StudentInfo.hdr_Sm_studentinfo
                         where
                         (id == hdr.entityId && course == hdr.Course && section == hdr.Section)
                         select new dto_hdr_SM_student_info()
                         {
                             Id = hdr.Id,
                             StudentID = hdr.StudentID,
                             grno = hdr.grno,
                             StudentCategory = hdr.StudentCategory,
                             FullName = hdr.FullName,
                             LastName = hdr.LastName,
                             DateofBirth = hdr.DateofBirth,
                             CNIC = hdr.CNIC,
                             Nationality = hdr.Nationality,
                             gender = hdr.gender,
                             Religon = hdr.Religon,
                             Address = hdr.Address,
                             Country = hdr.Country,
                             State = hdr.State,
                             City = hdr.City,
                             Phoneno = hdr.Phoneno,
                             mobileno = hdr.mobileno,
                             Email = hdr.Email,
                             joingdate = hdr.joingdate,
                             admissiondate = hdr.admissiondate,
                             syllabus = hdr.syllabus,
                             Course = hdr.Course,
                             Section = hdr.Section,
                             Sectiongroup = hdr.Sectiongroup,
                             fatherName = hdr.fatherName,
                             fatherincome = hdr.fatherincome,
                             Contactno = hdr.Contactno,
                             fathercnic = hdr.fathercnic,
                             whatsappno = hdr.whatsappno,
                             fatheremail = hdr.fatheremail,
                             fatheraddress = hdr.fatheraddress,
                             fathercountry = hdr.fathercountry,
                             fatherstate = hdr.fatherstate,
                             fathercity = hdr.fathercity,
                             mothername = hdr.mothername,
                             mothercnic = hdr.mothercnic,
                             mothercontactno = hdr.mothercontactno,
                             motherwhatsapp = hdr.motherwhatsapp,
                             motheremail = hdr.motheremail,
                             motheraddres = hdr.motheraddres,
                             mothercountry = hdr.mothercountry,
                             motherstate = hdr.motherstate,
                             mothercity = hdr.mothercity,
                             emergencyrelagion = hdr.emergencyrelagion,
                             emergencypersonname = hdr.emergencypersonname,
                             emergencycnic = hdr.emergencycnic,
                             emergencycontactno = hdr.emergencycontactno
                         }).ToList();
            return query;
        }
    }
}
