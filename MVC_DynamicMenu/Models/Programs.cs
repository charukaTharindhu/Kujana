using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class Programs
    {
        [Key]
        public int ProgramID { get; set; }
        public string Program { get; set; }
        public string Commenced { get; set; }
        public string DateOfExit { get; set; }
        public string Pause { get; set; }
        public string Resume { get; set; }
        public string Setting { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }

    }
}
