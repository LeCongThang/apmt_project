using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APMT.Areas.Company.Models
{
    public class userCompany
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public bool? isAllowed { get; set; }
        public string avartar { get; set; }
        public string createAt { get; set; }
        public string updateAt { get; set; }
    }
}