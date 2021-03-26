using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class NewCallNote
    {
        [Key]
        public int CallNoteID { get; set; }
        public string Type_of_Past_noteOBelow { get; set; }
        public string Program { get; set; }
        public int PraticipantID { get; set; }
    }
}
