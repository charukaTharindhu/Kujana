using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class AllocateBudgetAgreement
    {
        [Key]

        public int AllocateID { get; set; }
        public String Select_Program { get; set; }
        public String Support_purpose { get; set; }
        public String Support_category { get; set; }
        public String Budget { get; set; }
        public String Remaining_budget { get; set; }
        public String Biler_type { get; set; }

        public int MainBudgetID { get; set; }
        public MainBudgetAgreement MainBudgetAgreement { get; set; }



    }
}
