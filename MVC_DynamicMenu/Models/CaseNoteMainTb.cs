using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class CaseNoteMainTb
    {
        [Key]

        public int ID { get; set; }
        public string Date { get; set; }
        public string Hours { get; set; }
        public string Participant { get; set; }
        public string Note_Summary { get; set; }
        public string Added_By { get; set; }
        public string Contact_type { get; set; }
    }
}
