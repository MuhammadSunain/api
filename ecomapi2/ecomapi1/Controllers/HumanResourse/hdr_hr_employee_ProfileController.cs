using ecomapi1.dto1;
using ecomapi1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecomapi1.Controllers.HumanResourse
{
    [RoutePrefix("api/hdr_HR_EmployeeProfile")]
    public class hdr_hr_employee_ProfileController : ApiController
    {
        ecomSchoolEntities hdr_HR_EmployeeData = new ecomSchoolEntities();
        [Route("Save/{hdr_hr_employeeData}")]
        [HttpPost]
        public IHttpActionResult Savehdr_hr_employeeData(hdr_HR_EmployeeProfile hdr_hr_employeeData)
        {
            try
            {
                hdr_HR_EmployeeProfile hr_Employeeinfo = new hdr_HR_EmployeeProfile();
                hr_Employeeinfo.empid = hdr_hr_employeeData.empid;
                hr_Employeeinfo.shrotcode = hdr_hr_employeeData.shrotcode;
                hr_Employeeinfo.machinecode = hdr_hr_employeeData.machinecode;
                hr_Employeeinfo.joindate = hdr_hr_employeeData.joindate;
                hr_Employeeinfo.firstname = hdr_hr_employeeData.firstname;
                hr_Employeeinfo.lastname = hdr_hr_employeeData.lastname;
                hr_Employeeinfo.dateofbirth = hdr_hr_employeeData.dateofbirth;
                hr_Employeeinfo.Gender = hdr_hr_employeeData.Gender;
                hr_Employeeinfo.bloodgroup = hdr_hr_employeeData.bloodgroup;
                hr_Employeeinfo.CNIC = hdr_hr_employeeData.CNIC;
                hr_Employeeinfo.birthcountry = hdr_hr_employeeData.birthcountry;
                hr_Employeeinfo.birthcity = hdr_hr_employeeData.birthcity;
                hr_Employeeinfo.nationality = hdr_hr_employeeData.nationality;
                hr_Employeeinfo.religion = hdr_hr_employeeData.religion;
                hr_Employeeinfo.email = hdr_hr_employeeData.email;
                hr_Employeeinfo.contactno = hdr_hr_employeeData.contactno;
                hr_Employeeinfo.whatsappno = hdr_hr_employeeData.whatsappno;
                hr_Employeeinfo.emptype = hdr_hr_employeeData.emptype;
                hr_Employeeinfo.empcategory = hdr_hr_employeeData.empcategory;
                hr_Employeeinfo.empdepartment = hdr_hr_employeeData.empdepartment;
                hr_Employeeinfo.empdestination = hdr_hr_employeeData.empdestination;
                hr_Employeeinfo.site = hdr_hr_employeeData.site;
                hr_Employeeinfo.entityId = hdr_hr_employeeData.entityId;
                hr_Employeeinfo.clientId = hdr_hr_employeeData.clientId;
                hdr_HR_EmployeeData.hdr_HR_EmployeeProfile.Add(hr_Employeeinfo);
                hdr_HR_EmployeeData.SaveChanges();
                return Ok("MESSAGE");
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(hdr_hr_employeeData);
        }
        [HttpGet]
        [Route("Get_hdr_HR_employee_Info")]
        public IEnumerable<hdr_HR_EmployeeProfile> GetAll()
        {
            var obj = hdr_HR_EmployeeData.Set<hdr_HR_EmployeeProfile>().ToList();
            return obj;
        }
        //HR_Employeeinfo
        [HttpGet]
        [Route("Gethdr_HR_EMPLOYEE_InfoByentityId/{id}")]

        public async Task<List<HR_Employeeinfo>> GetEntityById(int id)
        {
            var query = (from hdr in hdr_HR_EmployeeData.hdr_HR_EmployeeProfile
                         where
                         (id == hdr.entityId)
                         select new HR_Employeeinfo()
                         {
                             Id = hdr.Id,
                             requesterid = hdr.empid,
                             requestername = hdr.firstname,
                             empid = hdr.empid,
                             shrotcode = hdr.shrotcode,
                             machinecode = hdr.machinecode,
                             joindate = hdr.joindate,
                             firstname = hdr.firstname,
                             lastname = hdr.lastname,
                             dateofbirth = hdr.dateofbirth,
                             Gender = hdr.Gender,
                             bloodgroup = hdr.bloodgroup,
                             CNIC = hdr.CNIC,
                             birthcountry = hdr.birthcountry,
                             birthcity = hdr.birthcity,
                             nationality = hdr.nationality,
                             religion = hdr.religion,
                             email = hdr.email,
                             contactno = hdr.contactno,
                             whatsappno = hdr.whatsappno,
                             emptype = hdr.emptype,
                             empcategory = hdr.empcategory,
                             empdepartment = hdr.empdepartment,
                             empdestination = hdr.empdestination,
                             site = hdr.site,
                         }).ToList();
            return query;
        }
    }
}
