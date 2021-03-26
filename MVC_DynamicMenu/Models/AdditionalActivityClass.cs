using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class AdditionalActivityClass
    {
        [Key]
        public int ActivityID { get; set; }
        public String Description_of_costs { get; set; }
        public String Biller { get; set; }
        public String Notes { get; set; }
        public String Debtor { get; set; }
        public String Total_Price { get; set; }

        public int MainBudgetID { get; set; }
        public MainBudgetAgreement MainBudgetAgreement { get; set; }

    }
}
