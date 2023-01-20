using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class dtout_Entity_Roles
    {
        public int Id { get; internal set; }
        public string Code { get; internal set; }
        public string Role { get; internal set; }
        public object client { get; internal set; }
    }
}