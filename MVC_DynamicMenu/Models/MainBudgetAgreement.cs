using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Models
{
    public class MainBudgetAgreement
    {
        [Key]
        public int MainBudgetID { get; set; }
        public int NDIS_ID { get; set; }
        public String Client_Name { get; set; }
        public String Start_Date { get; set; }
        public String End_Date { get; set; }
        public String Date_of_birth { get; set; }
        public String Actions { get; set; }

        public List<AdditionalActivityClass> AdditionalActivityClass { get; set; }
        public List<AllocateBudgetAgreement> AllocateBudgetAgreement { get; set; }
        public List<MySupport> MySupport { get; set; }
        public List<ServiceSchedules> ServiceSchedules { get; set; }
       
    }
}
