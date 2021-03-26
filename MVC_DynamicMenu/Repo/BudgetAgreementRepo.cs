using MVC_DynamicMenu.Data;
using MVC_DynamicMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Repo
{
    public class BudgetAgreementRepo
    {
        private readonly DynamicMenuDBContext _c = null;

        public BudgetAgreementRepo(DynamicMenuDBContext c)
        {
            _c = c;
        }

        public void AddNewBudgetAgreement(MainBudgetAgreement model)
        {
            _c.MainBudgetAgreement.Add(model);
            var serviceS = new ServiceSchedules
            {
                Client_name = model.Client_Name,
                Day_of_week = model.Start_Date,
                End_date_and_time = model.End_Date,
                Hierarchy = "-",
                MainBudgetAgreement = model,
                MainBudgetID = model.MainBudgetID,
                Service = model.AllocateBudgetAgreement[0].Support_category,
                Staff = "",
                Status = "Published",
                Start_date_and_time = model.Start_Date,
                
                


            };
            _c.ServiceSchedules.Add(serviceS);
            _c.SaveChanges();
        }
    }
}
