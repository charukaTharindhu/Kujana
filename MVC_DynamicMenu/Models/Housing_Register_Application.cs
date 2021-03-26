using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class Housing_Register_Application
    {
        [Key]
        public int ApplicationID { get; set; }
        public string Application_type { get; set; }
        public string priority_catogory { get; set; }
        public string priority_type { get; set; }
        public string Date_Submited { get; set; }
        public string Location_Submited { get; set; }
        public string Application_number { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }
    }
}
