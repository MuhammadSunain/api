using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class dtout_User_Auth
    {

        public int Id { get; internal set; }
        public string Entity { get; internal set; }
        public string Username { get; internal set; }
        public string Password { get; internal set; }
        public string Fullname { get; internal set; }
        public string Email { get; internal set; }
        public string CellNo { get; internal set; }
        public string UserCategory { get; internal set; }
        public string Role { get; internal set; }
        public string Status { get; internal set; }
        public int? entityid { get; internal set; }
    }
}