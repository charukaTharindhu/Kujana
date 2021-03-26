using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class MySupport
    {
        [Key]
        public int SupportID { get; set; }
        public String SelectProgaramm { get; set; }
        public String SupportPurpose { get; set; }
        public String SupportCategory { get; set; }
        public String Support_Item { get; set; }
        public String Biller_type { get; set; }
        public String Service_Provider { get; set; }
        public String Ratio { get; set; }
        public String SVC_Booking { get; set; }
        public String Qty_week { get; set; }
        public String Week { get; set; }
        public String Total_units { get; set; }
        public String Unit_Price { get; set; }
        public String Total_price { get; set; }
        public String UnitOfMeasure { get; set; }

        public int MainBudgetID { get; set; }
        public MainBudgetAgreement MainBudgetAgreement { get; set; }

    }
}
