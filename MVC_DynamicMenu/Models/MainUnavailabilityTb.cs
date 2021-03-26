using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class MainUnavailabilityTb
    {
        [Key]
        public int UnavailabilityID { get; set; }
        public string Worker { get; set; }
        public string Is_all_day { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }
        public string Recurrance { get; set; }
        public string End_Recurrance { get; set; }
        public string Comment { get; set; }
        public string Approved { get; set; }
    }
}
