using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebExperience.Models
{
    public class Asset
    {
        public int id { get; set; }
        public string asset_id { get; set; }
        public string file_name { get; set; }
        public string mime_type { get; set; }
        public string created_by { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string description { get; set; }
    }
}