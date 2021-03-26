using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class MainParticipantTb
    {
        [Key]

        public int NDIS_No { get; set; }
        public String First_Name { get; set; }
        public String Last_Name { get; set; }
        public String DOB { get; set; }
        public String Address { get; set; }
        public String Contact_info{ get; set; }
        public String Programm_Info { get; set; }
        public String Office { get; set; }
        public String Setting { get; set; }
    }
}
