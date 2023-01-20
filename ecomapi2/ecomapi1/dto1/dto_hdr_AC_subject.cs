using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class dto_hdr_AC_subject
    {
        public int Id { get; internal set; }
        public string Code { get; internal set; }
        public string SubjectType { get; internal set; }
        public string Course { get; internal set; }
        public string Language { get; internal set; }
        public string PeriodsPerWeek { get; internal set; }
        public string SubjectName { get; internal set; }
        public string SubjectCategory { get; internal set; }
        public string SubjectClass { get; internal set; }
        public string Compulsory { get; internal set; }
        public string Syllabus { get; internal set; }
    }
}