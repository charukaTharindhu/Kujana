using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class Skills_Avidence
    {
        [Key]

        public int SkillID { get; set; }
        public string Doc { get; set; }
        public string Type { get; set; }
        public string Cert_No { get; set; }
        public string Competency { get; set; }
        public string Data_Completed { get; set; }
        public string Expiry_date { get; set; }
        public string CheckedBy { get; set; }
        public string ExpiryAlerts { get; set; }

    }
}
