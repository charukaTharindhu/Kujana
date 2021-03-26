using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class MyProfile
    {
        [Key]
        public int ProfileID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Mobile_number { get; set; }
        public string NOK { get; set; }
        public string Address { get; set; }
        public string Driver_License { get; set; }
        public string Probation { get; set; }
        public string Rest_Authentication { get; set; }

        public int UserID { get; set; }
        public Users Users { get; set; }
    }
}
