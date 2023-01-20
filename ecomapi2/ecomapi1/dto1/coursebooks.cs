using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecomapi1.dto1
{
    public class coursebooks
    {
        public int Id { get; internal set; }
        public string bookno { get; internal set; }
        public string course { get; internal set; }
        public string subject { get; internal set; }
        public string subtype { get; internal set; }
        public string bookname { get; internal set; }
        public string tag { get; internal set; }
        public string author { get; internal set; }
        public string publisher { get; internal set; }
        public string barcode { get; internal set; }
        public string price { get; internal set; }
        public string edition { get; internal set; }
        public string year { get; internal set; }
        public string seriesname { get; internal set; }
    }
}