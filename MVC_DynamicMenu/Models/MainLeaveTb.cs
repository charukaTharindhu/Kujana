using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class MainLeaveTb
    {
        [Key]
        public int LeaveID { get; set; }
        public string Worker { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }
        public string Comment { get; set; }
        public string Approved { get; set; }
    }
}
