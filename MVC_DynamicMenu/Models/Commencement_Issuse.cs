using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class Commencement_Issuse
    {
        [Key]
        public int CommencementID { get; set; }
        public string Program_Details_and_Support_needs { get; set; }
        public string Comments { get; set; }
        public string Issues { get; set; }
        public string Select_Other_issues { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }

    }
}
