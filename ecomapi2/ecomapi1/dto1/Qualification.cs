using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class Qualification
    {
        public int Id { get; internal set; }
        public string Code { get; internal set; }
        public string QualificationType { get; internal set; }
        public object Description { get; internal set; }
        public string qualification { get; internal set; }
    }
}