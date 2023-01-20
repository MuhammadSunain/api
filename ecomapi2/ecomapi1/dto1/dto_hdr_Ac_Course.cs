using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class dto_hdr_Ac_Course
    {
        public int Id { get; internal set; }
        public string Code { get; internal set; }
        public string CourseCategory { get; internal set; }
        public string Course { get; internal set; }
        public string Syllabus { get; internal set; }
        public int? AgeTill { get; internal set; }
        public int? AgeFrom { get; internal set; }
    }
}