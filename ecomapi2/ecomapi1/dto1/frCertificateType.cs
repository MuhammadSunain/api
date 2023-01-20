using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class frCertificateType
    {
        public string Code { get; internal set; }
        public string certificateType { get; internal set; }
        public string Description { get; internal set; }
        public string CertificateFor { get; internal set; }
    }
}