using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class AddDocument_Skill
    {
        [Key]
        public int DocID { get; set; }
        public String  Description { get; set; }
        public String Certificate_number { get; set; }
        public String Competency { get; set; }
        public String Completed { get; set; }
        public String Alert_template { get; set; }
        public String Valid_for { get; set; }
        public String Expiry_date { get; set; }
        public String Send_alert { get; set; }
        public String Preriod_befor_Expiring_reminder { get; set; }
        public String Checked_by { get; set; }
        public String Select_file { get; set; }
    }
}
