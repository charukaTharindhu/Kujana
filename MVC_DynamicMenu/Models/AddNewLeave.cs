using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class AddNewLeave
    {
        [Key]
        public int LID { get; set; }
        public string Worker { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }  
        public string Comment { get; set; }
    }
}
