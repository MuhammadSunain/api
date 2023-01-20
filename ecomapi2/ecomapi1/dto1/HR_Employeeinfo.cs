using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class HR_Employeeinfo
    {
        internal string requestername;

        public int Id { get; internal set; }
        public int? empid { get; internal set; }
        public string shrotcode { get; internal set; }
        public string machinecode { get; internal set; }
        public string joindate { get; internal set; }
        public string firstname { get; internal set; }
        public string lastname { get; internal set; }
        public string dateofbirth { get; internal set; }
        public string Gender { get; internal set; }
        public string bloodgroup { get; internal set; }
        public string CNIC { get; internal set; }
        public string birthcountry { get; internal set; }
        public string birthcity { get; internal set; }
        public string nationality { get; internal set; }
        public string religion { get; internal set; }
        public string email { get; internal set; }
        public string contactno { get; internal set; }
        public string whatsappno { get; internal set; }
        public string emptype { get; internal set; }
        public string empcategory { get; internal set; }
        public string empdepartment { get; internal set; }
        public string empdestination { get; internal set; }
        public string site { get; internal set; }
        public int? requesterid { get; internal set; }
    }
}