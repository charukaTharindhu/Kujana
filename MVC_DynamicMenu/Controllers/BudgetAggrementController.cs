using Microsoft.AspNetCore.Mvc;
using MVC_DynamicMenu.Models;
using MVC_DynamicMenu.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Controllers
{
    public class BudgetAggrementController : Controller
    {
        private readonly BudgetAgreementRepo _c = null;

        public BudgetAggrementController(BudgetAgreementRepo c)
        {
            _c = c;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewBudgetAgreement()
        {
            return View(new MainBudgetAgreement());
        }
        [HttpPost]
        public ActionResult AddNewBudgetAgreement(MainBudgetAgreement model)
        {
            model.NDIS_ID = 123;
            model.Client_Name = "Charuka";
            model.Date_of_birth = "";
            model.Start_Date = "";
            model.End_Date = "";

            _c.AddNewBudgetAgreement(model);
            return View(new MainBudgetAgreement());
        }

    }
}
