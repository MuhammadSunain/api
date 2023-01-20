using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class dto_hdr_SM_student_info
    {
        internal string grno;
        internal string gender;
        internal string mobileno;
        internal DateTime? joingdate;
        internal DateTime? admissiondate;

        public int Id { get; internal set; }
        public string StudentID { get; internal set; }
        public string StudentCategory { get; internal set; }
        public string LastName { get; internal set; }
        public DateTime? DateofBirth { get; internal set; }
        public string CNIC { get; internal set; }
        public string Nationality { get; internal set; }
        public string Religon { get; internal set; }
        public string Address { get; internal set; }
        public string Country { get; internal set; }
        public string State { get; internal set; }
        public string City { get; internal set; }
        public string Phoneno { get; internal set; }
        public string Email { get; internal set; }
    }
}