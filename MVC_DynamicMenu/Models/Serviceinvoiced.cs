using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class Serviceinvoiced
    {
        [Key]
        public int Reference { get; set; }
        public String Claim_status { get; set; }
        public int Claim_number { get; set; }
        public String Claim_External_refewnce { get; set; }
        public String Client { get; set; }
        public String Activiti_start_day { get; set; }
        public String Invoice_date { get; set; }
        public String Suport_item { get; set; }
        public String Service { get; set; }
        public String Provider { get; set; }
        public String Biller_type { get; set; }
        public String Total { get; set; }
        public String Actions { get; set; }
    }
}
