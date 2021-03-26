using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class MainCallNoteTb
    {
        [Key]
        public int ParticipantID { get; set; }
        public string Call_note { get; set; }
    }
}
