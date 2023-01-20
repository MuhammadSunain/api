using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class hdr_Ac_Author
    {
        public int Id { get; internal set; }
        public string Code { get; internal set; }
        public string AuthorType { get; internal set; }
        public string NickName { get; internal set; }
        public string Name { get; internal set; }
        public string Country { get; internal set; }
        public string YearBorn { get; internal set; }
        public string YearDied { get; internal set; }
        public string Awards { get; internal set; }
    }
}