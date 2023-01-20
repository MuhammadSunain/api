using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class hdr_Ac_pulisher
    {
        public int Id { get; internal set; }
        public string Code { get; internal set; }
        public string Publisher { get; internal set; }
        public string Address { get; internal set; }
        public string Country { get; internal set; }
        public string PhoneNo { get; internal set; }
        public string Email { get; internal set; }
        public string WebUrl { get; internal set; }
    }
}